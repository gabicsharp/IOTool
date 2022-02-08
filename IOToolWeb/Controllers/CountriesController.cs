using System.Threading.Tasks;
using IOToolDataLibrary.Data;
using IOToolDataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IOToolWeb.Controllers
{
    [Authorize(Roles = "Level5")]
    public class CountriesController : Controller
    {
        private readonly ICountriesData _countryData;

        public CountriesController(ICountriesData countryData)
        {
            _countryData = countryData;
        }


        public async Task<IActionResult> Index()
        {
            var countries = await _countryData.GetAllCountries();
            return View(countries);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var country =  await _countryData.GetCountryById(id);

            return View(country);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CountriesModel supplier)
        {
            await _countryData.DeleteCountry(supplier.Id);

            return RedirectToAction("Index");
        }
    }
}
