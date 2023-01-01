using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcProje.Models.Entity
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [DisplayName("kullanıcı Adı")]
        public string UserName { get; set; }

        [Required, StringLength(50, ErrorMessage = "En fazla 50 karakter olabilir!")]
        public string Password { get; set; }
        [DisplayName("kullanıcı SoyAdı")]
        [Required, StringLength(50, ErrorMessage = "En fazla 50 karakter olabilir!")]
        public string UserSurname { get; set; }

        public string UserImage { get; set; }

        public string UserAbout { get; set; }
        [DataType(DataType.EmailAddress)]
        public string UserMail { get; set; }
        [Required, StringLength(50, ErrorMessage = "En fazla 50 karakter olabilir!")]
        public string UserPassword { get; set; }

        public bool UserStatus { get; set; }

        public List<Animal> Animals { get; set; }
    }
}
