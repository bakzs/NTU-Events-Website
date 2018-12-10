using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NTUEvents.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View($"This is a userprofilecontroller");
        }

        [HttpGet("{id}")]
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
        [HttpPut]
        public IActionResult UpdateUser(int userId)
        {
            //Update user profile

            //Return a view object
            return RedirectToAction("Index");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int userId)
        {
            //Delete user profile

            //Return a view object
            return RedirectToAction("Index");
        }
    }
