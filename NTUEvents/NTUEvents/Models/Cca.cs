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
        [StringLength(45)]
        public string CcaType { get; set; }
        [StringLength(1024)]
        public string Description { get; set; }
        [StringLength(45)]
        public string Schedule { get; set; }
        [StringLength(45)]
        public string Venue { get; set; }
        [StringLength(45)]
        public string Contact { get; set; }
        public ICollection<CcaMembership> CcaMemberships { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
