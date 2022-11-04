using HPEL_Assessment.Data;
using HPEL_Assessment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HPEL_Assessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetEntity(EntityChoosen value)
        {
            if(value.Entity == "Owners")
            {
                return RedirectToAction(nameof(OwnersController.Index));
            } else if(value.Entity == "Vehicles")
            {
                return RedirectToAction(nameof(VehiclesController.Index));
            } else
            {
                return RedirectToAction(nameof(ClaimsController.Index));
            }
            // return View("Index"); -> Only runs the html
            //dogs.Add(dogViewModel);
            //return RedirectToAction(nameof(Index)); // runs the method
        }
    }
}