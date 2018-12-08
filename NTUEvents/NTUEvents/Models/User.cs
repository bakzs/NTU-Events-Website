using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTUEvents.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int UserProfileId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
