using courseapp.services;
using courseapp.ViewMobel;
using Microsoft.AspNetCore.Mvc;

namespace courseapp.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        [Area("Admin")]
        public IActionResult LogIn()
        {
            return View();
        }


        [HttpPost("LogIn")]
        [Area("Admin")]
        public IActionResult LogIn(loginviewmodel logininfo)

            
        {

            var adminservice = new Adminservice();

            var islogin = adminservice.login(logininfo.Emial, logininfo.Password);
            
            if (islogin)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                
                logininfo.Massage = "Email or password is incorrect";
                return View(logininfo); 
            }

          
        }
    }
}
