using System.ComponentModel.DataAnnotations;

namespace MvcProje.Models.Entity
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required, StringLength(50, ErrorMessage = "En fazla 50 karakter olabilir!")]
        public string CategoryName { get; set; }
        

        public List<Animal> Animals { get; set; }

    }
}
