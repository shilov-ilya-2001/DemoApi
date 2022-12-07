using Newtonsoft.Json;

namespace DemoApi.Model.Mapping
{
    public class BuildingInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Height { get; set; }
        [JsonProperty("Architectural_Style_Name")]
        public string ArchitecturalStyleName { get; set; }
        [JsonProperty("City_Name")]
        public string CityName { get; set; }
        public int OpenedYear { get; set; }
    }
}
