using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Controllers
{
    public class CategoriesController : Controller
    {
		private ToDoListContext db = new ToDoListContext();
		public IActionResult Index()
		{
			return View(db.Categories.ToList());
		}
		public IActionResult Details(int id)
		{
			var thisItem = db.Categories.FirstOrDefault(category => category.CategoryId == id);
			return View(thisItem);
		}
		public IActionResult Create()
		{
			ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
			return View();
		}
		[HttpPost]
		public IActionResult Create(Category item)
		{
			db.Categories.Add(item);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Edit(int id)
		{
			var thisItem = db.Categories.FirstOrDefault(category => category.CategoryId == id);
			ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
			return View(thisItem);
		}
		[HttpPost]
		public IActionResult Edit(Category category)
		{
			db.Entry(category).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult Delete(int id)
		{
            var thisItem = db.Categories.FirstOrDefault(category => category.CategoryId == id);
			return View(thisItem);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			var thisItem = db.Categories.FirstOrDefault(category => category.CategoryId == id);
			db.Categories.Remove(thisItem);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
    }
}
