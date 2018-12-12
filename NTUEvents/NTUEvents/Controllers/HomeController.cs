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
        //Go to startup.cs and insert maproute Eg: "routes.MapRoute("default", "{controller=Home}/{action=EventPage}");"
        //controller --> this page (home)
        //action --> this function (eventPage)
        //Insert more map route functions here

        public IActionResult EventPage()
        {
            return View("Event");
        }
    }
}