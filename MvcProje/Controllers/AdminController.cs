using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MvcProje.Data;
using MvcProje.Models.Entity;
using MvcProje.Repositories;

namespace MvcProje.Controllers
{
    public class AdminController : Controller
    {
        GenericRepository<Animal> repository = new GenericRepository<Animal>();
        GenericRepository<Admin> rps= new GenericRepository<Admin>();  
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

        //admin giriş doğrulama
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            bool adminVarMi = false;
            string password = "";
            foreach(var admn in rps.List())
            {
                if (admin.Email == admn.Email)
                {
                    adminVarMi = true;
                    password = admn.Password;
                    break;
                }
            }
            if(adminVarMi)
            {
                if (admin.Password == password)
                {
                    HttpContext.Session.SetInt32("Id", admin.Id);
                    HttpContext.Session.SetString("Email", admin.Email);

                    return RedirectToAction("Index", "Admin");
                }
                ViewBag.Uyari = "sifre hatali";
                return View(admin);
            }
            else
            {
                ViewBag.Uyari = "Kullanici adi veya sifre Yanlış";
                return View(admin);
            }
            
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("Id");
            HttpContext.Session.Remove("Email");
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Admin");
        
        }


        [HttpGet]
        public IActionResult AnimalAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AnimalAdd(Animal p)
        {
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
     
        public ActionResult AnimalUpdate(int id)
        {
            //var a =db.Animals.Where(x=>x.AnimalID==id).FirstOrDefault();

            Animal a =repository.Find(x=>x.AnimalID==id);
           /* a.AnimalName = "oguz";
            repository.TUpdate(a);

            int s = 4;*/
            return View(a);

        }
        [HttpPost]
        public ActionResult AnimalUpdate(Animal animal)
           {
           // int iad = animal.AnimalID;
           // animal.AnimalName = "hikm";
            var updatedAnimal=repository.TGet(animal.AnimalID);
            updatedAnimal.AnimalName=animal.AnimalDescription;
            updatedAnimal.AnimalAge= animal.AnimalAge;
            repository.TUpdate(updatedAnimal);
            //int a=animal.AnimalID;
            // var a = db.Animals.Where(x => x.AnimalID == id).FirstOrDefault();

            /*animal.AnimalAge = id;
            animal.AnimalDescription = id.ToString();*/




            //db.Animals.Add(animal);


           // db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
