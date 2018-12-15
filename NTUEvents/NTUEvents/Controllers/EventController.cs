using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NTUEvents.Models;

/*namespace NTUEvents.Controllers
{
    /* 
        Method   Functions              Routing 
     1. [Get]    GetAllEvents         - api/events 
     2. [Get]    GetUserEvents        - api/events/{id}
     3. [Post]   CreateNewEvent       - api/events/create/{userId}
     4. [Put]    UpdateNewEvent       - api/events/update/{eventId}
     5. [Put]    DeleteEvent          - api/events/delete/{eventId}
     6. [Put]    DeleteAllUserEvents  - api/events/deleteall/{userId}

     *Note
     0. Do not key incorrect userid/eventid. 
     1. When testing on postman, select the correct method
     2. For [Put] method, type "Content-type" into Key and "application/json" into Value
     3. Generate the Json string according to the Object values
     4. Insert Json string into Description.

    

    //Launch IIS at Class path
    //Go to Properties in your solution explorer -> launchSettings.json
    //Edit the "launchUrl"

    //Default route: api/events
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly NtuEventsContext NtuEventsContext_Db;

        public EventController(NtuEventsContext context)
        {
            NtuEventsContext_Db = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public string GetAllEvents()
        {
            //Show all non-deleted events
            var alleventList = NtuEventsContext_Db.Events.Where(t => t.IsDeleted == false).ToList();
            return JsonConvert.SerializeObject(alleventList, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
        }

        [HttpGet]
        [Route("{userId}")]
        [AllowAnonymous]
        public string GetUserEvents(int userId)
        {
            //Get user list
            //Filter by user and show all events by him
            var usereventRegList = (NtuEventsContext_Db.EventParticipations.Where(t => t.UserIdEventregFk == userId)).ToList();
            var usereventInfo = NtuEventsContext_Db.Events.Where(t => usereventRegList.FirstOrDefault(p => t.EventId == p.EventidEventregFk) != null).ToList();
            return JsonConvert.SerializeObject(usereventInfo, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
        }

        [HttpPost]
        [Route("create/{userId}")]
        [AllowAnonymous]
        public string CreateNewEvent([FromBody] Event eventInfo, int userId)
        {
            //Add event first
            NtuEventsContext_Db.Events.Add(eventInfo);
            NtuEventsContext_Db.SaveChanges();

            //Get last count in db = event id
            //Add event reg and save to db.
            int count = NtuEventsContext_Db.Events.Count();
            EventParticipation eventregInfo = new EventParticipation()
            {
                EventidEventregFk = count,
                UserIdEventregFk = userId,
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };
            NtuEventsContext_Db.EventParticipations.Add(eventregInfo);
            NtuEventsContext_Db.SaveChanges();
            return "Success";
        }

        [HttpPut]
        [Route("update/{eventId}")]
        [AllowAnonymous]
        public string UpdateNewEvent([FromBody] Event eventInfo, int eventId)
        {
            //Get event
            //Update event
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

        [HttpPut]
        [Route("delete/{eventId}")]
        [AllowAnonymous]
        public string DeleteEvent(int eventId)
        {
            //Update isDeleted field - Soft delete
            var eventItem = NtuEventsContext_Db.Events.Single(t => t.EventId == eventId);
            eventItem.IsDeleted = true;
            NtuEventsContext_Db.SaveChanges();
            return "Success";
        }

        [HttpPut]
        [Route("deleteall/{userId}")]
        [AllowAnonymous]
        public string DeleteAllUserEvents(int userId)
        {
            //Get all events by the user & update isDeleted field - Soft delete
            var usereventRegList = (NtuEventsContext_Db.EventParticipations.Where(t => t.UserIdEventregFk == userId)).ToList();
            var usereventInfo = NtuEventsContext_Db.Events.Where(t => usereventRegList.FirstOrDefault(p => t.EventId == p.EventidEventregFk) != null).ToList();
            foreach (var userEvents in usereventInfo)
            {
                userEvents.IsDeleted = true;
            }
            NtuEventsContext_Db.SaveChanges();
            return "Success";
        }
    }
}*/
