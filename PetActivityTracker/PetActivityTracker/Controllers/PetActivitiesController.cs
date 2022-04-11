#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetActivityTracker.Data;

namespace PetActivityTracker.Models
{
    public class PetActivitiesController : Controller
    {
        private readonly PetActivityTrackerContext _context;

        public PetActivitiesController(PetActivityTrackerContext context)
        {
            _context = context;
        }

        // GET: PetActivities
        public async Task<IActionResult> Index(int? id)
        {
            //  Set current time frame to this day on first load
            if (TempData["CurrentDate"] == null)   TempData["CurrentDate"] = DateTime.UtcNow;

            //  Set ViewBad.Pet for View to display more pet information
            ViewBag.Pet = await _context.Pet.FirstOrDefaultAsync(pet => pet.PetId == id);

            //  Ensures Tempdata is kept between requests
            TempData.Keep();
            DateTime currTimeFrame = (DateTime)TempData["CurrentDate"];

            var activities = _context.PetActivity.Where(pa => pa.PetId == id && pa.StartTime.DayOfYear == currTimeFrame.DayOfYear);
            
            return View(await activities.ToListAsync());
        }

        public async Task<IActionResult> IncrementDay(int? id)
        {
            DateTime currTimeFrame = (DateTime)TempData["CurrentDate"];
            TempData["CurrentDate"] = currTimeFrame.AddDays(1);
            TempData.Keep();

            return RedirectToAction("Index", new { id = id });
        }

        public async Task<IActionResult> DecrementDay(int? id)
        {
            DateTime currTimeFrame = (DateTime)TempData["CurrentDate"];
            TempData["CurrentDate"] = currTimeFrame.AddDays(-1);
            TempData.Keep();

            return RedirectToAction("Index", new { id = id });
        }

    }
}
