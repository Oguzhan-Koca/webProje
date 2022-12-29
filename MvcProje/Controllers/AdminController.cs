using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcProje.Models.Entity;
using MvcProje.Repositories;

namespace MvcProje.Controllers
{
    public class AdminController : Controller
    {
        GenericRepository<Animal> repository = new GenericRepository<Animal>();
        //[Authorize]
        public IActionResult Index()
        {
            var animals = repository.List();
            return View(animals);
        }
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
