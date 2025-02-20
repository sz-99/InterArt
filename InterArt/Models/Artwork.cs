using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InterArt.Models
{
    public class Artwork
    {
        [Key]
        public int Id { get; set; }

        public string? AicId {  get; set; }
        public string? Title { get; set; }
        public string? Artist { get; set; }
        public string? DateDisplay { get; set; }
        public string? MediumDisplay { get; set; }
        public string? PlaceOfOrigin { get; set; }
        public string? Dimensions { get; set; }
        public string? CreditLine { get; set; }
        public string? ArtworkType { get; set; }
        public string? DepartmentTitle { get; set; }
        public string? Classification { get; set; }
        public string? Material { get; set; }
        public bool IsPublicDomain { get; set; }
        public string? ImageUrl { get; set; }
    }



}
