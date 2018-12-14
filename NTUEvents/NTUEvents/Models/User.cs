using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NTUEvents.Models
{
    public class User
    {
        public User()
        {
            Ccas = new HashSet<Cca>();
            CcaMemberships = new HashSet<CcaMembership>();
            Events = new HashSet<EventParticipation>();
        }

        [Key]
        public int UserId { get; set; }
        public int? UserProfileId { get; set; }
        [StringLength(45)]
        public string Username { get; set; }
        [StringLength(128)]
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsDeleted { get; set; }

        public UserProfile UserProfile { get; set; }
        public ICollection<Cca> Ccas { get; set; }
        public ICollection<CcaMembership> CcaMemberships { get; set; }
        public ICollection<EventParticipation> Events { get; set; }
    }
}
