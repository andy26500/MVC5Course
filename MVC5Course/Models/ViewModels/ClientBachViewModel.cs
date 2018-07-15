using System.ComponentModel.DataAnnotations;

namespace MVC5Course.Models.ViewModels
{
    public class ClientBachViewModel
    {
        public int ClientId { get; set; }
       
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        
        [Required]
        public string LastName { get; set; }
    }
}