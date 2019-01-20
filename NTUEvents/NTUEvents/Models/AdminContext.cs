using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NTUEvents.Models
{
    public class AdminContext : IdentityDbContext<IdentityUser>
    {
        public AdminContext(DbContextOptions<AdminContext> options) : base(options)
        {
        }
    }
}
