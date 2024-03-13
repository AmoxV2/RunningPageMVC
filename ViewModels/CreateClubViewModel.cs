using Learning_MVC.Data.Enum;
using Learning_MVC.Models;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Learning_MVC.ViewModels
{
    public class CreateClubViewModel
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
 
        public Address Address { get; set; }
        public IFormFile Image { get; set; }
        public ClubCategory ClubCategory { get; set; }

    }
}
