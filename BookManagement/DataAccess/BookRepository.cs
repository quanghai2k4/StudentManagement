using System.Collections.Generic;
using System.Linq;
using Domain;

namespace DataAccess
{
    public class BookRepository
    {
        private readonly DataStore _dataStore;

        public BookRepository(DataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public List<Book> RetrieveBooks()
        {
            return _dataStore.Books;
        }

        public Book? RetrieveBook(int id)
        {
            return _dataStore.Books.FirstOrDefault(b => b.Id == id);
        }

        public void CreateBook(Book book)
        {
            _dataStore.Books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            var existing = RetrieveBook(book.Id);
            if (existing != null)
            {
                existing.Title = book.Title;
                existing.Author = book.Author;
                existing.Price = book.Price;
                existing.Category = book.Category;
            }
        }

        public void DeleteBook(int id)
        {
            var book = RetrieveBook(id);
            if (book != null)
            {
                _dataStore.Books.Remove(book);
            }
        }
        
        public List<Category> RetrieveCategories()
        {
            return _dataStore.Categories;
        }

    }
}
