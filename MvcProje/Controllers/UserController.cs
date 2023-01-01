using Microsoft.AspNetCore.Mvc;
using MvcProje.Data;
using MvcProje.Models.Entity;
using MvcProje.Repositories;
using NuGet.Protocol.Core.Types;
using NuGet.Protocol.Plugins;

namespace MvcProje.Controllers
{
    public class UserController : Controller
    {
        Context db = new Context();
        GenericRepository<User> repository= new GenericRepository<User>();  


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
            bool adminVarMi = false;
            string password = "";
            foreach (var userr in repository.List())
            {
                if (userr.UserMail == user.UserMail)
                {
                    adminVarMi = true;
                    password = userr.Password;
                    break;
                }
            }
            if (adminVarMi)
            {
                if (user.Password == password)
                {
                    HttpContext.Session.SetInt32("Id", user.UserID);
                    HttpContext.Session.SetString("Email", user.UserMail);

                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Uyari = "sifre hatali";
                return View(user);
            }
            else
            {
                ViewBag.Uyari = "Kullanici adi veya sifre Yanlış";
                return View(user);
            }
        }

        [HttpGet]
        public IActionResult AnimalAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AnimalAdd(Animal animal)
        {
            
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
            
           // repository.TDelete(animal);
            return RedirectToAction("Index");
        }



    }
}