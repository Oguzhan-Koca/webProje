using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebProje.Models.Entities
{
    [Table("Hakkimizda")]
    public class Hakkimizda
    {
        [Key]
        public int HakkimizdaId { get; set; }
        [Required]
        [DisplayName("Hakkımızda Açıklama")]
        public string Aciklama { get; set; }

    }
}