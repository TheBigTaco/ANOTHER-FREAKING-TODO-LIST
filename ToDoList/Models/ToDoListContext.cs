using System;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class ToDoListContext : DbContext
    {
		public virtual DbSet<Category> Categories { get; set; }
		public DbSet<Item> Items { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder
				.UseMySql(@"Server=localhost;Port=8889;database=todolist;uid=root;pwd=root;");
    }
}
