#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetActivityTracker.Data;
using PetActivityTracker.Models;

namespace PetActivityTracker.Controllers
{
    public class PetsController : Controller
    {
        private readonly PetActivityTrackerContext _context;

        public PetsController(PetActivityTrackerContext context)
        {
            _context = context;
        }

        // GET: Pets
        public async Task<IActionResult> Index(int? id)
        {
            if (id != null)
            {
                return View(await _context.Pet.Where(x => x.UserId == id).ToListAsync());
            }
            else return RedirectToAction("Index", "Home");
            
        }

        // GET: Pets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet
                .FirstOrDefaultAsync(m => m.PetId == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // GET: Pets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PetId,UserId,PetName,FoodConsumption,WaterConsumption")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                //int? i = (int)HttpContext.Session.GetInt32("UserId");
                pet.UserId = (int)HttpContext.Session.GetInt32("UserId");
                _context.Add(pet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Pets", new { id = (int)HttpContext.Session.GetInt32("UserId") });
        }

        // GET: Pets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            return View(pet);
        }

        public async Task<IActionResult> Manage()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            var model = _context.Pet.Where(Pet => Pet.UserId == userId);
            return View("Manage", model);
            
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PetId,UserId,PetName,FoodConsumption,WaterConsumption")] Pet pet)
        {
            pet.UserId = (int)HttpContext.Session.GetInt32("UserId");
            if (id != pet.PetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetExists(pet.PetId))
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
            return View(pet);
        }

        // GET: Pets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pet
                .FirstOrDefaultAsync(m => m.PetId == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            foreach(var petActivity in _context.PetActivity.Where(pa=>pa.PetId == id))
            {
                _context.PetActivity.Remove(petActivity);
            }

            await _context.SaveChangesAsync();
            var pet = await _context.Pet.FindAsync(id);
            _context.Pet.Remove(pet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetExists(int id)
        {
            return _context.Pet.Any(e => e.PetId == id);
        }
    }
}
