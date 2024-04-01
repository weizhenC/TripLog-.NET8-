using Microsoft.AspNetCore.Mvc;
using TripLog.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TripLog_updated.Controllers
{
    public class ActivityController : Controller
    {
        private readonly TripLogContext context;

        public ActivityController(TripLogContext ctx)
        {
            context = ctx;
        }

        public IActionResult Manage()
        {
            var viewModel = new ManageActivitiesViewModel
            {
                Activities = context.Activities.ToList()
            };

            return View("~/Views/Manage/Activity.cshtml", viewModel);
        }

        [HttpPost]
        public IActionResult AddActivity(ManageActivitiesViewModel manageActivitiesViewModel)
        {
            if (ModelState.IsValid)
            {
                context.Activities.Add(manageActivitiesViewModel.NewActivity);
                context.SaveChanges();
                return RedirectToAction("Manage");
            }

            var viewModel = new ManageActivitiesViewModel
            {
                NewActivity = manageActivitiesViewModel.NewActivity,
                Activities = context.Activities.ToList()
            };

            return View("~/Views/Manage/Activity.cshtml", manageActivitiesViewModel.NewActivity);
        }

        [HttpPost]
        public IActionResult DeleteActivity(int id)
        {
            var activity = context.Activities.Find(id);
            if (activity != null)
            {
                context.Activities.Remove(activity);
                context.SaveChanges();
            }
            return RedirectToAction("Manage");
        }
    }
}
