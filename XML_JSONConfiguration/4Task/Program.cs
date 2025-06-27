using System.Text;
using System.Text.Json;

namespace _4Task
{
    /*Використовуючи приклади, розглянуті на уроці, створіть свою програму для адміністратора, яка зберігатиме дані конфігурації у спеціальному файлі або в реєстрі.
     * Створіть програму користувача, зовнішнім виглядом якого можна керувати за допомогою адмінпрограми.*/
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Програма налаштувань конфігурації!");

            Console.WriteLine("Оберіть режим:");
            Console.WriteLine("1 — Адміністратор");
            Console.WriteLine("2 — Користувач");
            int key = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (key)
            {
                case 1:
                    AdminProgram.Run();
                    break;
                case 2:
                    UserProgram.Run();
                    break;
                default:
                    Console.WriteLine("Невідомий режим.");
                    break;
            }
        }
    }

    public class Config
    {
        public string ForegroundColor { get; set; }
        public string BackgroundColor { get; set; }
    }

    public static class AdminProgram
    {
        private const string configFile = "userconfig.json";
        public static void Run()
        {
            Console.WriteLine("=== Адмін-програма ===");

            Console.Write("Введіть колір тексту (наприклад, Red, Green, Blue): ");
            string fg = Console.ReadLine();

            Console.Write("Введіть колір  фону (наприклад, Black, White, Yellow): ");
            string bg = Console.ReadLine();

            var config = new Config
            {
                ForegroundColor = fg,
                BackgroundColor = bg
            };

            string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(configFile, json);

            Console.WriteLine($"Налаштування збережено у {configFile}");
        }
    }

    public static class UserProgram
    {
        private const string configFile = "userconfig.json";

        public static void Run()
        {
            Console.WriteLine("=== Користувацький режим ===");

            if (File.Exists(configFile))
            {
                try
                {
                    string json = File.ReadAllText(configFile);
                    var config = JsonSerializer.Deserialize<Config>(json);

                    Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), config.ForegroundColor, true);
                    Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), config.BackgroundColor, true);
                    Console.Clear();
                }
                catch
                {
                    Console.WriteLine("Помилка в налаштуваннях. Використовуються стандартні кольори.");
                }
            }
            else
            {
                Console.WriteLine("Налаштування не знайдено.");
            }

            Console.WriteLine("Програма користувача з налаштуваннями.");
            Console.ReadKey();
        }
    }
}