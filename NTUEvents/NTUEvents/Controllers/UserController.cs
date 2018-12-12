using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NTUEvents.Models;

namespace NTUEvents.Controllers
{
    /* 
        Method   Functions              Routing 
     1. [Get]    GetUser         - api/user/{userId}
     3. [Post]   CreateUser      - api/user/create/
     4. [Put]    UpdateUser      - api/user/update/{userId}
     5. [Delete] DeleteUser      - api/user/delete/{userId}

     *Note
     0. Do not key incorrect userId. 
     1. When testing on postman, select the correct method
     2. For [Put] method, type "Content-type" into Key and "application/json" into Value
     3. Generate the Json string according to the Object values
     4. Insert Json string into Description.

    */

    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly NtuEventsContext NtuEventsContext;

        public UserController(NtuEventsContext DbContext)
        {
            NtuEventsContext = DbContext;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUser(int userId)
        {
            var user = NtuEventsContext.User.Find(userId);
            var userProfileJson = JsonConvert.SerializeObject(user);
            return Json(userProfileJson);
        }

        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] User UserItem)
        {
            NtuEventsContext.User.Add(UserItem);
            NtuEventsContext.SaveChanges();
            return Ok("You have successfully created your account!");
        }

        [HttpPut("update/{id:int}")]
        public IActionResult UpdateUser([FromBody] User UserItem, int userId)
        {
            var user = NtuEventsContext.User.Find(userId);
            user.Username = UserItem.Username;
            user.Password = UserItem.Password;
            user.Cca = UserItem.Cca;
            user.CcaMembership = UserItem.CcaMembership;
            user.Events = UserItem.Events;
            return Ok("You have successfully updated your account!");
        }

        [HttpDelete("delete/{id:int}")]
        public IActionResult DeleteUser(int userId)
        {
            var user = NtuEventsContext.User.Find(userId);
            user.IsDeleted = true;
            NtuEventsContext.SaveChanges();
            return Ok("You have successfully deleted your account!");
        }
    }
}
