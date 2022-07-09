using System;
using System.Threading.Tasks;

namespace EX_04_async_await
{
    internal class Program
    {
        static Task Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenuAsync().Result;
            }

            return Task.CompletedTask;
        }

        private static async Task<bool> MainMenuAsync()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Демонстрация блокировки асинхронности синхронностью");
            Console.WriteLine("2) Недетерминированный вывод");
            Console.WriteLine("3) Task.WhenAll");
            Console.WriteLine("4) Task.WhenAny");
            Console.WriteLine("5) Получение резульатата 01");
            Console.WriteLine("6) Получение резульатата 02");
            Console.WriteLine("0) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    await PrintAsync("Hello C#");
                    await PrintAsync("Hello World");
                    await PrintAsync("Hello GUYS!");

                    Console.ReadKey();
                    return true;

                case "2":
                    // определяем и запускаем задачи
                    var task1 = PrintAsync("Hello C#");
                    var task2 = PrintAsync("Hello World");
                    var task3 = PrintAsync("Hello Guys!");

                    // ожидаем завершения задач
                    await task1;
                    await task2;
                    await task3;

                    Console.ReadKey();
                    return true;

                case "3":
                    // определяем и запускаем задачи
                    var task01 = PrintAsync("Hello C#");
                    var task02 = PrintAsync("Hello World");
                    var task03 = PrintAsync("Hello METANIT.COM");

                    // ожидаем завершения всех задач
                    await Task.WhenAll(task01, task02, task03);

                    Console.ReadKey();
                    return true;
                case "4":
                    // определяем и запускаем задачи
                    var task001 = PrintAsync_04("Hello C#");
                    var task002 = PrintAsync_04("Hello World");
                    var task003 = PrintAsync_04("Hello METANIT.COM");

                    // ожидаем завершения хотя бы одной задачи
                    await Task.WhenAny(task001, task002, task003);

                    Console.ReadKey();
                    return true;

                case "5":
                    // определяем и запускаем задачи
                    var taskx = SquareAsync(4);
                    var tasky = SquareAsync(5);
                    var taskz = SquareAsync(6);

                    // ожидаем завершения всех задач
                    int[] results = await Task.WhenAll(taskx, tasky, taskz);
                    // получаем результаты:
                    foreach (int result in results)
                        Console.WriteLine(result);

                    Console.ReadKey();
                    return true;

                case "6":
                    // определяем и запускаем задачи
                    var task0001 = SquareAsync(4);
                    var task0002 = SquareAsync(5);
                    var task0003 = SquareAsync(6);

                    await Task.WhenAll(task0001, task0002, task0003);
                    // получаем результат задачи task2
                    Console.WriteLine($"task2 result: {task0002.Result}"); // task2 result: 25
                    Console.ReadKey();
                    return true;
                case "0":
                    return false;
                default:
                    return true;
            }
        }

        // --- 01 ---
        async static Task PrintAsync(string message)
        {
            await Task.Delay(2000);     // имитация продолжительной операции
            Console.WriteLine(message);
        }
        // --- 02 ---
        // --- 03 ---
        // --- 04 ---
        async static Task PrintAsync_04(string message)
        {
            await Task.Delay(new Random().Next(1000, 2000));     // имитация продолжительной операции
            Console.WriteLine(message);
        }
        // --- 05 ---
        async static Task<int> SquareAsync(int n)
        {
            await Task.Delay(1000);
            return n * n;
        }
        // --- 06 ---
    }
}
