using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace MyFirstEcommerce.Models
{
    public class ShoppingCart
    {
        [Key]
        public int CartId { get; set; }
        public int ProId { get; set; }
        [ForeignKey("ProId")]
        public virtual Product Product { get; set; }
        
        [Range(1,int.MaxValue,ErrorMessage ="يجب الا تقل الكمية عن 1")]
        public int Qty { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUsers { get; set; }   

    }
}
