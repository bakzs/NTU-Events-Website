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

    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
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
            return Json(from e in ntuEventsContext_Db.Events
                        where e.IsDeleted.Equals(false)
                        select e);
        }

        //GET: api/Event/1
        [HttpGet("{eventId}")]
        public ActionResult<Event> GetEvent(int eventId)
        {
            var eventItem = from e in ntuEventsContext_Db.Events
                            where e.EventId == eventId
                            && e.IsDeleted.Equals(false)
                            select e;

            if (!eventItem.Any())
            {
                return NotFound();
            }

             return Json(eventItem);
        }

        //GET: api/Event/User/1
        [HttpGet("User/{userId}")]
        public ActionResult<IEnumerable<Event>> GetAllUserEvents(int userId)
        {
            return Json(GetAllUserEventsHelper(userId));
        }

        //POST: api/Event
        [HttpPost]
        public ActionResult<Event> CreateEvent([FromBody] Event eventItem)
        {
            ntuEventsContext_Db.Events.Add(eventItem);
            ntuEventsContext_Db.SaveChanges();

            return CreatedAtAction("GetEvent", new { eventItem.EventId }, eventItem);
        }

        //PUT: api/Event/1
        //Generate UpdatedBy and UpdatedDate in client
        [HttpPut("{eventId}")]
        public ActionResult UpdateEvent(int eventId, [FromBody] Event eventItem)
        {
            if (eventId != eventItem.EventId)
            {
                return BadRequest();
            }

            ntuEventsContext_Db.Entry(eventItem).State = EntityState.Modified;
            ntuEventsContext_Db.SaveChanges();

            return NoContent();
        }

        //SOFT DELETE
        //PUT: api/Event/delete/1/1
        [HttpPut("delete/{eventId}/{userId}")]
        public ActionResult<Event> DeleteEvent(int eventId, int userId)
        {
            var eventItem = ntuEventsContext_Db.Events.Find(eventId);

            if (eventItem == null)
            {
                return NotFound();
            }

            eventItem.DeletedBy = userId;
            eventItem.DeletedDate = DateTime.Today;
            eventItem.IsDeleted = true;
            ntuEventsContext_Db.SaveChanges();

            return eventItem;
        }

        //SOFT DELETE
        //PUT: api/Event/deleteall/1
        [HttpPut("deleteall/{userId}")]
        public ActionResult<IEnumerable<Event>> DeleteAllUserEvents(int userId)
        {
            var eventParticipationItems = GetAllUserEventParticipationsHelper(userId);

            if (!eventParticipationItems.Any())
            {
                return NotFound();
            }

            foreach (var eventParticipationItem in eventParticipationItems)
            {
                var eventParticipationLoopItem = ntuEventsContext_Db.EventParticipations.Find(eventParticipationItem.UserId, eventParticipationItem.EventId);
                eventParticipationLoopItem.DeletedBy = userId;
                eventParticipationLoopItem.DeletedDate = DateTime.Today;
                eventParticipationLoopItem.IsDeleted = true;
            }

            ntuEventsContext_Db.SaveChanges();
            return Json(eventParticipationItems);
        }

        //Helper method
        public IEnumerable<Event> GetAllUserEventsHelper(int userId)
        {
            return (from e in ntuEventsContext_Db.Events
                    join ep in ntuEventsContext_Db.EventParticipations
                    on e.EventId equals ep.EventId
                    where ep.UserId == userId
                    && ep.IsDeleted.Equals(false)
                    select e)
                        .ToList();
        }

        //Helper method
        public IEnumerable<EventParticipation> GetAllUserEventParticipationsHelper(int userId)
        {
            return (from ep in ntuEventsContext_Db.EventParticipations
                    where ep.UserId == userId
                    && ep.IsDeleted.Equals(false)
                    select ep)
                        .ToList();
        }
    }
}
