using courseapp.Models;
using courseapp.ViewMobel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace courseapp.services
{

    interface ICategoryservice
    {
        List<Category> Readall();
        int create(Category model);

        Category readbyid( int id);
        int update(Category model);
    }
    public class Categoryservice : ICategoryservice

    {
        private coursedatabaseContext _context { get; set; }

        public Categoryservice()
        {
            _context = new coursedatabaseContext();
        }

       

        public List<Category> Readall()
        {
          return _context.Category.ToList();
                
               
        }

        public int create(Category model)
        {

            var categorynameexists = _context.Category.Where(e => e.Name.ToLower() == model.Name.ToLower()).Any();

            if (categorynameexists)
            {
                return -2;
            }


            _context.Category.Add(model);

            return _context.SaveChanges();


        }

        public Category readbyid(int id)
        {
          return  _context.Category.Find(id);


                }

        public int update(Category updatedcategory)
        {


            var categorynameexists = _context.Category.Where(e => e.Name.ToLower() != updatedcategory.Name.ToLower());

            if (categorynameexists.Where(e => e.Name.ToLower() == updatedcategory.Name.ToLower()).Any())
            {
                return -2;
            }

            _context.Category.Update(updatedcategory);
            return _context.SaveChanges();  
         
        }
    }
}
