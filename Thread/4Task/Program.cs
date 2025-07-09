namespace _4Task
{
    /*Використовуючи конструкції блокування, модифікуйте останній приклад уроку таким чином, щоб отримати можливість послідовної роботи 3-х потоків.*/
    internal class Program
    {
        static int counter = 0;
        static object locker = new object();  // Загальний об'єкт блокування
        static int currentThread = 0;

        static void Function(int threadIndex)
        {
            for (int i = 0; i < 10; i++)
            {
                lock (locker)
                {
                    while (threadIndex != currentThread)
                    {
                        Monitor.Wait(locker);  // Чекаємо, поки не прийде наша черга
                    }

                    Console.WriteLine($"Thread {threadIndex + 1}: {++counter}");

                    // Передаємо керування наступному потоку
                    currentThread = (currentThread + 1) % 3;

                    Monitor.PulseAll(locker);  // Пробуджуємо всі потоки
                }
            }
        }

        static void Main()
        {
            Thread[] threads = {
                new Thread(() => Function(0)),
                new Thread(() => Function(1)),
                new Thread(() => Function(2))
            };

            foreach (Thread thread in threads)
                thread.Start();

            Console.ReadKey();
        }
    }
}
