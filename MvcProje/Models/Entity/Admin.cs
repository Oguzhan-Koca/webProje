using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProje.Models.Entity
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, StringLength(50, ErrorMessage = "En fazla 50 karakter olabilir!")]
        public string Password { get; set; }
        public string Yetki { get; set; }

    }
}
