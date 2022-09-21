using courseapp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace courseapp.ViewMobel
{

    [NotMapped]
    public class CategoryModelView
    {

      
        public int Id { get; set; }

        [Required(ErrorMessage ="name requred")]
        public string Name { get; set; }

       

        public int? ParentId { get; set; }

        public string? ParentName  { get; set; }

        [NotMapped]
        public IEnumerable<Category> Maincategory { get; set; }
    }
}
