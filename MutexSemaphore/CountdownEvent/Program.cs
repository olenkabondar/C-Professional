using System.Text;

namespace CountdownEvent
{
    internal class Program
    {// CountdownEvent із початковим лічильником 2 (дві задачі)
        static CountdownEvent countdown = new CountdownEvent(2);

        static void Main()
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
