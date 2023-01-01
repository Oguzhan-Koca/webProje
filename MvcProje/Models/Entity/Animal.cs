using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcProje.Models.Entity
{
    public class Animal
    {
        [Key]
        public int AnimalID { get; set; }
        [Required]
        public int AnimalAge { get; set; }

        public string AnimalImage { get; set; }
        [DisplayName("Hayvan Adı")]
        public string AnimalName { get; set; }
        [DisplayName("Ürün Açıklama")]
        public string AnimalDescription { get; set; }
       

        public int UserID { get; set; }
      
        public int CategoryID { get; set; }
        public User? User { get; set; }
        public Category Category { get; set; }

        
    }
}
