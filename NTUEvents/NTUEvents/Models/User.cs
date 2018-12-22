using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NTUEvents.Models
{
    public class User
    {
        public User()
        {
            CcaMemberships = new HashSet<CcaMembership>();
            EventParticipations = new HashSet<EventParticipation>();
        }

        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int? ContactNumber { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public ICollection<CcaMembership> CcaMemberships { get; set; }
        public ICollection<EventParticipation> EventParticipations { get; set; }
    }
}
