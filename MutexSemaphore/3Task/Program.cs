namespace _3Task
{
    /*Створіть програму, яка може бути запущена лише в одному екземплярі (використовуючи іменований Mutex).*/
    internal class Program
    {

        static Mutex mutex;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            bool isNewInstance;
            string mutexName = "Global\\MyUniqueAppMutex"; // Ім’я mutex-а (унікальне)

            mutex = new Mutex(true, mutexName, out isNewInstance);

            if (!isNewInstance)
            {
                Console.WriteLine("⚠ Програма вже запущена. Завершення...");
                //Console.ReadKey();
                return;
            }

            try
            {
                Console.WriteLine("✅ Програма запущена. Натисніть будь-яку клавішу для виходу...");
                Console.ReadKey();
            }
            finally
            {
                mutex.ReleaseMutex(); //звільняємо Mutex
            }
        }
    }
}
