using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyFirstEcommerce.Models;

namespace MyFirstEcommerce.ViewModel
{
    public class IndexVM
    {
        public List<Category> Categories{ get; set; }
        public List<Product> Products { get; set; }
    }
}
