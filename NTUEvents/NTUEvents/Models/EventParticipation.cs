using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NTUEvents.Models
{
    public class EventParticipation
    {
        [Key]
        public int EventParticipationId { get; set; }
        public int? EventidEventregFk { get; set; }
        public int? UserIdEventregFk { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsDeleted { get; set; }

        public Event EventidEventregFkNavigation { get; set; }
        public User UserIdEventregFkNavigation { get; set; }
    }
}
