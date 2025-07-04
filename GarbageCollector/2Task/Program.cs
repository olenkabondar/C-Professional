using System.Text;

namespace _2Task
{
    /*Створіть клас, який дозволить виконувати моніторинг ресурсів, що використовуються програмою. 
     * Використовуйте його з метою спостереження за роботою програми, а саме: користувач може вказати прийнятні рівні споживання ресурсів (пам'яті), 
     * а методи класу дозволять видати попередження, коли кількість ресурсів, що реально використовуються, наблизитися до максимально допустимого рівня.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            var monitor = new ResourceMonitor(memoryLimitMB: 100); // 100 MB

            monitor.MemoryWarning += (usedMemory) =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Увага! Використано {usedMemory / 1024 / 1024} MB пам’яті");
                Console.ResetColor();
            };

            monitor.StartMonitoring();

            Console.WriteLine("Моніторинг запущено. Натисніть Enter для виходу...");
            Console.ReadLine();
            monitor.StopMonitoring();
        }
    }
}
