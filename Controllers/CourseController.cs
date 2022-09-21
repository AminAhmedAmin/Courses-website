using courseapp.Models;
using courseapp.ViewMobel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace courseapp.Controllers
{
    public class CourseController : Controller
    {
        private readonly coursedatabaseContext _context;

        public CourseController(coursedatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {


            var model = new List<CourseModelView>
            {
                new CourseModelView
                {
                    Id =1,
                    Name = "amin",
                    Descriptoin="fff",
                    CreationDate = DateTime.Now,    

                },
                 new CourseModelView
                {
                    Id =2,
                    Name = "dddc",
                    Descriptoin="ccccc",
                    CreationDate = DateTime.Now,

                }

            };

            return View(model);
          
        }
    }
}
