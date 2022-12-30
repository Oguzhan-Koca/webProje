using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcProje.Data;
using MvcProje.Models.Entity;
using MvcProje.Repositories;

namespace MvcProje.Controllers
{
    public class AdminController : Controller
    {
        GenericRepository<Animal> repository = new GenericRepository<Animal>();
        Context db = new Context(); 
        //[Authorize]
        public IActionResult Index()
        {
            var animals = repository.List();
            return View(animals);
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
         
        //admin giriş doğrulama
        public ActionResult Login(Admin admin)
        {
            var login = db.Admin.Where(x => x.Email == admin.Email).SingleOrDefault();
            if(login.Email==admin.Email&&login.Password==admin.Password)
            {
               
                HttpContext.Session.SetInt32("Id", login.Id);               
                HttpContext.Session.SetString("Email", login.Email);
              
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.Uyari = "Kullanici adi veya sifre Yanlış";
            return View(admin);
        }
        //public ActionResult Logout()
        //{
        //    HttpContext.Session.Remove("Id");
        //    HttpContext.Session.Remove("Email");
        //    HttpContext.Session.Clear();
        //    return RedirectToAction("Login", "Admin");
          
        //}




        [HttpGet]
        public IActionResult AnimalAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AnimalAdd(Animal p)
        {
            p.AnimalStatus = true;
            p.UserID = 15;
            repository.TAdd(p);
            return RedirectToAction("Index"); //admin controller daki index metoduna gönderme yani yukarı
        }
        public IActionResult AnimalDelete(int id)
        {
            Animal a=repository.Find(x=> x.AnimalID==id);
            repository.TDelete(a);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AnimalUpdate(int id)
        {
            Animal a=repository.Find(x=>x.AnimalID==0); 
            return View(a);

        }

    }
}
