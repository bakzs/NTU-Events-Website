using System;
using System.Collections.Generic;

namespace NTUEvents.Models
{
    public partial class User
    {
        public User()
        {
            Cca = new HashSet<Cca>();
            Ccamembership = new HashSet<Ccamembership>();
            Eventreg = new HashSet<Eventreg>();
        }

        public int UserId { get; set; }
        public int? UserProfileIdUserFk { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsDeleted { get; set; }

        public Userprofile UserProfileIdUserFkNavigation { get; set; }
        public ICollection<Cca> Cca { get; set; }
        public ICollection<Ccamembership> Ccamembership { get; set; }
        public ICollection<Eventreg> Eventreg { get; set; }
    }
}
