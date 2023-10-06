using Microsoft.AspNetCore.Mvc;
using mvc_app2.Models; 

namespace mvc_app2.Controllers
{
    public class PageController : Controller
    {
        private readonly ApplicationDbContext _dbContext; 

        public PageController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult CreateIntern()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateIntern(Intern application)
        {
            if (ModelState.IsValid)
            {
                
                _dbContext.Interns.Add(application);
                _dbContext.SaveChanges(); 

                
                return RedirectToAction("Success");
            }
            else
            {
                
                return View(application);
            }
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
