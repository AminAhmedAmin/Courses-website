using courseapp.Models;

namespace courseapp.services
{ 
    interface IAdminservice
    {
        bool login(string _Email, string _Password);
        bool ChangePassword(string _Email, string _Password);
        bool ForgetPassword(string Email);
    };
    public class Adminservice : IAdminservice
    {
        private coursedatabaseContext _context { get; set; }

        public Adminservice()
        {
            _context = new coursedatabaseContext();
        }

        public bool login(string _Email, string _Password)
        {
           return _context.Admin.Where(a => a.Emial == _Email && a.Password == _Password).Any();
        }
        public bool ChangePassword(string _Email, string _Password)
        {
            throw new NotImplementedException();
        }

        public bool ForgetPassword(string _Email)
        {
            throw new NotImplementedException();
        }

       
    }
}
