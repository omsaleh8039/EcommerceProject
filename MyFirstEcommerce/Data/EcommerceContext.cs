using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyFirstEcommerce.Models;

namespace MyFirstEcommerce.Data
{
    public class EcommerceContext:IdentityDbContext<ApplicationUser>
    {
        public EcommerceContext(DbContextOptions<EcommerceContext>options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Contact> contacts { get; set; }    
        public DbSet<ShoppingCart> shoppingCarts { get; set; }

    }

}
