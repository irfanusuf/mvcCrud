using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvcRegistrations.Models;
using System.Diagnostics;

namespace mvcRegistrations.Controllers
{


    
    public class HomeController : Controller
    {
        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }



        [Authorize]
        [HttpGet]
        public IActionResult SecureIndex()
        {
            return View();
        }


        
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

    
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

    }
}