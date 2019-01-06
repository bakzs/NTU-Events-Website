using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTUEvents.Models
{
    public class Event
    {
        public Event()
        {
            EventParticipations = new HashSet<EventParticipation>();
        }

        [Key]
        public int EventId { get; set; }
        [ForeignKey("Cca")]
        public int CcaId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Venue { get; set; }
        public int? Quota { get; set; }
        public string Contact { get; set; }
        public string Website { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool? IsDeleted { get; set; }

        public Cca Cca { get; set; }
        public ICollection<EventParticipation> EventParticipations { get; set; }
    }
}
