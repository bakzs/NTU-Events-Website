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
    public class CcaController : Controller
    {
        private readonly NtuEventsContext ntuEventsContext_Db;

        public CcaController(NtuEventsContext ntuEventsContext)
        {
            ntuEventsContext_Db = ntuEventsContext;
        }

        //GET: api/Cca
        [HttpGet]
        public ActionResult<IEnumerable<Cca>> GetAllCcas()
        {
            return Json(from cca in ntuEventsContext_Db.Ccas
                        where cca.IsDeleted.Equals(false)
                        select cca);
        }

        //GET: api/Cca/1
        [HttpGet("{CcaId}")]
        public ActionResult<Cca> GetCca(int CcaId)
        {
            var ccaItem = from cca in ntuEventsContext_Db.Ccas
                          where cca.CcaId == CcaId
                          && cca.IsDeleted.Equals(false)
                          select cca;

            if (!ccaItem.Any())
            {
                return NotFound();
            }

            return Json(ccaItem);
        }

        //GET: api/Cca/User/1
        [HttpGet("User/{userId}")]
        public ActionResult<IEnumerable<Cca>> GetAllUserCcas(int userId)
        {
            return Json(GetAllUserCcasHelper(userId));
        }

        //POST: api/Cca
        //Generate CreatedBy and CreatedDate at client
        [HttpPost]
        public ActionResult<Cca> CreateCca([FromBody] Cca ccaItem)
        {
            ntuEventsContext_Db.Ccas.Add(ccaItem);
            ntuEventsContext_Db.SaveChanges();

            return CreatedAtAction("GetCca", new { ccaItem.CcaId }, ccaItem);
        }

        //PUT: api/Cca/1
        //Generate UpdatedBy and UpdatedDate in client
        [HttpPut("{ccaId}")]
        public ActionResult UpdateEvent(int ccaId, [FromBody] Cca ccaItem)
        {
            if (ccaId != ccaItem.CcaId)
            {
                return BadRequest();
            }

            ntuEventsContext_Db.Entry(ccaItem).State = EntityState.Modified;
            ntuEventsContext_Db.SaveChanges();

            return NoContent();
        }

        //SOFT DELETE
        //PUT: api/Cca/delete/1
        //Generate DeletedBy in client
        [HttpPut("delete/{ccaId}")]
        public ActionResult<Cca> DeleteCca(int ccaId)
        {
            var ccaItem = ntuEventsContext_Db.Ccas.Find(ccaId);

            if (ccaItem == null)
            {
                return NotFound();
            }

            ccaItem.DeletedDate = DateTime.Today;
            ccaItem.IsDeleted = true;
            ntuEventsContext_Db.SaveChanges();

            return ccaItem;
        }

        //Helper method
        public IEnumerable<Cca> GetAllUserCcasHelper(int userId)
        {
            return (from cca in ntuEventsContext_Db.Ccas
                    join ccamem in ntuEventsContext_Db.CcaMemberships
                    on cca.CcaId equals ccamem.CcaId
                    where ccamem.UserId == userId
                    && ccamem.IsDeleted.Equals(false)
                    select cca)
                        .ToList();
        }
    }
}
