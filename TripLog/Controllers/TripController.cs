using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TripLog.Models;

namespace TripLog.Controllers
{
    public class TripController : Controller
    {
        private TripLogContext context { get; set; }
        public TripController(TripLogContext ctx) => context = ctx;

        public RedirectToActionResult Index() => RedirectToAction("Add", new { id = "page1" });

        //This method prepares the data needed for dropdown lists in the view by populating ViewBag properties
        //with SelectList objects containing destination names, accommodation names, and activity names.
        private void PrepareDropDownLists()
        {
            ViewBag.Destinations = new SelectList(context.Destinations, "DestinationId", "Name");
            ViewBag.Accommodations = new SelectList(context.Accommodations, "AccommodationId", "Name");
            ViewBag.Activities = new SelectList(context.Activities, "ActivityId", "Name");
        }




        [HttpGet]
        public ViewResult Add(string id = "")
        {
            var vm = new TripViewModel();
            PrepareDropDownLists();

            if (id.ToLower() == "page2")
            {
                vm.PageNumber = 2;
                var accommodationId = TempData.Peek("AccommodationId") as int?;
                if (accommodationId.HasValue)
                {
                    vm.Accommodation = context.Accommodations.Find(accommodationId.Value);
                }
                return View("Add2", vm);
            }
            else if (id.ToLower() == "page3")
            {
                vm.PageNumber = 3;
                return View("Add3", vm);
            }
            else
            {
                vm.PageNumber = 1;
                return View("Add1", vm);
            }
        }

        //Add GET Action: 
        [HttpPost]
        public async Task<IActionResult> AddAsync(TripViewModel vm)
        {
            PrepareDropDownLists();

            if (vm.PageNumber == 1)
            {

                if (ModelState.IsValid) // only page 1 has required data
                {
                    var vmJson = System.Text.Json.JsonSerializer.Serialize(vm, new JsonSerializerOptions { WriteIndented = true });
                    Console.WriteLine(vmJson);

                    TempData[nameof(Trip.DestinationId)] = vm.Trip.DestinationId;
                    TempData[nameof(Trip.AccommodationId)] = vm.Trip.AccommodationId;
                    TempData[nameof(Trip.StartDate)] = vm.Trip.StartDate;
                    TempData[nameof(Trip.EndDate)] = vm.Trip.EndDate;
                    TempData.Keep();
                    return RedirectToAction("Add", new { id = "Page2" });
                }
                else
                {

                    var vmJson = System.Text.Json.JsonSerializer.Serialize(vm, new JsonSerializerOptions { WriteIndented = true });
                    Console.WriteLine(vmJson);
                    PrepareDropDownLists();
                    return View("Add1", vm);
                }
            }
            else if (vm.PageNumber == 2)
            {
                TempData.Keep();
                return RedirectToAction("Add", new { id = "Page3" });
            }
            else if (vm.PageNumber == 3)
            {

                Console.WriteLine("TempData keys and values:");
                foreach (var key in TempData.Keys)
                {
                    Console.WriteLine($"{key}: {TempData[key]}");
                }


                var newTrip = new Trip();

                if (TempData["DestinationId"] is int destinationId)
                {
                    newTrip.DestinationId = destinationId;
                }

                if (TempData["AccommodationId"] is int accommodationId)
                {
                    newTrip.AccommodationId = accommodationId;
                }

                if (TempData["StartDate"] is DateTime startDate)
                {
                    newTrip.StartDate = startDate;
                }

                if (TempData["EndDate"] is DateTime endDate)
                {
                    newTrip.EndDate = endDate;
                }
                var vmJson = System.Text.Json.JsonSerializer.Serialize(vm, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine(newTrip);
                context.Trips.Add(newTrip);
                await context.SaveChangesAsync();

                var selectedActivityIds = vm.Trip.ActivityIds;
                foreach (var activityId in selectedActivityIds)
                {
                    var tripActivity = new TripActivity { TripId = newTrip.TripId, ActivityId = activityId };
                    context.TripActivities.Add(tripActivity);
                }


                await context.SaveChangesAsync();
                TempData["message"] = $"Trip added successfully.";

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public RedirectToActionResult Cancel()
        {
            TempData.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}