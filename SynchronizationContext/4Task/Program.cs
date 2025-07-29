using System.Text;

namespace _4Task
{
    /*Створіть програму за шаблоном Console Application. Створіть контекст синхронізації, який зможе обробляти помилки,
     * що виникли в асинхронних методах з типом void, що повертається. 
     * Встановіть створений контекст синхронізації та перевірте виклик асинхронного методу з типом void, чи обробляється ваша помилка в контексті.
     * Встановіть контекст синхронізації. Зробіть висновки щодо використання асинхронних методів з типом void.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            // Встановлюємо наш контекст синхронізації
            var context = new ErrorHandlingSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(context);

            Console.WriteLine("Головний Main потік:");
            PrintThreadInfo();

            // Викликаємо async void метод — помилка всередині
            ThrowingAsyncVoid();

            // Даємо час async void методу завершитись
            Thread.Sleep(5000);

            Console.WriteLine("Програму завершено.");
        }
        static async void ThrowingAsyncVoid()
        {
            await Task.Delay(500);
            Console.WriteLine("\nВсередині async void.");
            PrintThreadInfo();

            throw new InvalidOperationException("Помилка в async void!");
        }

        static void PrintThreadInfo()
        {
            var thread = Thread.CurrentThread;
            Console.WriteLine($"Thread ID: {thread.ManagedThreadId}, " +
                              $"Name: {thread.Name ?? "null"}, " +
                              $"IsThreadPoolThread: {thread.IsThreadPoolThread}");
        }
    }
    class ErrorHandlingSynchronizationContext : SynchronizationContext
    {
        public override void Post(SendOrPostCallback d, object state)
        {
            Thread thread = new Thread(() =>
            {
                try
                {
                    d(state);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[SynchronizationContext] Caught exception: {ex.Message}");
                }
            });

            thread.Name = "ErrorHandlingContextThread";
            thread.Start();
        }
    }
}
