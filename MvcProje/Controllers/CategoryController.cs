using Microsoft.AspNetCore.Mvc;
using MvcProje.Data;
using MvcProje.Models.Entity;
using MvcProje.Repositories;

namespace MvcProje.Controllers
{
	public class CategoryController : Controller
	{
		GenericRepository<Category> repository = new GenericRepository<Category>();
		Context db = new Context();
		//GenericRepository<Category> repository = new GenericRepository<Category>();
		public IActionResult Index()
		{
			return View(db.Categories.ToList());
			//var categories = repository.List();

			//return View(categories);
		}
		public IActionResult Edit(int id)
		{
			var kategori = repository.Find(x=>x.CategoryID== id);
			int  a = kategori.CategoryID;
			//db.Categories.Where(x => x.CategoryID == id).FirstOrDefault();
			int ss = 5;

			return View(kategori);

		}

        [HttpPost]
		[ValidateAntiForgeryToken]	
        public ActionResult Edit(int id ,Category category,string name)
        {
		
            var a = repository.Find(x => x.CategoryID == category.CategoryID);

            a.CategoryName=category.CategoryName;
			repository.TUpdate(a);
			return RedirectToAction("Index");
            /*foreach (var item in repository.List())
			{
				if(item.CategoryID==id)
				{
					item.CategoryName = "adana";
					db.SaveChanges();
					break;
                }
					
			}

            if (ModelState.IsValid)
            {
                var a = db.Categories.Where(x => x.CategoryID ==category.CategoryID ).FirstOrDefault();
                a.CategoryName = category.CategoryName;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }*/
            return View(category);
        }
    }
}
