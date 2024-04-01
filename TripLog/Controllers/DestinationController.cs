using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripLog.Models;

namespace TripLog.Controllers
{
    public class DestinationController : Controller
    {

        private TripLogContext context { get; set; }
        public DestinationController(TripLogContext ctx) => context = ctx;


        public async Task<IActionResult> Manage()
        {
            var viewModel = new ManageDestinationsViewModel
            {
                Destinations = await context.Destinations.ToListAsync()
            };
            return View("~/Views/Manage/Destination.cshtml", viewModel);
        }



        [HttpPost]
        public async Task<IActionResult> AddDestination(ManageDestinationsViewModel destination)
        {
            if (ModelState.IsValid)
            {
                context.Destinations.Add(destination.NewDestination);
                await context.SaveChangesAsync();
                return RedirectToAction("Manage");
            }
            return View("~/Views/Manage/Destination.cshtml", destination);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            var destination = await context.Destinations.FindAsync(id);
            if (destination != null)
            {
                context.Destinations.Remove(destination);
                await context.SaveChangesAsync();
            }
            return RedirectToAction("Manage");
        }
    }
}
