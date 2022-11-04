using HPEL_Assessment.Data;
using HPEL_Assessment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HPEL_Assessment.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly DataContext _context;

        public VehiclesController(DataContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<List<Vehicles>>> Index()
        {
            return View(await _context.Vehicles.ToListAsync());
        }

        public IActionResult Create()
        {
            //var dogVm = new DogViewModel();
            return View();
        }

        public async Task<ActionResult> CreateVehicle(Vehicles vehicle)
        {
            var dbOwner = await _context.Vehicles.FindAsync(vehicle.OwnerId);
            if (dbOwner == null)
                return RedirectToAction(nameof(Index));

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); // runs the method
        }

        public async Task<ActionResult> UpdateOwner(Vehicles vehicle)
        {
            //_context.Add(owner);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index)); // runs the method
            var dbVehicle = await _context.Vehicles.FindAsync(vehicle.Id);
            if (dbVehicle == null)
                return RedirectToAction(nameof(Index));
            //return BadRequest("Hero not found");

            var dbOwner = await _context.Owners.FindAsync(vehicle.OwnerId);
            if (dbOwner == null)
                return RedirectToAction(nameof(Index));

            dbVehicle.Brand = vehicle.Brand;
            dbVehicle.Vin = vehicle.Vin;
            dbVehicle.Color = vehicle.Color;
            dbVehicle.Year = vehicle.Year;
            dbVehicle.OwnerId = vehicle.OwnerId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
