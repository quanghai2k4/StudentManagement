using System.Collections.Generic;
using Domain;

namespace DataAccess
{
    public class DataStore
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Category> Categories { get; set; } = new List<Category>();

        public DataStore()
        {
            SeedData();
        }

        private void SeedData()
        {
            var cat1 = new Category { Id = 1, CategoryName = "Programming", Description = "IT Books" };
            var cat2 = new Category { Id = 2, CategoryName = "Fiction", Description = "Novel and Stories" };
            
            Categories.Add(cat1);
            Categories.Add(cat2);

            Books.Add(new Book { Id = 1, Title = "Clean Code", Author = "Uncle Bob", Price = 45.5m, Category = cat1 });
            Books.Add(new Book { Id = 2, Title = "The Hobbit", Author = "J.R.R. Tolkien", Price = 25.0m, Category = cat2 });
        }
    }
}
