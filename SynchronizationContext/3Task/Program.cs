using System.Text;

namespace _3Task
{
    /*Створіть програму за шаблоном Console Application. Візьміть попередній приклад (Завдання 2), не прибираючи/не змінюючи контекст синхронізації,
     * виконайте продовження оператора await в контексті робочого потоку пула потоків.*/
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            var context = new MySynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(context);

            Console.WriteLine("Головний Main потік:");
            PrintThreadInfo();

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
            }).ConfigureAwait(false);  // ← Продовження НЕ в оригінальному контексті

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
