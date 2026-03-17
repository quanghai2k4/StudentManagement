using System;
using DataAccess;
using Application;
using ConsoleApp;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DataStore dataStore = new DataStore();
            BookRepository repository = new BookRepository(dataStore);
            BookUseCase useCase = new BookUseCase(repository, dataStore);
            BookUI ui = new BookUI(useCase);
            ui.Run();
        }
    }
}
