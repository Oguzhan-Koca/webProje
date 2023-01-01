using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcProje.Models.Entity
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }
        [Required]
        [DisplayName("Hakkımızda Açıklama")]
        public string AboutDetail { get; set; } 
        public string AboutImage { get; set; }

         

    }
}
