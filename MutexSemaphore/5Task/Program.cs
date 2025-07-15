using System.Text;

namespace _5Task
{
    /*Створіть Semaphore, що контролює доступу до ресурсу з кількох потоків. 
     * Організуйте впорядкований висновок інформації про отримання доступу до спеціального файлу *.log.*/
    internal class Program
    {
        // Семафор дозволяє одночасно доступ лише для 1 потоку (макс. 1)
        static Semaphore semaphore = new Semaphore(1, 1, "LogFileAccessSemaphore");
        static string logFilePath = "LogFileAccessSemaphore.txt";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Початок роботи потоків\n");

            for (int i = 1; i <= 5; i++)
            {
                int threadId = i;
                Thread thread = new Thread(() => AccessLog(threadId));
                thread.Start();
            }

            Console.ReadKey();
        }
        static void AccessLog(int threadId)
        {
            Console.WriteLine($"Потік {threadId} очікує доступу до файлу...");

            semaphore.WaitOne(); // Очікує, поки буде дозволено доступ
            try
            {
                Console.WriteLine($"Потік {threadId} отримав доступ!");

                //запис у файл
                string message = $"[{DateTime.Now}] Потік {threadId} записав у log.txt{Environment.NewLine}";
                File.AppendAllText(logFilePath, message);
                Thread.Sleep(1000); // Затримка для імітації роботи з файлом
            }
            finally
            {
                Console.WriteLine($"Потік {threadId} звільняє доступ!");
                semaphore.Release(); // Звільнення семафору
            }
        }
    }
}
