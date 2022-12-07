using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DemoApi.Model
{
    public class ArchitecturalStyle
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(32)]
        [Required]
        [JsonProperty("Architectural_Style_Name")]
        public string Name { get; set; }

        /* Navigation properties */
        [JsonIgnore]
        public ICollection<Building> Buildings { get; set; }
    }
}
