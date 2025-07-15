using System.Text;

namespace _2Task
{
    /*Перетворіть приклад блокування подій таким чином, щоб замість ручної обробки використовувалася автоматична.
     Перетворення прикладу з уроку 016_WaitHandle*/
    internal class Program
    {
        // CountdownEvent автоматично відстежує кількість виконаних завдань і дає сигнал, коли всі завершено.
        static CountdownEvent countdown = new CountdownEvent(2); // початково задаємо лічильник на 2 задачі
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            // Поміщення двох завдань у пул потоків
            ThreadPool.QueueUserWorkItem(Task1);
            ThreadPool.QueueUserWorkItem(Task2);

            Console.WriteLine("Очікування завершення обох завдань.");
            countdown.Wait(); // Очікування, поки CountdownEvent стане 0
            Console.WriteLine("\nУсі завдання завершені.");

            // Другий запуск
            countdown.Reset(2); // Повторне встановлення на 2 завдання

            ThreadPool.QueueUserWorkItem(Task1);
            ThreadPool.QueueUserWorkItem(Task2);

            Console.WriteLine("\nОчікування завершення одного із завдань.");
            while (countdown.CurrentCount > 1)
            {
                Thread.Sleep(100); // Очікуємо, поки одна з задач завершиться
            }
            Console.WriteLine("\nОдне із завдань завершено.");
            countdown.Wait(); // Чекаємо на друге
        }

        static void Task1(object state)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write("1 ");
                Thread.Sleep(500);
            }
            countdown.Signal(); // Зменшити лічильник
        }

        static void Task2(object state)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write("2 ");
                Thread.Sleep(500);
            }
            countdown.Signal(); // Зменшити лічильник
        }
    }
}
