using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    [ApiController]
    public class UserController : Controller
    {
        private readonly NtuEventsContext ntuEventsContext_Db;

        public UserController(NtuEventsContext ntuEventsContext)
        {
            ntuEventsContext_Db = ntuEventsContext;
        }

        //GET: api/User/1
        [HttpGet("{userId}")]
        public ActionResult<User> GetUser(int userId)
        {
            var userItem = from u in ntuEventsContext_Db.Users
                           where u.UserId == userId
                            && u.IsDeleted.Equals(false)
                            select u;

            if (!userItem.Any())
            {
                return NotFound();
            }

            return Json(userItem);
        }

        //POST: api/User
        //TODO: Generate CreateDate property at client
        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User userItem)
        {
            ntuEventsContext_Db.Users.Add(userItem);
            ntuEventsContext_Db.SaveChanges();

            return CreatedAtAction("GetUser", new { userItem.UserId }, userItem);
        }

        //PUT: api/User/1
        [HttpPut("{userId}")]
        public ActionResult UpdateUser(int userId, [FromBody] User userItem)
        {
            if (userId != userItem.UserId)
            {
                return BadRequest();
            }

            ntuEventsContext_Db.Entry(userItem).State = EntityState.Modified;
            ntuEventsContext_Db.SaveChanges();

            return NoContent();
        }

        //SOFT DELETE
        //PUT: api/User/delete/1
        [HttpPut("delete/{userId}")]
        public ActionResult<User> DeleteUser(int userId)
        {
            var userItem = ntuEventsContext_Db.Users.Find(userId);

            if (userItem == null)
            {
                return NotFound();
            }

            userItem.DeletedBy = userId;
            userItem.DeletedDate = DateTime.Today;
            userItem.IsDeleted = true;
            ntuEventsContext_Db.SaveChanges();

            return userItem;
        }
    }
}
