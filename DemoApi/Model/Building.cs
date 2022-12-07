using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace DemoApi.Model
{
    public class Building
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(64)]
        [Required]
        public string Name { get; set; }

        [MaxLength(1024)]
        [Required]
        public string Description { get; set; }

        [Range(1, 1000)]
        [Required]
        public int Height { get; set; }

        // Foreign key for ArchitecturalStyle table
        [JsonIgnore]
        public int ArchitecturalStyleId { get; set; }

        // Foreign key for City table
        [Column("Location")]
        [JsonIgnore]
        public int CityId { get; set; }

        [Column("Opened")]
        [Required]
        [Range(1, 9999)]
        public int OpenedYear { get; set; }

        /* Navigation properties */
        [JsonIgnore]
        public ArchitecturalStyle ArchitecturalStyle { get; set; }
        [JsonIgnore]
        public City City { get; set; }
    }
}
