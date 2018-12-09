using System;
using System.Collections.Generic;

namespace NTUEvents.Models
{
    public partial class Event
    {
        public Event()
        {
            Eventreg = new HashSet<Eventreg>();
        }

        public int EventId { get; set; }
        public int? CcaidEventFk { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Venue { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Quota { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }

        public Cca CcaidEventFkNavigation { get; set; }
        public ICollection<Eventreg> Eventreg { get; set; }
    }
}
