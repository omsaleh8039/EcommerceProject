using System.ComponentModel.DataAnnotations;

namespace MyFirstEcommerce.Models
{
    public class Contact
    {
        [Key]
        public int CoId { get; set; }
        [Required(ErrorMessage = "الاسم مطلوب")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="البريد الالكتروني مطلوب")]
        [EmailAddress] //اجباري
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
