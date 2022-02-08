using IOToolDataLibrary.Data;
using IOToolDataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IOToolWeb.Controllers
{
    [Authorize(Roles = "Level5")]
    public class TransportersController : Controller
    {
        private readonly ITransportersData _transporterData;

        public TransportersController(ITransportersData transporterData)
        {
            _transporterData = transporterData;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var transporters = await _transporterData.GetAllTransporters();
            return View(transporters);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TransportersModel transporter)
        {
            transporter.Active = 1;
            transporter.Alias = "Alias";
            if (ModelState.IsValid)
            {
                await _transporterData.InsertTransporter(transporter);
                return RedirectToAction("Index");
            }
            else
            {
                return View(transporter);
            }

        }

        public async Task<IActionResult> Edit(int id)
        {
            var transporter = await _transporterData.GetTransporterById(id);

            return View(transporter);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TransportersModel transporter)
        {
            transporter.Active = 1;
            transporter.Alias = "Alias";
            if (ModelState.IsValid)
            {
                await _transporterData.UpdateTransporter(transporter);
                return RedirectToAction("Index");
            }
            else
            {
                return View(transporter);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var transporter = await _transporterData.GetTransporterById(id);

            return View(transporter);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TransportersModel transporter)
        {
            await _transporterData.DeleteTransporter(transporter.Id);

            return RedirectToAction("Index");
        }
    }
}
