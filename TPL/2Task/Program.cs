using System.Text;

namespace _2Task
{
    /*Створіть два методи, які виконуватимуться у межах паралельних завдань. Організуйте виклик цих методів за допомогою Invoke таким чином, 
     * щоб основний потік програми (метод Main) не зупинив виконання.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Головний потік в Main.");

            // Запускаємо паралельні завдання у фоновому потоці
            Task.Run(() =>
            {
                TaskFactory factory = new TaskFactory();
                factory.ContinueWhenAll(
                    new Task[]
                    {
                    factory.StartNew(Method1),
                    factory.StartNew(Method2)
                    },
                    tasks => Console.WriteLine("Обидва методи завершені.")
                ).Wait();
            });

            //основний потік продовжує виконання
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Main працює - {i + 1}");
                Thread.Sleep(300);
            }

            Console.WriteLine("Завершення головного потоку Main.");
            Console.ReadKey();
        }

        static void Method1()
        {
            Console.WriteLine("Метод 1 почав виконання.");
            Thread.Sleep(1500);
            Console.WriteLine("Метод 1 завершив виконання.");
        }

        static void Method2()
        {
            Console.WriteLine("Метод 2 почав виконання.");
            Thread.Sleep(1000); //закінчиться раніш бо менше часу засинає
            Console.WriteLine("Метод 2 завершив виконання.");
        }
    }
}
