using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebProje.Models.Entities
{
    [Table("Iletisim")]
    public class Iletisim
    {
        [Key]
        public int IletisimId { get; set; }
        [StringLength(250, ErrorMessage = "En fazla 250 karakter olabilir!")]
        public string Adres { get; set; }
        // [StringLength(250, ErrorMessage = "En fazla 250 karakter olabilir!")]
        [RegularExpression(@"^(0(\d{10}))$", ErrorMessage = "Geçersiz Telefon Numarası!")]
        public string Telefon { get; set; }
        public string Fax { get; set; }
        public string Whatsapp { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
    }
}
