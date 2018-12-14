using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NTUEvents.Models
{
    public class UserProfile
    {
        public UserProfile()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int UserProfileId { get; set; }
        [StringLength(45)]
        public string Name { get; set; }
        public int? ContactNumber { get; set; }
        [StringLength(45)]
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
