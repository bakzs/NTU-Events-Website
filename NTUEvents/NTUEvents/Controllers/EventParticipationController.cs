using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NTUEvents.Models;

namespace NTUEvents.Controllers
{
    /*
        Method   Functions                     Routing 
     1. [Get]    GetAllEventParticipations     - api/eventparticipations/{eventId}
     2. [Post]   CreateEventParticipation      - api/eventparticipations/{userId}/{eventId}
     3. [Put]    UpdateEventParticipation      - api/eventparticipations/{userId}/{eventId}
     4. [Put]    DeleteAllEventParticipations  - api/eventparticipations/{eventId}/deleteall
     */

    [Route("api/eventparticipations")]
    [ApiController]
    public class EventParticipationController : Controller
    {
        private readonly NtuEventsContext ntuEventsContext_Db;

        public EventParticipationController(NtuEventsContext ntuEventsContext)
        {
            ntuEventsContext_Db = ntuEventsContext;
        }

        // GET: api/eventparticipations/{eventId}
        [HttpGet("{eventId}")]
        public ActionResult<IEnumerable<User>> GetAllEventParticipations(int eventId)
        {
            return (from u in ntuEventsContext_Db.Users
                    join ep in ntuEventsContext_Db.EventParticipations
                    on u.UserId equals ep.UserId
                    where ep.EventId == eventId
                    && ep.IsDeleted.Equals(false)
                    && u.IsDeleted.Equals(false)
                    select u)
                        .ToList();
        }

        // POST: api/eventparticipations/{userId}/{eventId}
        [HttpPost("{userId}/{eventId}")]
        public ActionResult<EventParticipation> CreateEventParticipation([FromBody] EventParticipation eventParticipationItem)
        {
            ntuEventsContext_Db.EventParticipations.Add(eventParticipationItem);
            ntuEventsContext_Db.SaveChanges();

            return Ok(eventParticipationItem);
        }

        //PUT: api/eventparticipations/{userId}/{eventId}
        //Generate UpdatedBy and UpdatedDate in client
        [HttpPut("{userId}/{eventId}")]
        public ActionResult UpdateEventParticipation(int userId, int eventId, [FromBody] EventParticipation eventParticipationItem)
        {
            if (eventId != eventParticipationItem.EventId || userId != eventParticipationItem.UserId)
            {
                return BadRequest();
            }

            ntuEventsContext_Db.Entry(eventParticipationItem).State = EntityState.Modified;
            ntuEventsContext_Db.SaveChanges();

            return NoContent();
        }

        //SOFT DELETE
        //PUT: api/eventparticipations/{userId}/delete/{eventId}
        [HttpPut("{userId}/delete/{eventId}")]
        public ActionResult<EventParticipation> DeleteEventParticipation(int userId, int eventId)
        {
            var eventParticipationItem = ntuEventsContext_Db.EventParticipations.Find(userId, eventId);

            if (eventParticipationItem == null)
            {
                return NotFound();
            }

            eventParticipationItem.DeletedBy = userId;
            eventParticipationItem.DeletedDate = DateTime.Today;
            eventParticipationItem.IsDeleted = true;
            ntuEventsContext_Db.SaveChanges();

            return eventParticipationItem;
        }

        //SOFT DELETE
        //PUT: api/eventparticipations/{eventId}/deleteall
        [HttpPut("{eventId}/deleteall")]
        public ActionResult<IEnumerable<EventParticipation>> DeleteAllEventParticipations(int eventId)
        {
            var eventParticipationItems = GetAllEventParticipationsHelper(eventId);

            if (!eventParticipationItems.Any())
            {
                return NotFound();
            }

            foreach (var eventParticipationItem in eventParticipationItems)
            {
                var eventParticipationLoopItem = ntuEventsContext_Db.EventParticipations.Find(eventParticipationItem.UserId, eventParticipationItem.EventId);
                //Code for admin
                eventParticipationLoopItem.DeletedBy = 10000;
                eventParticipationLoopItem.DeletedDate = DateTime.Today;
                eventParticipationLoopItem.IsDeleted = true;
            }

            ntuEventsContext_Db.SaveChanges();
            return Json(eventParticipationItems);
        }

        //Helper method
        public IEnumerable<EventParticipation> GetAllEventParticipationsHelper(int eventId)
        {
            return (from u in ntuEventsContext_Db.Users
                    join ep in ntuEventsContext_Db.EventParticipations
                    on u.UserId equals ep.UserId
                    where ep.EventId == eventId
                    && ep.IsDeleted.Equals(false)
                    && u.IsDeleted.Equals(false)
                    select ep)
                        .ToList();
        }
    }
}
