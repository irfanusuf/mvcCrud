using Microsoft.AspNetCore.Mvc;

namespace mvc_app2.Controllers
{
    public class PageController : Controller
    {
      


        public IActionResult CreateIntern()
        {
            return View();
        }
    }
}
