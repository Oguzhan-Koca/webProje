using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebProje.Models.Entities
{

    [Table("Kategori")]
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }
        [Required, StringLength(50, ErrorMessage = "En fazla 50 karakter olabilir!")]
        public string KategoriAd { get; set; }
        [Required, StringLength(100, ErrorMessage = "En fazla 100 karakter olabilir!")]
        public string Aciklama { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}