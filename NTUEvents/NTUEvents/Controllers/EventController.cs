using System;
using System.Data.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NTUEvents.Models;

namespace NTUEvents.Controllers
{
    /*
        Method   Functions              Routing 
     1. [Get]    GetAllEvents         - api/events 
     2. [Get]    GetUserEvents        - api/events/{id}
     3. [Post]   CreateNewEvent       - api/events/create/{userId}
     4. [Put]    UpdateNewEvent       - api/events/update/{eventId}
     5. [Put]    DeleteEvent          - api/events/delete/{eventId}
     6. [Put]    DeleteAllUserEvents  - api/events/deleteall/{userId}

     Note
     0. Do not key incorrect userid/eventid. 
     1. When testing on postman, select the correct method
     2. For [Put] method, type "Content-type" into Key and "application/json" into Value
     3. Generate the Json string according to the Object values
     4. Insert Json string into Description. */   

    //Launch IIS at Class path
    //Go to Properties in your solution explorer -> launchSettings.json
    //Edit the "launchUrl"

    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly NtuEventsContext NtuEventsContext_Db;

        public EventController(NtuEventsContext DbContext)
        {
            NtuEventsContext_Db = DbContext;
        }

        [HttpGet("Events")]
        public JsonResult GetAllEvents()
        {
            //Get all non-deleted events
            var AllEvents = (from e in NtuEventsContext_Db.Events
                                select e)
                                .ToList();
            return Json(AllEvents);

            /*var alleventList = NtuEventsContext_Db.Events.Where(t => t.IsDeleted == false).ToList();
            return JsonConvert.SerializeObject(alleventList, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });*/
        }

        [HttpGet("{userId}")]
        public JsonResult GetAllUserEvents(int userId)
        {
            //Get user list
            //Filter by user and show all events by him
            var AllUserEventParticipations = (from e in NtuEventsContext_Db.EventParticipations
                                where e.UserId == userId
                                select e)
                                .ToList();
            
            //TODO: var AllUserEvents = NtuEventsContext_Db.Query()
                                    .Include();

            return Json(AllUserEventParticipations);

            /*var usereventRegList = (NtuEventsContext_Db.EventParticipations.Where(t => t.UserIdEventregFk == userId)).ToList();
            var usereventInfo = NtuEventsContext_Db.Events.Where(t => usereventRegList.FirstOrDefault(p => t.EventId == p.EventidEventregFk) != null).ToList();
            return JsonConvert.SerializeObject(usereventInfo, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });*/
        }

        [HttpPost("create/{userId}")]
        public IActionResult CreateEvent([FromBody] Event eventItem, int userId)
        {
            NtuEventsContext_Db.Events.Add(eventItem);
            NtuEventsContext_Db.SaveChanges();

            return Ok("Successfully created a new event!");

            /*int currentEventCount = NtuEventsContext_Db.Events.Count();
            EventParticipation eventParticipationItem = new EventParticipation()
            {
                EventidEventregFk = currentEventCount,
                UserIdEventregFk = userId,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };
            NtuEventsContext_Db.EventParticipations.Add(eventParticipationItem);
            NtuEventsContext_Db.SaveChanges();*/
        }

        [HttpPut("update")]
        public IActionResult UpdateEvent([FromBody] Event eventItem)
        {
            NtuEventsContext_Db.Events.Update(eventItem);
            NtuEventsContext_Db.SaveChanges();

            return Ok("Successfully updated event!");
            
            /*Event eventItem = NtuEventsContext_Db.Events.Single(x => x.EventId == eventId);
            eventItem.CcaidEventFk = eventInfo.CcaidEventFk;
            eventItem.Name = eventInfo.Name;
            eventItem.Type = eventInfo.Type;
            eventItem.Venue = eventInfo.Venue;
            eventItem.Description = eventInfo.Description;
            eventItem.StartDate = eventInfo.StartDate;
            eventItem.EndDate = eventInfo.EndDate;
            eventItem.Quota = eventInfo.Quota;
            eventItem.UpdatedDate = DateTime.Now;
            eventItem.UpdatedBy = eventInfo.UpdatedBy;
            NtuEventsContext_Db.SaveChanges();
            return "Success";*/
        }

        [HttpPut("delete/{eventId}")]
        public IActionResult DeleteEvent(int eventId)
        {
            var EventItem = NtuEventsContext_Db.Events.Find(eventId);
            EventItem.IsDeleted = true;
            NtuEventsContext_Db.SaveChanges();

            return Ok("Successfully deleted event!");

            /*var eventItem = NtuEventsContext_Db.Events.Single(t => t.EventId == eventId);
            eventItem.IsDeleted = true;
            NtuEventsContext_Db.SaveChanges();*/
        }

        /*[HttpPut("deleteall/{userId}")]
        public IActionResult DeleteAllUserEvents(int userId)
        {
            
            NtuEventsContext_Db.SaveChanges();
            return Ok("Successfully deleted all user events!");

            /*var usereventRegList = (NtuEventsContext_Db.EventParticipations.Where(t => t.UserIdEventregFk == userId)).ToList();
            var usereventInfo = NtuEventsContext_Db.Events.Where(t => usereventRegList.FirstOrDefault(p => t.EventId == p.EventidEventregFk) != null).ToList();
            foreach (var userEvents in usereventInfo)
            {
                userEvents.IsDeleted = true;
            }
        }*/
    }
}
