using System.Collections.Generic;
using DataAccess;
using Domain;

namespace Application
{
    public class BookUseCase
    {
        private readonly BookRepository _repository;

        public BookUseCase(BookRepository repository)
        {
            _repository = repository;
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
            return _repository.RetrieveCategories();
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
