using Exam.Web.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;

namespace Exam.Web.Controllers
{
    
    public class AuthController : Controller
    {


        public AuthController(IConfiguration configuration,SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            Configuration = configuration;
            SignInManager = signInManager;
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public IConfiguration Configuration { get; }
        public SignInManager<IdentityUser> SignInManager { get; }
        public UserManager<IdentityUser> UserManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await UserManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Email or password is wrong!");
                return View(model);
            }

            var result = await SignInManager.PasswordSignInAsync(user,model.Password,false,false);
            
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Email or password is wrong!");
                return View(model);
            }

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new IdentityUser() { UserName = model.Email, Email = model.Email };

            var result = await UserManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
            await UserManager.AddToRoleAsync(user,"Member");

            return RedirectToAction(nameof(Login));
        }

        public async Task<IActionResult> InitAuth()
        {
            var adminEmail = Configuration.GetSection("AdminCreds").GetValue<string>("Username");
            var adminPass = Configuration.GetSection("AdminCreds").GetValue<string>("Password");

            var adminUser = new IdentityUser() { Email = adminEmail, UserName = adminEmail };

            if (!await RoleManager.RoleExistsAsync("Admin"))
            {
                var adminRole = new IdentityRole("Admin");   
                await RoleManager.CreateAsync(adminRole);
            }
            if (!await RoleManager.RoleExistsAsync("Member"))
            {
                var memberRole = new IdentityRole("Member");   
                await RoleManager.CreateAsync(memberRole);
            }

            var result = await UserManager.CreateAsync(adminUser,adminPass);
            
            await UserManager.AddToRoleAsync(adminUser, "Admin");

            return Ok();
        }

    }
}
