using Microsoft.AspNetCore.Mvc;
using mvc_app2.Models;
using System.Diagnostics;

namespace mvc_app2.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }




    }
}