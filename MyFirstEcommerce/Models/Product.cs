using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstEcommerce.Models
{
    public class Product
    {
        [Key]
        public int ProId { get; set; }
        [Required(ErrorMessage = "اسم المنتج مطلوب")]
        public string? ProName { get; set; }
        [Required(ErrorMessage = "وصف المنتج مطلوب")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "سعر المنتج مطلوب")]   
        public decimal Price { get; set; }
        public string ProImage { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public int CatId { get; set; }
        [ForeignKey("CatId")]
        public virtual Category Category  { get; set; }

    }
}
