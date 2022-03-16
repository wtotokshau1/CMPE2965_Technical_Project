using Microsoft.AspNetCore.Mvc;
using PetActivityTrackerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetActivityTrackerMVC.Controllers
{
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Users user)
        {
            if (user.UserName == "Warren" && user.Password == "Password")
                return View("PetDetails");
            else
                return View();
        }
    }
}
