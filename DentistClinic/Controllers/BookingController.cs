using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DentistClinic.Controllers
{
    [Authorize(Roles = "Patient")]
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reserve()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reserves()
        {
            return View();
        }
    }
}
