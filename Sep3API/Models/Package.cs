using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Sep3API.Models
{
    public class Package
    {
        [Required]
        [NotNull, Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        [JsonPropertyName("ID")]
        [Key]
        public int ID { get; set; }
        [Required, MaxLength(128)]
        [JsonPropertyName("Name")]
        public  string Name { get; set; }
        [Required, MaxLength(128)]
        [JsonPropertyName("Location")]
        public  string Location { get; set; }
       
        [JsonPropertyName("Price")]
        [Required]
        public  int Price { get; set; }
        [Required]
        [Range(1,10)]
        [JsonPropertyName("Review")]
        public int Review { get; set; }

        public Package(string Name, string Location, int Price, int Review)
        {
            this.Name = Name;
            this.Location = Location;
            this.Price = Price;
            this.Review = Review;
        }
        public override string ToString()
        {
            return ID + " " + Name + " " + Location + " " + Price + " " + Review +"'";
        }
        
    }
}