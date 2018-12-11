using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NTUEvents.Models;

namespace NTUEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly NtuEventsContext ntueventsContext_db;
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<UserProfile>> Get()
        {
            //Sample of how it works
            var userprofile = ntueventsContext_db.Userprofile.ToList();
            return userprofile;
        }


        public ValuesController(NtuEventsContext context)
        {
            ntueventsContext_db = context;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
