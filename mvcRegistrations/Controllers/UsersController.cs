﻿using Microsoft.AspNetCore.Mvc;
using mvcRegistrations.Models;
using Microsoft.AspNetCore.Identity;
namespace mvcRegistrations
{
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UsersController(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser>signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
                    return RedirectToAction("Login");

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
        public async Task<IActionResult> Login(LoginUser model)
        {
            var login = await _signInManager.PasswordSignInAsync(model.Username,
                model.Password, false, false);


            if (login!= null &&  login.Succeeded)
            {
                return RedirectToAction("index", "home");

            }
            return View();
        }
    }
}

