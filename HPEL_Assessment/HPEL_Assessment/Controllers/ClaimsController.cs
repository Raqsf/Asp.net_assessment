using HPEL_Assessment.Data;
using HPEL_Assessment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HPEL_Assessment.Controllers
{
    public class ClaimsController : Controller
    {

        private readonly DataContext _context;
        public ClaimsController(DataContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<List<Claims>>> Index()
        {
            return View(await _context.Claims.ToListAsync());
        }

        public IActionResult Create()
        {
            //var dogVm = new DogViewModel();
            return View();
        }

        public async Task<ActionResult> CreateClaim(Claims claim)
        {
            var dbVehicle = await _context.Vehicles.FindAsync(claim.VehicleId);
            if (dbVehicle == null)
                return RedirectToAction(nameof(Index));

            _context.Claims.Add(claim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); // runs the method
        }

        public async Task<ActionResult> UpdateClaim(Claims claim)
        {
            //_context.Add(owner);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index)); // runs the method
            var dbClaim = await _context.Claims.FindAsync(claim.Id);
            if (dbClaim == null)
                return RedirectToAction(nameof(Index));
            //return BadRequest("Hero not found");

            var dbVehicle = await _context.Vehicles.FindAsync(claim.VehicleId);
            if (dbVehicle == null)
                return RedirectToAction(nameof(Index));

            dbClaim.Description = claim.Description;
            dbClaim.Status = claim.Status;
            dbClaim.Date = claim.Date;
            dbClaim.VehicleId = claim.VehicleId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
