using System;
using System.Collections.Generic;

namespace NTUEvents.Models
{
    public class UserProfile
    {
        public UserProfile()
        {
            Users = new HashSet<User>();
        }

        public int UserProfileId { get; set; }
        public string Name { get; set; }
        public int? ContactNumber { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
