using IOToolDataLibrary.Data;
using IOToolDataLibrary.Models;
using IOToolDataLibrary.Models.CustomTables;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace IOToolWeb.Controllers
{
    public class DPsController : Controller
    {
        private readonly ICountriesData _countriesData;
        private readonly ICitiesData _citiesData;
        private readonly IRequestTypesData _requestTypesData;
        private readonly ISuppliersData _suppliersData;
        private readonly ITransportersData _transportersData;
        private readonly IPricesData _pricesdata;
        private readonly ICostCentersData _costCenterData;
        private readonly IRequestsData _requestData;

        public DPsController(ICountriesData countriesData,
                             ICitiesData citiesData,
                             IRequestTypesData requestTypesData,
                             ISuppliersData suppliersData,
                             ITransportersData transporterData,
                             IPricesData priceData,
                             ICostCentersData costCenterData,
                             IRequestsData requestData)
        {
            _countriesData = countriesData;
            _citiesData = citiesData;
            _requestTypesData = requestTypesData;
            _suppliersData = suppliersData;
            _transportersData = transporterData;
            _pricesdata = priceData;
            _costCenterData = costCenterData;
            _requestData = requestData;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> FillSelectRequestTypes()
        {
            var allRequestTypes = await _requestTypesData.GetAllRequestTypes();

            return Json(allRequestTypes);
        }

        public async Task<JsonResult> FillSelectHome()
        {
            var justHome = await _suppliersData.GetJustHomeSupplier();

            return Json(justHome);
        }

        public async Task<JsonResult> FillSelectSupplier()
        {
            var allSuppliers = await _suppliersData.GetSuppliersWithoutHome();

            return Json(allSuppliers);
        }

        public async Task<JsonResult> FiilCountries()
        {
            var allCountries = await _countriesData.GetAllCountries();

            return Json(allCountries);
        }

        public async Task<JsonResult> FiilCities(int Id_Country)
        {
            var allCities = await _citiesData.GetAllCitiesOfACountry(Id_Country);

            return Json(allCities);
        }

        public async Task<JsonResult> FillInputLocation(int Id_Supplier)
        {
            var specificSupplier = await _suppliersData.GetSupplierById(Id_Supplier);

            return Json(specificSupplier);
        }

        public async Task<JsonResult> FillTransporters()
        {
            var allTransporters = await _transportersData.GetAllTransporters();

            return Json(allTransporters);
        }

        public async Task<JsonResult> FillTransportTypes()
        {
            var allTransportTypes = await _transportersData.GetAllTransportTypes();

            return Json(allTransportTypes);
        }
        public async Task<JsonResult> FillMaterials()
        {
            var allMaterials = await _transportersData.GetAllMaterials();

            return Json(allMaterials);
        }
        public async Task<JsonResult> FillPriceCountyandCityHome()
        {
            var CountryAndCityHome = await _pricesdata.GetCountryAndCityHome();

            return Json(CountryAndCityHome);
        }

        public async Task<JsonResult> FillCostCenters()
        {
            var allCostCenters = await _costCenterData.GetAllCostCenters();

            return Json(allCostCenters);
        }

        public async Task<JsonResult> Calculate(string requestType, string from, string to, string etd, string eta, string nrPallets, string weight)
        {
            int id_requestType = 0, id_from = 0, id_to = 0, numberPallets = 0, weightKg = 0;
            Int32.TryParse(requestType, out id_requestType);
            Int32.TryParse(from, out id_from);
            Int32.TryParse(to, out id_to);
            Int32.TryParse(nrPallets, out numberPallets);
            Int32.TryParse(weight, out weightKg);
            int PremiumFreight = 0;
            decimal totalPrice = 0, palletPrice = 0;

            string Message = "No price was registered for this route. You will receive an estimated price after logistic team will process your request.";

            SuppliersModel sm1 = await _suppliersData.GetSupplierByIdWithIds(id_from);
            SuppliersModel sm2 = await _suppliersData.GetSupplierByIdWithIds(id_to);

            PricesModel price = await _pricesdata.GetPriceByIdStandardModel(sm1.Id_City, sm2.Id_City);
         
            if (price != null)
            {
                if (numberPallets <= 64)
                {
                    var pricePallet = CalculatePricePerPallet(numberPallets, price);
                    decimal pricePerPallet = Convert.ToDecimal(pricePallet.Result);
                    double transitTime = ((double)price.TransitTimeGroupage / (double)24);
                   // transitTime = transitTime.toFixed(2);

                    decimal priceCalculated = pricePerPallet * numberPallets;
                    totalPrice = priceCalculated;
                    palletPrice = pricePerPallet;
                    DateTime dt_etd = DateTime.Parse(etd, System.Globalization.CultureInfo.InvariantCulture);
                    DateTime dt_eta = DateTime.Parse(eta, System.Globalization.CultureInfo.InvariantCulture);
                   // TimeSpan ts = dt_eta.Subtract(dt_etd);
                    var span = dt_eta.Subtract(dt_etd);
                    double daysSelected = span.Days;

                    if (daysSelected > 0)
                    {
                        if (transitTime >= daysSelected)
                        {
                            Message = $"For this route, your transit time is NOT standard and price can't be calculated. " +
                                $"This request will be mark as PREMIUM FREIGHT !";
                            PremiumFreight = 2;
                        }
                        else if (transitTime < daysSelected)
                        {
                            Message = $"For this route, the standard time for transport is {transitTime.ToString("0.00")} days and ~ price = {priceCalculated.ToString("0.00")} (€)";
                            PremiumFreight = 1;
                        }
                    }
                    else
                    {
                        Message = $"";
                    }
                }
            }
            else
            {
                PremiumFreight = 2;
            }
            var result = new { Message = Message, PremiumFreight = PremiumFreight, totalPrice = totalPrice, palletPrice = palletPrice };
            return Json(result);
        }

        public async Task<JsonResult> CalculateProcessor(string Id_Request)
        {
            int Id = 0;
            Int32.TryParse(Id_Request, out Id);
       
            int PremiumFreight = 0;
            decimal totalPrice = 0, palletPrice = 0;

            string Message = "No price was registered for this route in database.";

            NewRequestEditCalculationModel newObj = await _requestData.GetRequestByIdToEditProcessorForCalculation(Id);

            SuppliersModel sm1 = await _suppliersData.GetSupplierByIdWithIds(newObj.IdFrom);
            SuppliersModel sm2 = await _suppliersData.GetSupplierByIdWithIds(newObj.IdTo);

            PricesModel price = await _pricesdata.GetPriceByIdStandardModel(sm1.Id_City, sm2.Id_City);

            if (price != null)
            {
                if (newObj.PalletNr <= 64)
                {
                    var pricePallet = CalculatePricePerPallet(newObj.PalletNr, price);
                    decimal pricePerPallet = Convert.ToDecimal(pricePallet.Result);
                    double transitTime = ((double)price.TransitTimeGroupage / (double)24);

                    decimal priceCalculated = pricePerPallet * newObj.PalletNr;
                    totalPrice = priceCalculated;
                    palletPrice = pricePerPallet;
                    DateTime dt_etd = DateTime.Parse(newObj.ETD.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                    DateTime dt_eta = DateTime.Parse(newObj.ETA.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                  
                    var span = dt_eta.Subtract(dt_etd);
                    double daysSelected = span.Days;

                    if (daysSelected > 0)
                    {
                        if (transitTime >= daysSelected)
                        {
                            Message = $"For this route, your transit time is NOT standard and price can't be calculated. " +
                                $"This request need to be mark as PREMIUM FREIGHT !";
                            PremiumFreight = 2;
                        }
                        else if (transitTime < daysSelected)
                        {
                            Message = $"Price was updated from database for selected route.";
                            PremiumFreight = 1;
                        }
                    }
                    else
                    {
                        Message = $"";
                    }
                }
            }
            else
            {
                PremiumFreight = 2;
            }
            var result = new { Message = Message, PremiumFreight = PremiumFreight, totalPrice = totalPrice, palletPrice = palletPrice };
            return Json(result);
        }


        public async Task<decimal> CalculatePricePerPallet(int nrPallets, PricesModel price)
        {
            decimal pricePallet = 0;

            if(nrPallets >= 1 && nrPallets <=4)
            {
                pricePallet = price.From1To4Pallets;
            }
            else if (nrPallets >= 5 && nrPallets <= 8)
            {
                pricePallet = price.From5To8Pallets;
            }
            else if (nrPallets >= 9 && nrPallets <= 12)
            {
                pricePallet = price.From9To12Pallets;
            }
            else if (nrPallets >= 13 && nrPallets <= 16)
            {
                pricePallet = price.From13To16Pallets;
            }
            else if (nrPallets >= 17 && nrPallets <= 20)
            {
                pricePallet = price.From17To20Pallets;
            }
            else if (nrPallets >= 21 && nrPallets <= 24)
            {
                pricePallet = price.From21To24Pallets;
            }
            else if (nrPallets >= 25 && nrPallets <= 28)
            {
                pricePallet = price.From25To28Pallets;
            }
            else if (nrPallets >= 29 && nrPallets <= 32)
            {
                pricePallet = price.From29To32Pallets;
            }
            else if (nrPallets >= 33 && nrPallets <= 36)
            {
                pricePallet = price.From33To36Pallets;
            }
            else if (nrPallets >= 37 && nrPallets <= 40)
            {
                pricePallet = price.From37To40Pallets;
            }
            else if (nrPallets >= 41 && nrPallets <= 44)
            {
                pricePallet = price.From41To44Pallets;
            }
            else if (nrPallets >= 45 && nrPallets <= 48)
            {
                pricePallet = price.From45To48Pallets;
            }
            else if (nrPallets >= 49 && nrPallets <= 52)
            {
                pricePallet = price.From49To52Pallets;
            }
            else if (nrPallets >= 53 && nrPallets <= 56)
            {
                pricePallet = price.From53To56Pallets;
            }
            else if (nrPallets >= 57 && nrPallets <= 60)
            {
                pricePallet = price.From57To60Pallets;
            }
            else if (nrPallets >= 61 && nrPallets <= 64)
            {
                pricePallet = price.From61To64Pallets;
            }

            return pricePallet;
        }
    }
}
