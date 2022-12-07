using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace DemoApi.Model
{
    public class BuildingsDatabaseContext : DbContext
    {
        public BuildingsDatabaseContext(DbContextOptions<BuildingsDatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ArchitecturalStyle> ArchitecturalStyles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Building> Buildings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var architecturalStyles = new ArchitecturalStyle[]
            {
                new ArchitecturalStyle
                {
                    Id = 1,
                    Name = "Expressionism"
                },
                new ArchitecturalStyle
                {
                    Id = 2,
                    Name = "Mughal architecture"
                },
                new ArchitecturalStyle
                {
                    Id = 3,
                    Name = "Modern architecture"
                },
                new ArchitecturalStyle
                {
                    Id = 4,
                    Name = "Gothic architecture"
                },
                new ArchitecturalStyle
                {
                    Id = 5,
                    Name = "Romanesque architecture"
                },
                new ArchitecturalStyle
                {
                    Id = 6,
                    Name = "Architecture of the Ancient World"
                },
                new ArchitecturalStyle
                {
                    Id = 7,
                    Name = "Art Deco"
                },
                new ArchitecturalStyle
                {
                    Id = 8,
                    Name = "Classical architecture"
                },
                new ArchitecturalStyle
                {
                    Id = 9,
                    Name = "Byzantine architecture"
                },
                new ArchitecturalStyle
                {
                    Id = 10,
                    Name = "High-tech architecture"
                },
                new ArchitecturalStyle
                {
                    Id = 11,
                    Name = "Neoclassical architecture"
                },
                new ArchitecturalStyle
                {
                    Id = 12,
                    Name = "Renaissance architecture"
                }
            };

            var countries = new Country[]
            {
                new Country
                {
                    Id = 1,
                    Name = "Australia",
                },
                new Country
                {
                    Id = 2,
                    Name = "India"
                },
                new Country
                {
                    Id = 3,
                    Name = "United Arab Emirates"
                },
                new Country
                {
                    Id = 4,
                    Name = "Russia"
                },
                new Country
                {
                    Id = 5,
                    Name = "Italy"
                },
                new Country
                {
                    Id = 6,
                    Name = "France"
                },
                new Country
                {
                    Id = 7,
                    Name = "United States of America"
                },
                new Country
                {
                    Id = 8,
                    Name = "Turkey"
                },
                new Country
                {
                    Id = 9,
                    Name = "Great Britain"
                }
            };

            var cities = new City[]
            {
                new City
                {
                    Id = 1,
                    Name = "Sydney",
                    CountryId = 1,
                },
                new City
                {
                    Id = 2,
                    Name = "Agra",
                    CountryId = 2,
                },
                new City
                {
                    Id = 3,
                    Name = "Dubai",
                    CountryId = 3,
                },
                new City
                {
                    Id = 4,
                    Name = "Moscow",
                    CountryId = 4,
                },
                new City
                {
                    Id = 5,
                    Name = "Pisa",
                    CountryId = 5,
                },
                new City
                {
                    Id = 6,
                    Name = "Paris",
                    CountryId = 6,
                },
                new City
                {
                    Id = 7,
                    Name = "Rome",
                    CountryId = 5,
                },
                new City
                {
                    Id = 8,
                    Name = "New York",
                    CountryId = 7,
                },
                new City
                {
                    Id = 9,
                    Name = "Istambul",
                    CountryId = 8
                },
                new City
                {
                    Id = 10,
                    Name = "Abu Dhabi",
                    CountryId = 3,
                },
                new City
                {
                    Id = 11,
                    Name = "London",
                    CountryId = 9,
                }
            };

            var buildings = new Building[]
            {
                new Building
                {
                    Id = 1,
                    Name = "Sydney Opera House",
                    Description = "Multi-venue performing arts centre in Sydney. Located on the foreshore of Sydney Harbour, it is widely regarded as one of the world's most famous and distinctive buildings and a masterpiece of 20th century architecture.",
                    ArchitecturalStyleId = 1,
                    CityId = 1,
                    Height = 65,
                    OpenedYear = 1973,
                },
                new Building
                {
                    Id = 2,
                    Name = "Taj Mahal",
                    Description = "Islamic ivory-white marble mausoleum on the right bank of the river Yamuna in the Indian city of Agra. It was commissioned in 1631 by the Mughal emperor Shah Jahan (r. 1628–1658) to house the tomb of his favourite wife, Mumtaz Mahal; it also houses the tomb of Shah Jahan himself. The tomb is the centrepiece of a 17-hectare (42-acre) complex, which includes a mosque and a guest house, and is set in formal gardens bounded on three sides by a crenellated wall.",
                    ArchitecturalStyleId = 2,
                    CityId = 2,
                    Height = 73,
                    OpenedYear = 1648,
                },
                new Building
                {
                    Id = 3,
                    Name = "Burj Khalifa",
                    Description = "Skyscraper in Dubai, United Arab Emirates. It is known for being the world’s tallest building. With a total height of 829.8 m (2,722 ft, or just over half a mile) and a roof height of 828 m (2,717 ft), the Burj Khalifa has been the tallest structure and building in the world since its topping out in 2009, supplanting Taipei 101, the previous holder of that status.",
                    ArchitecturalStyleId = 3,
                    CityId = 3,
                    Height = 828,
                    OpenedYear = 2010,
                },
                new Building
                {
                    Id = 4,
                    Name = "Saint Basil's Cathedral",
                    Description = "Orthodox church in Red Square of Moscow, and is one of the most popular cultural symbols of Russia. The building, now a museum, is officially known as the Cathedral of the Intercession of the Most Holy Theotokos on the Moat, or Pokrovsky Cathedral. It was built from 1555 to 1561 on orders from Ivan the Terrible and commemorates the capture of Kazan and Astrakhan. It was the city's tallest building until the completion of the Ivan the Great Bell Tower in 1600.",
                    ArchitecturalStyleId = 4,
                    CityId = 4,
                    Height = 47,
                    OpenedYear = 1561,
                },
                new Building
                {
                    Id = 5,
                    Name = "Leaning Tower of Pisa",
                    Description = "Freestanding bell tower, of Pisa Cathedral. It is known for its nearly four-degree lean, the result of an unstable foundation. The tower is one of three structures in the Pisa's Cathedral Square (Piazza del Duomo), which includes the cathedral and Pisa Baptistry",
                    ArchitecturalStyleId = 5,
                    CityId = 5,
                    Height = 58,
                    OpenedYear = 1173,
                },
                new Building
                {
                    Id = 6,
                    Name = "Eiffel Tower",
                    Description = "Wrought-iron lattice tower on the Champ de Mars in Paris, France. It is named after the engineer Gustave Eiffel, whose company designed and built the tower.",
                    ArchitecturalStyleId = 3,
                    CityId = 6,
                    Height = 330,
                    OpenedYear = 1887,
                },
                new Building
                {
                    Id = 7,
                    Name = "Colosseum",
                    Description = "Oval amphitheatre in the centre of the city of Rome, Italy, just east of the Roman Forum. It is the largest ancient amphitheatre ever built, and is still the largest standing amphitheatre in the world today, despite its age. Construction began under the emperor Vespasian (r. 69–79 AD) in 72 and was completed in 80 AD under his successor and heir, Titus (r. 79–81).",
                    ArchitecturalStyleId = 6,
                    CityId = 7,
                    Height = 48,
                    OpenedYear = 72,
                },
                new Building
                {
                    Id = 8,
                    Name = "Empire State Building",
                    Description = "Art Deco skyscraper in Midtown Manhattan, New York City. The building was designed by Shreve, Lamb & Harmon and built from 1930 to 1931. Its name is derived from 'Empire State', the nickname of the state of New York. The building has a roof height of 1,250 feet (380 m) and stands a total of 1,454 feet (443.2 m) tall, including its antenna.",
                    ArchitecturalStyleId = 7,
                    CityId = 8,
                    Height = 443,
                    OpenedYear = 1931,
                },
                new Building
                {
                    Id = 9,
                    Name = "Louvre",
                    Description = "The world's most-visited museum, and an historic landmark in Paris, France. It is the home of some of the best-known works of art, including the Mona Lisa and the Venus de Milo.",
                    ArchitecturalStyleId = 8,
                    CityId = 6,
                    Height = 21,
                    OpenedYear = 1981,
                },
                new Building
                {
                    Id = 10,
                    Name = "Hagia Sophia",
                    Description = "Mosque and major cultural and historical site in Istanbul, Turkey. The cathedral was a Greek Orthodox church from 360 AD until the conquest of Constantinople by the Ottoman Empire in 1453. It served as a mosque until 1935, when it became a museum. In 2020, the site once again became a mosque.",
                    ArchitecturalStyleId = 9,
                    CityId = 9,
                    Height = 55,
                    OpenedYear = 324,
                },
                new Building
                {
                    Id = 11,
                    Name = "56 Leonard Street",
                    Description = "Skyscraper on Leonard Street in the neighborhood of Tribeca in Manhattan, New York City. The building was designed by the Swiss architecture firm Herzog & de Meuron, which describes the building as 'houses stacked in the sky'. It is the tallest structure in Tribeca.",
                    ArchitecturalStyleId = 10,
                    CityId = 8,
                    Height = 250,
                    OpenedYear = 2017,
                },
                new Building
                {
                    Id = 12,
                    Name = "Buckingham Palace",
                    Description = "Royal residence and the administrative headquarters of the monarch of the United Kingdom. Located in the City of Westminster, the palace is often at the centre of state occasions and royal hospitality. It has been a focal point for the British people at times of national rejoicing and mourning",
                    ArchitecturalStyleId = 11,
                    CityId = 11,
                    Height = 108,
                    OpenedYear = 1705
                },
                new Building
                {
                    Id = 13,
                    Name = "Flatiron Building",
                    Description = "Steel-framed landmarked building at 175 Fifth Avenue in the eponymous Flatiron District neighborhood of the borough of Manhattan in New York City. Designed by Daniel Burnham and Frederick P. Dinkelberg, it was completed in 1902 and originally contained 20 floors.",
                    ArchitecturalStyleId = 12,
                    CityId = 8,
                    Height = 87,
                    OpenedYear = 1902,
                },
            };

            modelBuilder.Entity<ArchitecturalStyle>().HasData(architecturalStyles);
            modelBuilder.Entity<Country>().HasData(countries);
            modelBuilder.Entity<City>().HasData(cities);
            modelBuilder.Entity<Building>().HasData(buildings);
        }
    }
}
