using DemoApi.Model;
using DemoApi.Model.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly BuildingsDatabaseContext _context;

        public BuildingsController(BuildingsDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? minIndex, int? maxIndex)
        {
            List<BuildingInfo> result;
            // If both the minimum and maximum range indices are not specified send a response with all buildings records 
            if (minIndex == null && maxIndex == null)
            {
                result = await GetBuildings().ToListAsync();

                return Content(JsonConvert.SerializeObject(result, Formatting.Indented));
            }

            // If the minimum range index is less or equal to zero, return 404 HTTP response code
            if (minIndex <= 0)
            {
                return NotFound();
            }

            // If the minimum range index is greater than the maximum one, swap them
            if (minIndex > maxIndex)
            {
                var tempIndex = minIndex;
                minIndex = maxIndex;
                maxIndex = tempIndex;
            }

            result = await GetBuildings()
                .Where(b => b.Id >= minIndex && b.Id <= maxIndex)
                .ToListAsync();

            return Content(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await GetBuildings().FirstOrDefaultAsync(b => b.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            return Content(JsonConvert.SerializeObject(result, Formatting.Indented));
        }

        private IQueryable<BuildingInfo> GetBuildings()
        {
            var result = _context.Buildings
                .Include(b => b.City)
                .ThenInclude(b => b.Country)
                .Select(b => new BuildingInfo
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description,
                    Height = b.Height,
                    ArchitecturalStyleName = b.ArchitecturalStyle.Name,
                    CityName = b.City.Name,
                    OpenedYear = b.OpenedYear
                });

            return result.AsQueryable();
        }
    }
}
