using System.ComponentModel.DataAnnotations;

namespace MyFirstEcommerce.ViewModel
{
    public class LoginVM
    {
        [EmailAddress]
        public string? Email { get; set; } 
        public string? Password { get; set; }
    }
}
