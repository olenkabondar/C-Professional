using System.Text;
using TemperatureConverterLibrary;

namespace _2Task
{
    /*Створіть власну користувальницьку збірку за прикладом складання CarLibrary з уроку, 
     * складання буде використовуватися для роботи з конвертером температури.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            double celsius = 21;
            double fahrenheit = TemperatureConverter.CelsiusToFahrenheit(celsius);
            Console.WriteLine("Перетворення з Цельсію в Фаренгейти:");
            Console.WriteLine($"{celsius} °C = {fahrenheit} °F");

            double kelvin = TemperatureConverter.CelsiusToKelvin(celsius);
            Console.WriteLine("Перетворення з Цельсію в Кельвіни:");
            Console.WriteLine($"{celsius} °C = {kelvin} K");

            double celsiusFromK = TemperatureConverter.KelvinToCelsius(kelvin);
            Console.WriteLine("Перетворення з Кельвіну в Цельсії:");
            Console.WriteLine($"{kelvin} K = {celsiusFromK} °C");

            double celsiusFromF = TemperatureConverter.FahrenheitToCelsius(fahrenheit);
            Console.WriteLine("Перетворення з Фаренгейту в Цельсії:");
            Console.WriteLine($"{fahrenheit} °F = {celsiusFromF} °C");
        }
    }
}
