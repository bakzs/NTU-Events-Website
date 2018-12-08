using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTUEvents.Models
{
    public class UserProfile
    {
        public int UserProfileId { get; set; }
        public string Name { get; set; }
        public int Contact { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Boolean isDeleted { get; set; }
    }
}
