using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTUEvents.Models
{
    public class EventParticipation
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool? IsDeleted { get; set; }
        [ForeignKey("EventId")]
        public Event Event { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
