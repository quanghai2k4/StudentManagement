using System;
using System.Collections.Generic;
using Application;
using Domain;

namespace ConsoleApp
{
    public class BookUI
    {
        private readonly BookUseCase _useCase;

        public BookUI(BookUseCase useCase)
        {
            _useCase = useCase;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== BOOK MANAGEMENT SYSTEM ===");
                Console.WriteLine("1. View All Books");
                Console.WriteLine("2. Add New Book");
                Console.WriteLine("3. Update Book");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": ViewAllBooks(); break;
                    case "2": AddBook(); break;
                    case "3": UpdateBook(); break;
                    case "4": DeleteBook(); break;
                    case "0": return;
                }
            }
        }

        private void ViewAllBooks()
        {
            Console.Clear();
            var books = _useCase.GetAllBooks();
            foreach (var b in books)
            {
                Console.WriteLine($"ID: {b.Id} | Title: {b.Title} | Author: {b.Author} | Price: {b.Price} | Category: {b.Category?.CategoryName}");
            }
            Console.ReadKey();
        }

        private void AddBook()
        {
            var b = new Book();
            Console.Write("Id: "); b.Id = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Title: "); b.Title = Console.ReadLine() ?? "";
            Console.Write("Author: "); b.Author = Console.ReadLine() ?? "";
            Console.Write("Price: "); b.Price = decimal.Parse(Console.ReadLine() ?? "0");

            var categories = _useCase.GetAllCategories();
            for (int i = 0; i < categories.Count; i++)
                Console.WriteLine($"{i + 1}. {categories[i].CategoryName}");
            
            Console.Write("Select Category: ");
            int c = int.Parse(Console.ReadLine() ?? "1");
            b.Category = categories[c - 1];

            _useCase.AddBook(b);
        }

        private void UpdateBook()
        {
            Console.Write("Id to update: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            var b = _useCase.GetBookById(id);
            if (b == null) return;

            Console.Write("New Title: "); b.Title = Console.ReadLine() ?? b.Title;
            _useCase.UpdateBook(b);
        }

        private void DeleteBook()
        {
            Console.Write("Id to delete: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            _useCase.DeleteBook(id);
        }
    }
}
