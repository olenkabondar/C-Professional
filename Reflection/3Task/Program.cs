using System.Reflection;
using System.Text;

namespace _3Task
{
    /*Створіть програму, в якій надайте користувачеві доступ до збірки із завдання 2. 
     * Реалізуйте використання методу конвертації значення температури зі шкали Цельсія в шкалу Фаренгейта. 
     * Виконуючи завдання використовуйте лише рефлексію.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.Write("Введіть температуру в Цельсіях: ");
            string input = Console.ReadLine();

            if (!double.TryParse(input, out double celsius))
            {
                Console.WriteLine("Невірне числове значення.");
                return;
            }

            try
            {
                // Завантажуємо збірку з файлу DLL              
                Assembly assembly = Assembly.LoadFrom
                    (@"C://STUDY//С#Professional//HWProffesional//Reflection//TemperatureConverterLibrary//bin//Debug//net8.0//TemperatureConverterLibrary.dll");

                // Отримуємо тип класу TemperatureConverter
                Type converterType = assembly.GetType("TemperatureConverterLibrary.TemperatureConverter");
                if (converterType == null)
                {
                    Console.WriteLine("Клас TemperatureConverter не знайдено.");
                    return;
                }

                // Отримуємо метод CelsiusToFahrenheit
                MethodInfo method = converterType.GetMethod("CelsiusToFahrenheit", BindingFlags.Public | BindingFlags.Static);
                if (method == null)
                {
                    Console.WriteLine("Метод CelsiusToFahrenheit не знайдено.");
                    return;
                }

                // Викликаємо метод через рефлексію, передаючи аргумент
                object result = method.Invoke(null, new object[] { celsius });

                Console.WriteLine($"{celsius} °C = {result} °F");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }
    }
}
