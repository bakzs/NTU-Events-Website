using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NTUEvents.Models
{
    public class Event
    {
        public Event()
        {
            Eventreg = new HashSet<EventParticipation>();
        }

        [Key]
        public int EventId { get; set; }
        public int? CcaidEventFk { get; set; }
        [StringLength(45)]
        public string Title { get; set; }
        [StringLength(45)]
        public string Type { get; set; }
        [StringLength(45)]
        public string Venue { get; set; }
        [StringLength(1024)]
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
        public ICollection<EventParticipation> Eventreg { get; set; }
    }
}
