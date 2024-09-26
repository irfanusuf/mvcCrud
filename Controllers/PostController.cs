using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mvcRegistrations.Controllers
{
    public class PostController : Controller
    {


        [Authorize]
        [HttpGet]
        public IActionResult AddPost()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public IActionResult AddPostDb()
        {
            return View();
        }


        [Authorize]
        [HttpGet]
        public IActionResult ViewPost()
        {
            return View();
        }



        [Authorize]
        [HttpGet]
        public IActionResult ViewPostDb()
        {
            return View();
        }
    }
}
