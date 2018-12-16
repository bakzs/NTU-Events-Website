using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NTUEvents.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomePage()
        {
            return Ok("Home Page is successfully loaded!");
        }
        
        /*public IActionResult EventPage()
        {
            return View("Event");
        }
        public IActionResult UserProfilePage()
        {
            return View("UserProfile");
        }*/
    }
}