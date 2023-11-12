using System;
using System.Threading;
using System.Threading.Tasks;

namespace EX_01_async_await
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
            Console.WriteLine("1) Асинхронные методы, async и await");
            Console.WriteLine("2) Задержка асинхронной операции и Task.Delay");
            Console.WriteLine("3) Преимущества асинхронности - СИНХРОННО");
            Console.WriteLine("4) Преимущества асинхронности - АСИНХРОННО");
            Console.WriteLine("5) Лямбда при определении асинхрлонной операции");
            Console.WriteLine("0) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("================================");
                    Console.WriteLine("Некоторые действия в методе Main");
                    Console.WriteLine("================================");
                    await PrintAsync_01();
                    return true;
                case "2":
                    Console.WriteLine("================================");
                    Console.WriteLine("Некоторые действия в методе Main");
                    Console.WriteLine("================================");
                    await PrintAsync_02();
                    return true;
                case "3":
                    PrintName("Tom");
                    PrintName("Bob");
                    PrintName("Sam");
                    Console.ReadKey();
                    return true;
                case "4":
                    var tomTask = PrintNameAsync("Tom");
                    var bobTask = PrintNameAsync("Bob");
                    var samTask = PrintNameAsync("Sam");

                    await tomTask;
                    await bobTask;
                    await samTask;
                    Console.ReadKey();
                    return true;
                case "5":
                    var t = Task<int>.Run(() => {
                        int max = 1000000;
                        int ctr = 0;
                        for (ctr = 0; ctr <= max; ctr++)
                        {
                            if (ctr == max / 2 && DateTime.Now.Hour <= 12)
                            {
                                ctr++;
                                break;
                            }
                        }
                        return ctr;
                    });
                    Console.WriteLine("Finished {0:N0} iterations.", t.Result);
                    Console.ReadKey();
                    return true;
                case "0":
                    return false;
                default:
                    return true;
            }
        }

        // --- 01 --- Асинхронные методы, async и await
        private static void Print()
        {
            Thread.Sleep(3000);     // имитация продолжительной работы
            Console.WriteLine("Hello Guys!");
        }
        // определение асинхронного метода
        private static async Task PrintAsync_01()
        {
            Console.WriteLine("Начало метода PrintAsync");  // выполняется синхронно
            await Task.Run(() => Print());                  // выполняется асинхронно
            Console.WriteLine("Конец метода PrintAsync");
            Console.ReadKey();
        }
        // --- 02 --- Задержка асинхронной операции и Task.Delay
        private static async Task PrintAsync_02()
        {
            await Task.Delay(3000);     // имитация продолжительной работы
                                        // или так
                                        //await Task.Delay(TimeSpan.FromMilliseconds(3000));
            Console.WriteLine("Hello GUYS");
            Console.ReadKey();
        }
        // ---03 --- Преимущества асинхронности
        private static  void PrintName(string name)
        {
            Thread.Sleep(1000);     // имитация продолжительной работы
            Console.WriteLine(name);
        }
        // определение асинхронного метода
        private static async Task PrintNameAsync(string name)
        {
            await Task.Delay(1000);     // имитация продолжительной работы
            Console.WriteLine(name);
        }
    }
}
