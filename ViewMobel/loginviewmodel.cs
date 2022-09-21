using System.ComponentModel.DataAnnotations;

namespace courseapp.ViewMobel
{
    public class loginviewmodel
    {

        [EmailAddress]
        [Required]
        public string Emial { get; set; }


        [DataType(DataType.Password)]
        [Required]
       
        public string Password { get; set; }
        public string Massage { get; set; }
    }
}
