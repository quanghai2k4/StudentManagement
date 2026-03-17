using System;
using System.Collections.Generic;
using Application;
using Domain;

namespace ConsoleApp
{
    public class PersonnelUI
    {
        private readonly PersonnelUseCase _useCase;

        public PersonnelUI(PersonnelUseCase useCase)
        {
            _useCase = useCase;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== PERSONNEL MANAGEMENT SYSTEM ===");
                Console.WriteLine("1. View All Staff");
                Console.WriteLine("2. Add New Personnel");
                Console.WriteLine("3. Update Personnel");
                Console.WriteLine("4. Delete Personnel");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": ViewAllStaff(); break;
                    case "2": AddPerson(); break;
                    case "3": UpdatePerson(); break;
                    case "4": DeletePerson(); break;
                    case "0": return;
                }
            }
        }

        private void ViewAllStaff()
        {
            Console.Clear();
            var list = _useCase.GetAllPersonnel();
            foreach (var p in list)
            {
                Console.WriteLine($"ID: {p.Id} | Name: {p.FullName} | Position: {p.Position} | Dept: {p.Department?.DepartmentName}");
            }
            Console.ReadKey();
        }

        private void AddPerson()
        {
            var p = new Personnel();
            Console.Write("Id: "); p.Id = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Full Name: "); p.FullName = Console.ReadLine() ?? "";
            Console.Write("Position: "); p.Position = Console.ReadLine() ?? "";
            Console.Write("Salary: "); p.Salary = decimal.Parse(Console.ReadLine() ?? "0");

            var depts = _useCase.GetAllDepartments();
            for (int i = 0; i < depts.Count; i++)
                Console.WriteLine($"{i + 1}. {depts[i].DepartmentName}");
            
            Console.Write("Select Dept: ");
            int c = int.Parse(Console.ReadLine() ?? "1");
            p.Department = depts[c - 1];

            _useCase.AddPerson(p);
        }

        private void UpdatePerson()
        {
            Console.Write("Id to update: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            var p = _useCase.GetPersonById(id);
            if (p == null) return;

            Console.Write("New Name: "); p.FullName = Console.ReadLine() ?? p.FullName;
            _useCase.UpdatePerson(p);
        }

        private void DeletePerson()
        {
            Console.Write("Id to delete: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            _useCase.DeletePerson(id);
        }
    }
}
