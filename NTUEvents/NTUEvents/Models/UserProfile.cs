using System;
using System.Collections.Generic;

namespace NTUEvents.Models
{
    public partial class Userprofile
    {
        public Userprofile()
        {
            User = new HashSet<User>();
        }

        public int UserProfileId { get; set; }
        public string Name { get; set; }
        public int? Contact { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<User> User { get; set; }
    }
}
