using System.Threading.Tasks;
using IOToolDataLibrary.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IOToolWeb.Controllers
{
    [Authorize(Roles = "Level5")]
    public class CitiesController : Controller
    {
        private readonly ICitiesData _cityData;

        public CitiesController(ICitiesData cityData)
        {
            _cityData = cityData;
        }


        public async Task<IActionResult> Index()
        {
            var cities = await _cityData.GetAllCitiesWithCountries();
            return View(cities);
        }
    }
}
