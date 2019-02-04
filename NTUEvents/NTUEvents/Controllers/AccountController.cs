using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NTUEvents.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace NTUEvents.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Account accountItem)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user =
                await userManager.FindByNameAsync(accountItem.Username);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user,
                    accountItem.Password, false, false)).Succeeded)
                    {
                        return Ok("Login Successful!");
                    }
                }
            }

            return BadRequest("Invalid username or password!");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok("Logout successful!");
        }
    }
}
