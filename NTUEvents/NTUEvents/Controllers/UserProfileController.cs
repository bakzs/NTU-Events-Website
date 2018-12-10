using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NTUEvents.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NTUEvents.Controllers
{
    [Route("api/[controller]")]
    public class UserProfileController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View($"This is a userprofilecontroller");
        }

        [HttpGet("{id}")]
        public IActionResult GetUserProfile(int userProfileId)
        {
            //Return user profile

            //Return a view object
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult CreateUserProfile([FromBody] UserProfile UserProfileItem)
        {
            //Create user profile

            //Return a view object
            return RedirectToAction("Index");
        }
        [HttpPut]
        public IActionResult UpdateUserProfile(int userProfileId)
        {
            //Update user profile

            //Return a view object
            return RedirectToAction("Index");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUserProfile(int userProfileId)
        {
            //Delete user profile

            //Return a view object
            return RedirectToAction("Index");
        }
    }
}
