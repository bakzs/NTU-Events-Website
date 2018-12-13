using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NTUEvents.Controllers
{
    public class HomeController : Controller
    {
        //Routing
        //Function - Front-end navbar routing && initial routing at Startup.cs
        public IActionResult MainPage()
        {
            return View("Index");
        }
        
        public IActionResult EventPage()
        {
            return View("Event");
        }

        public IActionResult UserProfilePage()
        {
            return View("UserProfile");
        }
    }
}