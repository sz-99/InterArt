using System.Text.Json.Serialization;

namespace InterArt.Models
{
    public class Artwork
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } =string.Empty;
        [JsonPropertyName("artist_title")]
        public string Artist { get; set; } = string.Empty;
        public int Year { get; set; }
        public string PlaceOfOrigin { get; set; } = string.Empty;
        public string Medium {  get; set; } = string.Empty;
        public string ImageId {  get; set; } = string.Empty;


    }
   

}
