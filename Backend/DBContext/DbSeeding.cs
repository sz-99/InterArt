using InterArt.Models;
using InterArt_Backend.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace InterArt_Backend.DBContext
{
    public class DbSeeding
    {
        public static void SeedDatabase(ArtworkDbContext context)
        {
            SeedArtworkFromJson(context);
            SeedUsers(context);
        }


        public static void SeedArtworkFromJson(ArtworkDbContext context)
        {
            string folderPath = "./Resources/artworks_copy";
            if (!context.Artworks.Any())
            {
                var artworkList = new List<Artwork>();
                foreach (var file in Directory.GetFiles(folderPath, "*.json"))
                {
                    string json = File.ReadAllText(file);
                    dynamic data = JsonConvert.DeserializeObject(json);
                    var artwork = new Artwork
                    {
                        AicId = data.id, // :white_tick: Only needed if you must keep the original IDs
                        Title = data.title,
                        Artist = data.artist_title,
                        DateDisplay = data.date_display,
                        MediumDisplay = data.medium_display,
                        PlaceOfOrigin = data.place_of_origin,
                        Dimensions = data.dimensions,
                        CreditLine = data.credit_line,
                        ArtworkType = data.artwork_type_title,
                        DepartmentTitle = data.department_title,
                        Classification = data.classification_title,
                        // :white_tick: Fixing material_titles check
                        Material = (data.material_titles != null && data.material_titles.Type == JTokenType.Array)
                            ? string.Join(", ", data.material_titles.ToObject<List<string>>())
                            : null, // If it's not an array, store null
                        IsPublicDomain = data.is_public_domain,
                        // :white_tick: Fixing image_id check
                        ImageUrl = !string.IsNullOrEmpty((string?)data.image_id)
                            ? $"https://www.artic.edu/iiif/2/{data.image_id}/full/843,/0/default.jpg"
                            : null // If image_id is null or empty, store null
                    };
                    artworkList.Add(artwork);
                }
                context.Artworks.AddRange(artworkList);
                context.SaveChanges();
                Console.WriteLine(":white_tick: Data imported successfully!");
            }
            else
            {
                Console.WriteLine(":warning: Database already contains data. No new data was added.");
            }
        }

        public static void SeedUsers(ArtworkDbContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User() { Id = 1, UserName = "testuser1", Email = "testperson1@art.com", Name = "Test User", Password = "$2a$11$GSgb0bqvCx4PMi4Uz81IVuIASsVJxg.PR5E6z0pQA3rlbsRpas3Ba" },
                    new User() { Id = 2, UserName = "testuser2", Email = "testperson2@art.com", Name = "Second Person", Password = "$2a$11$t6H5URO2hcXG3YEelPfsNeFTEt0eSYjq/TuHgGR6pzILYfBWWNfc." },
                    new User() { Id = 3, UserName = "testuser3", Email = "testperson3@art.com", Name = "Third User", Password = "$2a$11$BqK8Im0mjHwAh47eNNlq8OtLVfllgcCjj7aTXkVRgZgifUYy9olc." }
                    );
                context.SaveChanges();
                Console.WriteLine("User data added to database.");
            }

            else
            {
                Console.WriteLine("Database already contains data. No new data was added.");
            }
        }

    }
}
