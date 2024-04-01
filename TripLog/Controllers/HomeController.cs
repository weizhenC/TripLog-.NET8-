using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripLog.Models;

namespace TripLog.Controllers
{
    public class HomeController : Controller
    {
        private TripLogContext context { get; set; }
        public HomeController(TripLogContext ctx) => context = ctx;


        public async Task<IActionResult> Index()
        {
            var trips = await context.Trips
                                       .Include(t => t.Destination)
                                     .Include(t => t.Accommodation)
                                        .Include(t => t.TripActivities)
                                     .ThenInclude(t => t.Activity)
                                      .ToListAsync();

            return View(trips);
        }
     

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var trip = await context.Trips.FindAsync(id);
            if (trip != null)
            {
                context.Trips.Remove(trip);
                await context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}