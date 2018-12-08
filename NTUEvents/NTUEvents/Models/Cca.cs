using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTUEvents.Models
{
    public class Cca
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Schedule { get; set; }
        public string Venue { get; set; }
        public string Contact { get; set; }
        public int UserId { get; set; }
    }
}
