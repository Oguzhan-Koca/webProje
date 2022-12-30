using Microsoft.AspNetCore.Mvc;
using MvcProje.Data;
using MvcProje.Models.Entity;
using NuGet.Protocol.Core.Types;

namespace MvcProje.Controllers
{
    public class UserController : Controller
    {
        Context db = new Context();


        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var login = db.Users.Where(x => x.UserMail == user.UserMail).SingleOrDefault();
            if (login.UserMail == user.UserMail && login.Password == user.Password)
            {

                HttpContext.Session.SetInt32("UserId", login.UserID);
                HttpContext.Session.SetString("UserEmail", login.UserMail);
                return RedirectToAction("Index", "User");
            }
            ViewBag.Uyari = "Kullanici adi veya sifre hatalidir";
            return View(user);
        }

        [HttpGet]
        public IActionResult AnimalAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AnimalAdd(Animal animal)
        {
            animal.AnimalStatus = true;
            animal.UserID = 15;
          //  repositllory.TAdd(animal);
            return RedirectToAction("Index"); //admin controller daki index metoduna gönderme yani yukarı
        }

        [HttpPost]
        public IActionResult AnimalUpdate(int animalId)
        {
            var update = db.Animals.Where(x => x.AnimalID == animalId).SingleOrDefault();
            if (update.AnimalID == animalId)
            {
                return View(update);
            }
            ViewBag.Uyari = "aradiginiz id'e sahip bir hayvan bulunamadi";
            return View();
        }

        [HttpPost]
        public ActionResult RemoveAnimal(Animal animal)
        {
            animal.AnimalStatus = false;
           // repository.TDelete(animal);
            return RedirectToAction("Index");
        }



    }
}