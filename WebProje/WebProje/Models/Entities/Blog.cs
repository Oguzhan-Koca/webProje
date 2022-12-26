using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProje.Models.Entities
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        [StringLength(50)]
        public string Baslik { get; set; }
        [StringLength(100)]
        public string Icerik { get; set; }
        public string ResimURL { get; set; }
        public int? KategoriId { get; set; }
        public Kategori Kategori { get; set; }
        public ICollection<Yorum> Yorums { get; set; }
    }
}