using System.Collections.Specialized;
using System.Text;

namespace _4Task
{
    /*Створіть колекцію типу OrderedDictionary та реалізуйте у ній можливість порівняння значень.*/

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            var orderedDictionary = new OrderedDictionary();

            // Додаємо елементи (ключ - int, значення - string)
            orderedDictionary.Add(4, "four");
            orderedDictionary.Add(1, "one");
            orderedDictionary.Add(5, "five");
            orderedDictionary.Add(2, "two");
            orderedDictionary.Add(3, "three");
            foreach (var pair in orderedDictionary)
            {
                Console.WriteLine($"{pair}");
            }

            int key1 = 4;
            int key2 = 1;

            string value1 = orderedDictionary[key1].ToString();
            string value2 = orderedDictionary[key2].ToString();

            if (value1 == null || value2 == null)
                Console.WriteLine("Значення не є рядками.");
            else
            {
                int result = string.Compare(value1, value2, StringComparison.OrdinalIgnoreCase);

                if (result < 0)
                    Console.WriteLine($"{orderedDictionary[key1]} менше ніж {orderedDictionary[key2]}");
                else if (result > 0)
                    Console.WriteLine($"{orderedDictionary[key1]} більше ніж {orderedDictionary[key2]}");
                else
                    Console.WriteLine($"{orderedDictionary[key1]} дорівнює {orderedDictionary[key2]}");
            }
        }
    }
}
