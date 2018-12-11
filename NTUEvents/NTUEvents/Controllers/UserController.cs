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
    public class UserController : Controller
    {
        private NtuEventsContext NtuEventsContext;

        public UserController(NtuEventsContext DbContext)
        {
            NtuEventsContext = DbContext;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUser(int userId)
        {
            //Return user profile

            //Return a view object
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User UserItem)
        {
            //Create user profile

            //Return a view object
            return RedirectToAction("Index");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateUser(int userId)
        {
            //Update user profile

            //Return a view object
            return RedirectToAction("Index");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser(int userId)
        {
            //Delete user profile

            //Return a view object
            return RedirectToAction("Index");
        }
    }
}
