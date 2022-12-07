using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DemoApi.Model
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        // Foreign key for Country table
        public int CountryId { get; set; }

        /* Navigation properties */
        [JsonIgnore]
        public Country Country { get; set; }
        [JsonIgnore]
        public ICollection<Building> Buildings { get; set; }
    }

}
