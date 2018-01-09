using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;
using ToDoList.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Tests
{
	[TestClass]
	public class ItemControllerTests
	{
		[TestMethod]
		public void ItemsController_AddsItemToIndexModelData_Collection()
		{
			// Arrange
			ItemsController controller = new ItemsController();
			Item testItem = new Item();
			testItem.Description = "test item";
            testItem.CategoryId = 1;

			// Act
			controller.Create(testItem);
			ViewResult indexView = new ItemsController().Index() as ViewResult;
			var collection = indexView.ViewData.Model as List<Item>;

            foreach(var thing in collection)
            {
                Console.WriteLine("############" + thing.ItemId + thing.Description);
            }

			// Assert
			CollectionAssert.Contains(collection, testItem);
		}
	}
}
