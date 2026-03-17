using System.Collections.Generic;
using DataAccess;
using Domain;

namespace Application
{
    public class BookUseCase
    {
        private readonly BookRepository _repository;
        private readonly DataStore _dataStore;

        public BookUseCase(BookRepository repository, DataStore dataStore)
        {
            _repository = repository;
            _dataStore = dataStore;
        }

        public List<Book> GetAllBooks()
        {
            return _repository.RetrieveBooks();
        }

        public Book? GetBookById(int id)
        {
            return _repository.RetrieveBook(id);
        }

        public List<Category> GetAllCategories()
        {
            return _dataStore.Categories;
        }

        public void AddBook(Book book)
        {
            _repository.CreateBook(book);
        }

        public void UpdateBook(Book book)
        {
            _repository.UpdateBook(book);
        }

        public void DeleteBook(int id)
        {
            _repository.DeleteBook(id);
        }
    }
}
