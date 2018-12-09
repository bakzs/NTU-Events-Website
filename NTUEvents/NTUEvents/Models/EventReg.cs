using System;
using System.Collections.Generic;

namespace NTUEvents.Models
{
    public partial class Eventreg
    {
        public int EventregId { get; set; }
        public int? EventidEventregFk { get; set; }
        public int? UserIdEventregFk { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsDeleted { get; set; }

        public Event EventidEventregFkNavigation { get; set; }
        public User UserIdEventregFkNavigation { get; set; }
    }
}
