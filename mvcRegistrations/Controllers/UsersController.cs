using Microsoft.AspNetCore.Mvc;
using mvcRegistrations.Models;
using Microsoft.AspNetCore.Identity;
namespace mvcRegistrations
{
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;


        public UsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;

        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }








        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser model)
        {

            var user = new IdentityUser { UserName = model.Username, Email = model.Email };


            var result = await _userManager.CreateAsync(user, model.Password);




            if (result.Succeeded)



            {
                var role = await _userManager.AddToRoleAsync(user, "User");




                if (role.Succeeded)
                {
                    return RedirectToAction("Index", "Home");

                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult LoginUSer()
        {
            return View();
        }
    }
}

