using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NTUEvents.Models;

namespace NTUEvents.Controllers
{
    /* 
        Method   Function          Routing 
     1. [Get]    GetUser         - api/users/{userId}
     2. [Post]   CreateUser      - api/users
     3. [Put]    UpdateUser      - api/users/{userId}
     4. [Put]    DeleteUser      - api/users/{userId}/delete
     */

    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly NtuEventsContext ntuEventsContext_Db;

        public UserController(NtuEventsContext ntuEventsContext)
        {
            ntuEventsContext_Db = ntuEventsContext;
        }

        //GET: api/users/{userId}
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

        //POST: api/users
        //TODO: Generate CreateDate property at client
        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User userItem)
        {
            ntuEventsContext_Db.Users.Add(userItem);
            ntuEventsContext_Db.SaveChanges();

            return CreatedAtAction("GetUser", new { userItem.UserId }, userItem);
        }

        //PUT: api/users/{userId}
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
        //PUT: api/users/{userId}/delete
        [HttpPut("{userId}/delete")]
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
