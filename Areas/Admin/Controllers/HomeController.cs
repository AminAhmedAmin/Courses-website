using Microsoft.AspNetCore.Mvc;

namespace courseapp.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        //[Route("Admin/[Controller]/[Action]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
