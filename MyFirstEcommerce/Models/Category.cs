using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstEcommerce.Models
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }
        [Required(ErrorMessage ="اسم الصنف مطلوب")]  
        public string? CatName { get; set; }
        public string? CatPhoto { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }

        //public int ProId { get; set; }
        //[ForeignKey("ProId")]
        public virtual ICollection<Product> Products { get; set; }

    }
}
