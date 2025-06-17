using System.Text;

namespace _6Task
{
    /*Використовуючи клас SortedList, створіть невелику колекцію та виведіть на екран значення пар «ключ-значення»
     * спочатку в алфавітному порядку, а потім у зворотному.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            var sortedList = new SortedList<string, string>();
            sortedList.Add("four", "чотири");
            sortedList.Add("one", "один");
            sortedList.Add("five", "пять");
            sortedList.Add("two", "два");
            sortedList.Add("three", "три");

            //за замовчуванням в порядку зростання
            Console.WriteLine("\n В алфавітному порядку");
            foreach (var item in sortedList)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            var reverseComparer = Comparer<string>.Create((x, y) => string.Compare(y, x, StringComparison.OrdinalIgnoreCase));

            var reversedList = new SortedList<string, string>(reverseComparer);

            foreach (var pair in sortedList)
            {
                reversedList.Add(pair.Key, pair.Value);
            }

            Console.WriteLine("\n В зворотному порядку");
            foreach (var item in reversedList)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
