using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NTUEvents.Models;
using Microsoft.AspNetCore.Authorization;

namespace NTUEvents.Controllers
{
     /*
        Method   Functions              Routing 
     1. [Get]    GetAllCcas           - api/ccas
     2. [Get]    GetCca               - api/ccas/{ccaId}
     3. [Get]    GetAllUserCcas       - api/ccas/user/{userId}
     3. [Post]   CreateCca            - api/ccas
     4. [Put]    UpdateCca            - api/ccas/{ccaId}
     5. [Put]    DeleteCca            - api/ccas/delete/{ccaId}
     */

    [Route("api/ccas")]
    [ApiController]
    public class CcaController : Controller
    {
        private readonly NtuEventsContext ntuEventsContext_Db;

        public CcaController(NtuEventsContext ntuEventsContext)
        {
            ntuEventsContext_Db = ntuEventsContext;
        }

        //GET: api/ccas
        [HttpGet]
        public ActionResult<IEnumerable<Cca>> GetAllCcas()
        {
            return Json(from cca in ntuEventsContext_Db.Ccas
                        where cca.IsDeleted.Equals(false)
                        select cca);
        }

        //GET: api/ccas/{ccaId}
        [HttpGet("{ccaId}")]
        public ActionResult<Cca> GetCca(int ccaId)
        {
            var ccaItem = from cca in ntuEventsContext_Db.Ccas
                          where cca.CcaId == ccaId
                          && cca.IsDeleted.Equals(false)
                          select cca;

            if (!ccaItem.Any())
            {
                return NotFound();
            }

            return Json(ccaItem);
        }

        //GET: api/ccas/user/{userId}
        [Authorize]
        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<Cca>> GetAllUserCcas(int userId)
        {
            return Json(GetAllUserCcasHelper(userId));
        }

        //POST: api/ccas
        //Generate CreatedBy and CreatedDate at client
        [Authorize]
        [HttpPost]
        public ActionResult<Cca> CreateCca([FromBody] Cca ccaItem)
        {
            ntuEventsContext_Db.Ccas.Add(ccaItem);
            ntuEventsContext_Db.SaveChanges();

            return CreatedAtAction("GetCca", new { ccaItem.CcaId }, ccaItem);
        }

        //PUT: api/ccas/{ccaId}
        //Generate UpdatedBy and UpdatedDate in client
        [Authorize]
        [HttpPut("{ccaId}")]
        public ActionResult UpdateCca(int ccaId, [FromBody] Cca ccaItem)
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
        //PUT: api/ccas/delete/{ccaId}
        //Generate DeletedBy in client
        [Authorize]
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
