using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcRegistrations.Models;




namespace mvcRegistrations.Controllers
{

    [Authorize (Roles = "Admin")]
    public class PageController : Controller
    {

        private readonly registrationsDbContext _dbContext;
        private readonly CloudinaryHelper cloudinaryHelper;


        public PageController(registrationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }


 
        public PageController(CloudinaryHelper cloudinaryHelper)
        {
            this.cloudinaryHelper = cloudinaryHelper;
        }

    
        // to show us the create page 

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Upload(InternApplicationViewModel application)
        {
            if (ModelState.IsValid)
            {
                
                if (application.Resume != null && application.Resume.Length > 0)
                {
               
                  
                    var uploadResult = cloudinaryHelper.UploadImage(application.Resume);

                    if (uploadResult != null)
                    {
                        
                        var intern = new Intern
                        {
                            Name = application.Name,
                            Email = application.Email,
                            Phone = application.Phone,
                            Address = application.Address,
                            ResumeUrl = uploadResult.Url.ToString()
                        };

                        _dbContext.Interns.Add(intern);
                        _dbContext.SaveChanges();

                        return RedirectToAction("List");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error uploading resume.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please upload a valid resume.");
                }
            }

            return View(application);
        }



        [HttpGet]
        public IActionResult List()
        {
            List<Intern> interns = _dbContext.Interns.ToList(); // Fetch all interns from the database
            return View(interns); // Pass the list of interns to the view
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var intern = _dbContext.Interns.Find(id);

            if (intern == null)
            {
                return NotFound();
            }

            return View(intern);
        }


        [HttpPost]
        public IActionResult Edit(Intern updatedIntern)
        {
            if (ModelState.IsValid)
            {
                var existingIntern = _dbContext.Interns.Find(updatedIntern.Id);

                if (existingIntern == null)
                {
                    return NotFound();
                }

                existingIntern.Name = updatedIntern.Name;
                existingIntern.Email = updatedIntern.Email;
                existingIntern.Phone = updatedIntern.Phone;
                existingIntern.Address = updatedIntern.Address;


                _dbContext.SaveChanges();

                return RedirectToAction("List");
            }

            return View(updatedIntern);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var intern = _dbContext.Interns.Find(id);

            if (intern == null)
            {
                return NotFound(); // Return a 404 error if the intern is not found
            }

            return View(intern);
        }


        [HttpPost]
        public IActionResult Deleted(int id)
        {
            var intern = _dbContext.Interns.Find(id);

            if (intern == null)
            {
                return NotFound();
            }

            _dbContext.Interns.Remove(intern);
            _dbContext.SaveChanges();

            return RedirectToAction("List");
        }

    }
}
