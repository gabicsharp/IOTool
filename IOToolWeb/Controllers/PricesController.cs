using System;
using System.Threading.Tasks;
using IOToolDataLibrary.Data;
using IOToolDataLibrary.Models;
using IOToolDataLibrary.Models.CustomTables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IOToolWeb.Controllers
{
    [Authorize(Roles = "Level5")]
    public class PricesController : Controller
    {
        private readonly IPricesData _priceData;
        private readonly ICitiesData _cityData;
        public PricesController(IPricesData priceData, ICitiesData cityData)
        {
            _priceData = priceData;
            _cityData = cityData;
        }

        public async Task<IActionResult> Index()
        {
            var prices = await _priceData.GetAllPricesSummary();
            ViewData["Prices"] = prices;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PricesModel price)
        {
            var origin = await _cityData.GetCityById(price.Id_OriginCity, price.Id_DestinationCity);
            string originCity = "", destinationCity = "";
            int i = 0;
            foreach (var item in origin)
            {
                if (i == 0) 
                {
                    originCity = item.Name;
                   
                }
                if (i == 1)
                {
                    destinationCity = item.Name;
                    break;
                }
                i++;
            }
             
            price.LaneName = $"{originCity}-{destinationCity}";
            price.Id_OriginZip = 1;
            price.Id_DestinationZip = 1;
            price.Id_PartnerLocation = 1;
            price.Active = 1;

            if (ModelState.IsValid)
            {
                await _priceData.InsertPrice(price);
                return RedirectToAction("Index");
            }
            else
            {
                return View(price);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var price = await _priceData.GetPriceByIdToEdit(id);

            return View(price);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NewPriceModel price)
        {
            if (ModelState.IsValid)
            {
                await _priceData.UpdatePrice(price);
                return RedirectToAction("Index");
            }
            else
            {
                return View(price);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            var price = await _priceData.GetPriceById(id);

            return View(price);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(NewPriceModel price)
        {
            await _priceData.DeletePrice(price.Id);

            return RedirectToAction("Index");
        }
    }
}
