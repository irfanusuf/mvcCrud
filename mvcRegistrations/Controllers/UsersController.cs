using Microsoft.AspNetCore.Mvc;    //import dependencies
using Microsoft.EntityFrameworkCore;
using mvcRegistrations.Models;

namespace mvcRegistrations.Controllers    // file path
{
    public class UsersController : Controller   //inheritance
    {


        private readonly registrationsDbContext _dbContext;

        public UsersController(registrationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }




        [HttpGet]

        public IActionResult SignUp()
        {
            return View();
        }


      

        

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult userLogin()
        {
            return View();
        }

    }
}
