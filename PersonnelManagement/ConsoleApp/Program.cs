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
            PersonnelRepository repository = new PersonnelRepository(dataStore);
            PersonnelUseCase useCase = new PersonnelUseCase(repository, dataStore);
            PersonnelUI ui = new PersonnelUI(useCase);
            ui.Run();
        }
    }
}
