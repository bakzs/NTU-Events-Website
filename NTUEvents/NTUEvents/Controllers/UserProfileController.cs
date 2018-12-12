using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NTUEvents.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NTUEvents.Controllers
{
    /* 
        Method   Functions              Routing 
     1. [Get]    GetUserProfile         - api/userprofile/{userProfileId}
     3. [Post]   CreateUserProfile      - api/userprofile/create/
     4. [Put]    UpdateUserProfile      - api/userprofile/update/{userProfileId}
     5. [Delete] DeleteUserProfile      - api/userprofile/delete/{userProfileId}

     *Note
     0. Do not key incorrect userProfileId. 
     1. When testing on postman, select the correct method
     2. For [Put] method, type "Content-type" into Key and "application/json" into Value
     3. Generate the Json string according to the Object values
     4. Insert Json string into Description.

    */

    [Route("api/[controller]")]
    public class UserProfileController : Controller
    {
        private readonly NtuEventsContext NtuEventsContext;

        public UserProfileController(NtuEventsContext DbContext)
        {
            NtuEventsContext = DbContext;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUserProfile(int userProfileId)
        {
            var userProfile = NtuEventsContext.UserProfile.Find(userProfileId);
            var userProfileJson = JsonConvert.SerializeObject(userProfile);
            return Json(userProfileJson);
        }

        [HttpPost("create")]
        public IActionResult CreateUserProfile([FromBody] UserProfile UserProfileItem)
        {
            NtuEventsContext.UserProfile.Add(UserProfileItem);
            NtuEventsContext.SaveChanges();
            return Ok("You have successfully created your user profile!");
        }

        [HttpPut("update/{id:int}")]
        public IActionResult UpdateUserProfile([FromBody] UserProfile UserProfileItem, int userProfileId)
        {
            var userProfile = NtuEventsContext.UserProfile.Find(userProfileId);
            userProfile.Name = UserProfileItem.Name;
            userProfile.ContactNumber = UserProfileItem.ContactNumber;
            userProfile.Email = UserProfileItem.Email;
            NtuEventsContext.SaveChanges();
            return Ok("You have successfully updated your user profile!");
        }

        [HttpDelete("delete/{id:int}")]
        public IActionResult DeleteUserProfile(int userProfileId)
        {
            var userProfile = NtuEventsContext.UserProfile.Find(userProfileId);
            userProfile.IsDeleted = true;
            NtuEventsContext.SaveChanges();
            return Ok("You have successfully deleted your user profile!");
        }
    }
}
