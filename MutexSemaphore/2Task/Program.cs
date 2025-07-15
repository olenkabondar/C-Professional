namespace _2Task
{
    /*Перетворіть приклад блокування подій таким чином, щоб замість ручної обробки використовувалася автоматична.*/

    //Змінимо EventResetMode.ManualReset на EventResetMode.AutoReset.
    //Логіка більше не потребує ручного скидання стану після Set() — подія автоматично повернеться в несигнальний стан після пробудження одного потоку.
    internal class Program
    {
        static EventWaitHandle handle = null;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            // EventResetMode.AutoReset — автоматичне скидання стану
            handle = new EventWaitHandle(false, EventResetMode.AutoReset, "GlobalEvent::GUID");

            Thread thread = new Thread(Function) { IsBackground = true };
            thread.Start();

            Console.WriteLine("Натисніть будь-яку клавішу для початку роботи.");
            Console.ReadKey();

            handle.Set();

            Console.ReadKey();
        }
        static void Function()
        {
            handle.WaitOne();

            while (true)
            {
                Console.WriteLine("Hello world!");
                Thread.Sleep(300);
            }
        }
    }
}
