using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTUEvents.Models
{
    public class EventReg
    {
        public int EventRegId { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
