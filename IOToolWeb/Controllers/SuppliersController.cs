using IOToolDataLibrary.Data;
using IOToolDataLibrary.Models;
using IOToolDataLibrary.Models.CustomTables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IOToolWeb.Controllers
{
    [Authorize(Roles = "Level5")]
    public class SuppliersController : Controller
    {
        private readonly ISuppliersData _supplierData;

        public SuppliersController(ISuppliersData supplierData)
        {
            _supplierData = supplierData;
        }

        public async Task<IActionResult> Index()
        {
            var suppliers = await _supplierData.GetAllSuppliers();
            return View(suppliers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SuppliersModel supplier)
        {
            supplier.Active = 1;
            supplier.Home = 0;
            if (ModelState.IsValid)
            {
                await _supplierData.InsertSupplier(supplier);
                return RedirectToAction("Index");
            }
            else
            {
                return View(supplier);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var supplier = await _supplierData.GetSupplierByIdWithIds(id);

            return View(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SuppliersModel supplier)
        {
            supplier.Active = 1;
            supplier.Home = 0;
            if (ModelState.IsValid)
            {
                await _supplierData.UpdateSupplier(supplier);
                return RedirectToAction("Index");
            }
            else
            {
                return View(supplier);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var supplier = await _supplierData.GetSupplierById(id);

            return View(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(NewSupplierModel supplier)
        {
            await _supplierData.DeleteSupplier(supplier.Id);

            return RedirectToAction("Index");
        }
    }
}
