using HPEL_Assessment.Data;
using HPEL_Assessment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HPEL_Assessment.Controllers
{
    public class OwnersController : Controller
    {
        private readonly DataContext _context;

        public OwnersController(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<Owners>>> Index()
        {
            return View(await _context.Owners.ToListAsync());
        }

        public IActionResult Create()
        {
            //var dogVm = new DogViewModel();
            return View();
        }

        public async Task<ActionResult> CreateOwner(Owners owner)
        {
            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); // runs the method
        }

        public async Task<ActionResult> UpdateOwner(Owners owner)
        {
            //_context.Add(owner);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index)); // runs the method
            var dbOwner = await _context.Owners.FindAsync(owner.Id);
            if (dbOwner == null)
                return RedirectToAction(nameof(Index));
                //return BadRequest("Hero not found");

            dbOwner.FirstName = owner.FirstName;
            dbOwner.LastName = owner.LastName;
            dbOwner.DriverLicense = owner.DriverLicense;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
