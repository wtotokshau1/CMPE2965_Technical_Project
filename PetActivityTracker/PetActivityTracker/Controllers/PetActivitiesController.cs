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
            var activities = _context.PetActivity.Where(pa => pa.PetId == id);
            return View(await activities.ToListAsync());
        }

        // GET: PetActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petActivity = await _context.PetActivity
                .FirstOrDefaultAsync(m => m.PetActivityID == id);
            if (petActivity == null)
            {
                return NotFound();
            }

            return View(petActivity);
        }

        // GET: PetActivities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PetActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PetActivityID,PetId,Activity,StartTime,EndTime,Consumption")] PetActivity petActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(petActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(petActivity);
        }

        // GET: PetActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petActivity = await _context.PetActivity.FindAsync(id);
            if (petActivity == null)
            {
                return NotFound();
            }
            return View(petActivity);
        }

        // POST: PetActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PetActivityID,PetId,Activity,StartTime,EndTime,Consumption")] PetActivity petActivity)
        {
            if (id != petActivity.PetActivityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetActivityExists(petActivity.PetActivityID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(petActivity);
        }

        // GET: PetActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petActivity = await _context.PetActivity
                .FirstOrDefaultAsync(m => m.PetActivityID == id);
            if (petActivity == null)
            {
                return NotFound();
            }

            return View(petActivity);
        }

        // POST: PetActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var petActivity = await _context.PetActivity.FindAsync(id);
            _context.PetActivity.Remove(petActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetActivityExists(int id)
        {
            return _context.PetActivity.Any(e => e.PetActivityID == id);
        }
    }
}
