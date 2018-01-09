using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Controllers
{
	public class ItemsController : Controller
	{
        private IItemRepository itemRepo;

		public ItemsController(IItemRepository repo = null)
		{
			if (repo == null)
			{
				this.itemRepo = new EFItemRepository();
			}
			else
			{
				this.itemRepo = repo;
			}
		}

		public ViewResult Index()
		{
			return View(itemRepo.Items.ToList());
		}

		public IActionResult Details(int id)
		{
			Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
			return View(thisItem);
		}

		public ViewResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Item item)
		{
			itemRepo.Save(item);   // Updated
								   // Removed db.SaveChanges() call
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int id)
		{
			Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
			return View(thisItem);
		}

		[HttpPost]
		public IActionResult Edit(Item item)
		{
			itemRepo.Edit(item);   // Updated!
								   // Removed db.SaveChanges() call
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
			Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
			return View(thisItem);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
			itemRepo.Remove(thisItem);   // Updated!
										 // Removed db.SaveChanges() call
			return RedirectToAction("Index");
		}
	}
}