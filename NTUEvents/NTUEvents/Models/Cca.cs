using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NTUEvents.Models
{
    public class Cca
    {
        public Cca()
        {
            CcaMemberships = new HashSet<CcaMembership>();
            Events = new HashSet<Event>();
        }

        [Key]
        public int CcaId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Schedule { get; set; }
        public string Venue { get; set; }
        public string Contact { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public ICollection<CcaMembership> CcaMemberships { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
