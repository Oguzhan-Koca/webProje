using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProje.Entities
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public Guid AdminId { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Eposta { get; set; }
        [Required, StringLength(50, ErrorMessage = "En fazla 50 karakter olabilir!")]
        public string Sifre { get; set; }
        public string Yetki { get; set; }
    }
}