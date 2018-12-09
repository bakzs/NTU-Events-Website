using System;
using System.Collections.Generic;

namespace NTUEvents.Models
{
    public partial class Ccamembership
    {
        public int CcaMembershipId { get; set; }
        public int? UserIdCcaMemFk { get; set; }
        public int? CcaIdCcaMemFk { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }

        public Cca CcaIdCcaMemFkNavigation { get; set; }
        public User UserIdCcaMemFkNavigation { get; set; }
    }
}
