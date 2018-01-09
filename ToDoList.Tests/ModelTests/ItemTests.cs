using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;

namespace ToDoList.Tests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void GetDescription_ReturnsItemDescription_String()
        {
            //Arrange
            var item = new Item();
            item.Description = "Wash the dog";

            //Act
            var result = item.Description;

            //Assert
            Assert.AreEqual("Wash the dog", result);
        }
    }
}
