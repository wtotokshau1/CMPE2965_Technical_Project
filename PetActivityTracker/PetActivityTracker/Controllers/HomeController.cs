using Microsoft.AspNetCore.Mvc;
using PetActivityTracker.Models;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetActivityTracker.Data;
using PetActivityTracker.Models;

namespace PetActivityTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly PetActivityTrackerContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, PetActivityTrackerContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            var myUser = await _context.Users.FirstOrDefaultAsync(x => x.UserName == user.UserName && x.Password == user.Password);
            var model =  _context.Pet;

            if (myUser != null)
            {
                TempData["UserID"] = myUser.UserId;
                return RedirectToAction("Index", "Pets");
            }
            else
            {
                ViewBag.Message = "Invalid Credentials!";
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}