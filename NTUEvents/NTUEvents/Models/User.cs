using System;
using System.Collections.Generic;

namespace NTUEvents.Models
{
    public class User
    {
        public User()
        {
            Cca = new HashSet<Cca>();
            CcaMembership = new HashSet<Ccamembership>();
            Events = new HashSet<Eventreg>();
        }

        public int UserId { get; set; }
        public int? UserProfileId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsDeleted { get; set; }

        public Userprofile UserProfile { get; set; }
        public ICollection<Cca> Cca { get; set; }
        public ICollection<Ccamembership> CcaMembership { get; set; }
        public ICollection<Eventreg> Events { get; set; }
    }
}
