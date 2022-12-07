using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DemoApi.Model
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        /* Navigation properties */
        [JsonIgnore]
        public ICollection<City> Cities { get; set; }
    }
}
