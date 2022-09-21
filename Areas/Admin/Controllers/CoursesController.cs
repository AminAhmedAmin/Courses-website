using courseapp.ViewMobel;
using Microsoft.AspNetCore.Mvc;

namespace courseapp.Areas.Admin.Controllers
{
    public class CoursesController : Controller
    {
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
