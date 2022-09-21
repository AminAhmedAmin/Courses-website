using courseapp.Models;
using courseapp.services;
using courseapp.ViewMobel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace courseapp.Areas.Admin.Controllers
{
    public class CateguryController : Controller
    {
        private readonly Categoryservice categoryservice;
        private readonly coursedatabaseContext _context;

        public CateguryController()
        {
            categoryservice = new Categoryservice();
            _context = new coursedatabaseContext();
        }
      



        [Area("Admin")]
        public IActionResult Index()
        {
            var category = categoryservice.Readall();

           


            return View(category);
        }



        [Area("Admin")]
        public IActionResult Create()
        {
 
            var categorymodel = new CategoryModelView
            {
                Maincategory = categoryservice.Readall()

           };

            return View(categorymodel);
        }




        [Area("Admin")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(CategoryModelView categoryModelView)
        {


                int result = categoryservice.create(new Category
                {
                    Name = categoryModelView.Name,
                    ParentId=categoryModelView.ParentId,
                    ParentName=categoryModelView.ParentName,
                });



                if (result == -2)
                {

                  

                    ViewBag.Massage = " Name Exists";
  
                  var categorymodel = new CategoryModelView
                 {
                    Maincategory = categoryservice.Readall()

                  };
                    return View(categorymodel);
                }

               


          

            return RedirectToAction("Index");

        }





        [Area("Admin")]
        public IActionResult Edit(int? id)
        {
            if ( id == null || id == 0)
            {
                RedirectToAction("Index");
            }

            var curruntcat = categoryservice.readbyid(id.Value);

            if(curruntcat == null)
            {
                return NotFound("CategoryNotFound");
            }

            var categorymodel = new CategoryModelView
            
            {
               
                Name = curruntcat.Name,
                ParentName = curruntcat.ParentName,
            
             
                Maincategory = categoryservice.Readall(),

            };


           
            return View(categorymodel);

        }



        [Area("Admin")]
        [HttpPost]
        public IActionResult Edit(CategoryModelView categoryModelView)
        {

                var categoy =  _context.Category.Find(categoryModelView.Id);

               categoy.Id= categoryModelView.Id;
                categoy.Name = categoryModelView.Name;
               categoy.ParentName= categoryModelView?.ParentName;
                 
              
              


                var result=   categoryservice.update(categoy);


                if (result == -2)
                {


                   

                    ViewBag.succes = false;
                    ViewBag.Massage = " Name Exists";



                var categorymodel = new CategoryModelView

                {
                    Maincategory = categoryservice.Readall(),
                    ParentName = categoryModelView.ParentName,

                };


                return View(categorymodel);
                }else  if (result > 0)
                {
                    ViewBag.succes = true;
                    ViewBag.Massage = $"Ctegory {categoryModelView.Id} Updated succesfully";

  
                  var categorymodel = new CategoryModelView

                  {
                    Maincategory = categoryservice.Readall(),
                 

                  };
                return View(categorymodel);

            }
                else
                {
  


                ViewBag.succes = false;
                    ViewBag.Massage = $"Ctegory {categoryModelView.Id} fialed to update";
                   
                }

                 


            return View(categoryModelView);
        }




        [Area("Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var category = await _context.Category.FindAsync(id);

            if (category == null)
                return NotFound();

            _context.Category.Remove(category);
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

    }
}
