using Microsoft.AspNetCore.Mvc;
using MvcProje.Data;
using MvcProje.Models.Entity;
using MvcProje.Repositories;

namespace MvcProje.Controllers
{
	public class CategoryController : Controller
	{
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
			var hakkinda = db.Categories.Where(x => x.CategoryID == id).SingleOrDefault();

			return View();

		}

        [HttpPost]
		[ValidateAntiForgeryToken]	
        public ActionResult Edit(int id, Category category)
        {

            if (ModelState.IsValid)
            {
                var a = db.Categories.Where(x => x.CategoryID == id).SingleOrDefault();
                a.CategoryName = category.CategoryName;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}
