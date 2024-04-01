using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripLog.Models;

namespace TripLog.Controllers
{
    public class AccommodationController : Controller
    {


        private TripLogContext context { get; set; }
        public AccommodationController(TripLogContext ctx)
        {
            context = ctx;
        }

        //This action is responsible for displaying the accommodation management page.
        //It retrieves a list of accommodations from the database asynchronously
        //nd populates a ManageAccommodationsViewModel object with this data.
        //Then, it returns a view named "Accommodation.cshtml" along with the view model.
        public async Task<IActionResult> Manage()
        {
            var viewModel = new ManageAccommodationsViewModel
            {
                Accommodations = await context.Accommodations.ToListAsync()
            };
            return View("~/Views/Manage/Accommodation.cshtml", viewModel);
        }


        //his action handles the submission of the form for adding a new accommodation.
        //It expects a ManageAccommodationsViewModel object containing the details of the new accommodation. 
        [HttpPost]
        public async Task<IActionResult> AddAccommodation(ManageAccommodationsViewModel accommodationsViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Manage/Accommodation.cshtml", accommodationsViewModel.NewAccommodation);
            }

            context.Accommodations.Add(accommodationsViewModel.NewAccommodation);
            await context.SaveChangesAsync();
            return RedirectToAction("Manage");
        }


        [HttpPost]
        public async Task<IActionResult> DeleteAccommodation(int id)
        {
            var accommodation = await context.Accommodations.FindAsync(id);
            if (accommodation != null)
            {
                context.Accommodations.Remove(accommodation);
                await context.SaveChangesAsync();
            }
            return RedirectToAction("Manage");
        }
    }
}
//Overall, this controller provides functionality for managing accommodations,
//including displaying a list of accommodations, adding new accommodations, and deleting existing accommodations.