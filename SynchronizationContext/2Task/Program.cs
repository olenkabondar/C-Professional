using System.Text;

namespace _2Task
{
    /*Створіть програму за шаблоном Console Application. Створіть свій контекст синхронізації та перевизначте метод Post. 
     * Метод Post повинен виконувати отриманий делегат у контексті потоку (примірник класу Thread). 
     * Дайте потоку, створеному виконання делегату у методі Post, ім'я. Встановіть на початку роботи методу Main створений контекст синхронізації. 
     * Створіть асинхронний метод, який у контексті завдання розраховує факторіал числа через цикл. 
     * Використовуйте оператор await для очікування завершення цього завдання. 
     * До і після оператора await виведіть на екран консолі в якому id потоку (ManagedThreadId) виконується ця частина, ім'я потоку (Name) 
     * і чи є потік потоком з пулу (IsThreadPoolThread).*/
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            // Встановлення власного контексту синхронізації
            var context = new MySynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(context);

            Console.WriteLine("Головний Main потік:");
            PrintThreadInfo();

            // Виклик асинхронного методу
            await CalculateFactorialAsync(6);

            Console.WriteLine("Повернення до головного Main потоку:");
            PrintThreadInfo();

            Console.ReadLine();
        }
        static async Task CalculateFactorialAsync(int n)
        {
            Console.WriteLine("\n Початок методу обрахунку факторіалу числа (до await)");
            PrintThreadInfo();

            int result = await Task.Run(() =>
            {
                int factorial = 1;
                for (int i = 2; i <= n; i++)
                    factorial *= i;
                return factorial;
            });

            Console.WriteLine("Кінець обрахунку факторіалу числа (після await)");
            PrintThreadInfo();

            Console.WriteLine($"Факторіал числа {n} =  {result}");
        }

        static void PrintThreadInfo()
        {
            var thread = Thread.CurrentThread;
            Console.WriteLine($"Thread ID: {thread.ManagedThreadId}, " +
                              $"Name: {thread.Name ?? "null"}, " +
                              $"IsThreadPoolThread: {thread.IsThreadPoolThread}");
        }
    }
    class MySynchronizationContext : SynchronizationContext
    {
        public override void Post(SendOrPostCallback d, object state)
        {
            Thread thread = new Thread(() =>
            {
                Thread.CurrentThread.Name = "CustomContextThread";
                d(state);
            });
            thread.Start();
        }
    }
}
