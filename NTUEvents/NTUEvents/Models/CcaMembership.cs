using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTUEvents.Models
{
    public class CcaMembership
    {
        public int UserId { get; set; }
        public int CcaId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool? IsDeleted { get; set; }
        [ForeignKey("CcaId")]
        public Cca Cca { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
