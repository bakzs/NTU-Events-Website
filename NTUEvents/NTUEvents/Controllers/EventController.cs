using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
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
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly NtuEventsContext ntuEventsContext_Db;

        public EventController(NtuEventsContext ntuEventsContext)
        {
            ntuEventsContext_Db = ntuEventsContext;
        }

        //GET: api/Event
        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetAllEvents()
        {
            return ntuEventsContext_Db.Events.ToList();
        }

        //GET: api/Event/1
        [HttpGet("{userId}")]
        public ActionResult<Event> GetEvent(int userId)
        {            
            var eventItem = ntuEventsContext_Db.Events.Find(userId);

            if (eventItem == null)
            {
                return NotFound();
            }

             return eventItem;
            
        }

        //GET: api/Event/User/1
        [HttpGet("User/{userId}")]
        public ActionResult<IEnumerable<Event>> GetAllUserEvents(int userId)
        {            
            return (from e in ntuEventsContext_Db.Events
                        join ep in ntuEventsContext_Db.EventParticipations
                        on e.EventId equals ep.EventId
                        where ep.UserId == userId
                        select e)
                        .ToList();
            
        }

        //POST: api/Event
        [HttpPost]
        public ActionResult<Event> CreateEvent([FromBody] Event eventItem)
        {
            ntuEventsContext_Db.Events.Add(eventItem);
            ntuEventsContext_Db.SaveChanges();

            return CreatedAtAction("GetEvent", new { eventItem.EventId }, eventItem);
        }

        /*[HttpPut("update")]
        public IActionResult UpdateEvent([FromBody] Event eventItem)
        {
            ntuEventsContext_Db.Events.Update(eventItem);
            ntuEventsContext_Db.SaveChanges();

            return Ok("Successfully updated event!");
            
            Event eventItem = NtuEventsContext_Db.Events.Single(x => x.EventId == eventId);
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
            return "Success";
        }

        [HttpPut("delete/{eventId}")]
        public IActionResult DeleteEvent(int eventId)
        {
            var EventItem = ntuEventsContext_Db.Events.Find(eventId);
            EventItem.IsDeleted = true;
            ntuEventsContext_Db.SaveChanges();

            return Ok("Successfully deleted event!");

            var eventItem = NtuEventsContext_Db.Events.Single(t => t.EventId == eventId);
            eventItem.IsDeleted = true;
            NtuEventsContext_Db.SaveChanges();
        }

        [HttpPut("deleteall/{userId}")]
        public IActionResult DeleteAllUserEvents(int userId)
        {
            
            NtuEventsContext_Db.SaveChanges();
            return Ok("Successfully deleted all user events!");

            var usereventRegList = (NtuEventsContext_Db.EventParticipations.Where(t => t.UserIdEventregFk == userId)).ToList();
            var usereventInfo = NtuEventsContext_Db.Events.Where(t => usereventRegList.FirstOrDefault(p => t.EventId == p.EventidEventregFk) != null).ToList();
            foreach (var userEvents in usereventInfo)
            {
                userEvents.IsDeleted = true;
            }
        }*/
    }
}
