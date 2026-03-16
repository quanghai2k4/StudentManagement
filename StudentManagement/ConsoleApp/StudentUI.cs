using System;
using Application;
using Domain;
using System.Linq;

namespace ConsoleApp
{
    public class StudentUI
    {
        private readonly StudentUseCase _useCase;

        public StudentUI(StudentUseCase useCase)
        {
            _useCase = useCase;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== STUDENT MANAGEMENT SYSTEM ===");
                Console.WriteLine("1. View All Students");
                Console.WriteLine("2. Add New Student");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("0. Exit");
                Console.Write("Select option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": ViewAllStudents(); break;
                    case "2": AddStudent(); break;
                    case "3": UpdateStudent(); break;
                    case "4": DeleteStudent(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid choice. Press any key to try again."); Console.ReadKey(); break;
                }
            }
        }

        private void ViewAllStudents()
        {
            Console.Clear();
            var students = _useCase.GetAllStudents();
            Console.WriteLine("LIST OF STUDENTS:");
            foreach (var s in students)
            {
                Console.WriteLine($"ID: {s.Id} | Name: {s.FirstName} {s.LastName} | Major: {(s.Major != null ? s.Major.MajorName : "N/A")}");
            }
            Console.WriteLine("\nPress any key to return to menu.");
            Console.ReadKey();
        }

        private void AddStudent()
        {
            Console.Clear();
            Console.WriteLine("ADD NEW STUDENT:");
            var s = new Student();
            
            Console.Write("Id: "); s.Id = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("First Name: "); s.FirstName = Console.ReadLine() ?? "";
            Console.Write("Last Name: "); s.LastName = Console.ReadLine() ?? "";
            Console.Write("DOB (yyyy-MM-dd): "); s.DateOfBirth = DateOnly.Parse(Console.ReadLine() ?? "2000-01-01");

            // Chọn ngành học (Major)
            Console.WriteLine("\n--- Select Major ---");
            var majors = _useCase.GetAllMajors();
            for (int i = 0; i < majors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {majors[i].MajorName}");
            }
            Console.WriteLine("0. No Major (N/A)");
            Console.Write("Choice: ");
            int majorChoice = int.Parse(Console.ReadLine() ?? "0");
            
            if (majorChoice > 0 && majorChoice <= majors.Count)
            {
                s.Major = majors[majorChoice - 1];
            }

            _useCase.AddStudent(s);
            Console.WriteLine("Student added successfully! Press any key.");
            Console.ReadKey();
        }

        private void UpdateStudent()
        {
            Console.Clear();
            Console.Write("Enter Student ID to update: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            var s = _useCase.GetStudentById(id);
            if (s == null)
            {
                Console.WriteLine("Student not found!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Updating Student: {s.FirstName} {s.LastName}");
            Console.Write("New First Name (current: " + s.FirstName + "): "); s.FirstName = Console.ReadLine() ?? s.FirstName;
            Console.Write("New Last Name (current: " + s.LastName + "): "); s.LastName = Console.ReadLine() ?? s.LastName;
            
            // Cập nhật ngành học
            Console.WriteLine("\n--- Update Major ---");
            Console.WriteLine($"Current Major: {(s.Major != null ? s.Major.MajorName : "None")}");
            var majors = _useCase.GetAllMajors();
            for (int i = 0; i < majors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {majors[i].MajorName}");
            }
            Console.WriteLine("0. Keep current or set to None");
            Console.Write("Choice: ");
            var mInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(mInput))
            {
                int majorChoice = int.Parse(mInput);
                if (majorChoice > 0 && majorChoice <= majors.Count)
                {
                    s.Major = majors[majorChoice - 1];
                }
                else if (majorChoice == 0)
                {
                    s.Major = null;
                }
            }

            _useCase.UpdateStudent(s);
            Console.WriteLine("Updated successfully!");
            Console.ReadKey();
        }

        private void DeleteStudent()
        {
            Console.Clear();
            Console.Write("Enter Student ID to delete: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            _useCase.DeleteStudent(id);
            Console.WriteLine("Deleted successfully!");
            Console.ReadKey();
        }
    }
}
