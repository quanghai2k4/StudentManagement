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
            // (7) Trong Main() khởi tạo các object theo thứ tự: DataStore, Repository, UseCase, UI.
            
            // 1. Khởi tạo DataStore
            DataStore dataStore = new DataStore();

            // 2. Khởi tạo Repository (Sử dụng DataStore)
            StudentRepository repository = new StudentRepository(dataStore);

            // 3. Khởi tạo UseCase (Lưu ý: UseCase cần cả Repository và DataStore để lấy danh sách Major)
            StudentUseCase useCase = new StudentUseCase(repository, dataStore);

            // 4. Khởi tạo UI (Chỉ sử dụng UseCase)
            StudentUI ui = new StudentUI(useCase);

            // Kích hoạt UI
            ui.Run();
        }
    }
}
