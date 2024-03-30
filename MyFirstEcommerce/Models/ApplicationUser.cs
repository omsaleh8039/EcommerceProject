using Microsoft.AspNetCore.Identity;

namespace MyFirstEcommerce.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
