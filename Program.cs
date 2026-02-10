using System;
using UltraBan.Core;

namespace UltraBan
{
    class Program
    {
        static void Main(string[] args)
        {
            BanSystemFacade facade = new BanSystemFacade();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- UltraBan System ---");
                Console.WriteLine("1. Добавить приложение");
                Console.WriteLine("2. Добавить действие (Ban/Warn)");
                Console.WriteLine("3. Список приложений");
                Console.WriteLine("4. Отчет по действиям");
                Console.WriteLine("5. Выход и сохранение");
                Console.Write("\nВыберите пункт: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Имя приложения: ");
                        string name = Console.ReadLine();
                        Console.Write("Категория: ");
                        string cat = Console.ReadLine();
                        facade.AddApplication(name, cat);
                        break;
                    case "2":
                        Console.Write("ID приложения: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Тип действия: ");
                        string act = Console.ReadLine();
                        Console.Write("Причина: ");
                        string reason = Console.ReadLine();
                        facade.AddAction(id, act, reason);
                        break;
                    case "3":
                        facade.GetAllApps().ForEach(a => Console.WriteLine(a));
                        break;
                    case "4":
                        ShowReport(facade);
                        break;
                    case "5":
                        facade.SaveData();
                        running = false;
                        break;
                }
            }
        }

        static void ShowReport(BanSystemFacade facade)
        {
            Console.WriteLine("\n--- ПОЛНЫЙ ОТЧЕТ ---");
            foreach (var app in facade.GetAllApps())
            {
                Console.WriteLine($"Приложение: {app.Name}");
                foreach (var action in app.Actions)
                    Console.WriteLine($" - [{action.Timestamp}] {action.ActionType}: {action.Reason}");
            }
        }
    }
}
