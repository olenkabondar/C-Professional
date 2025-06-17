using System.Text;

namespace _4Task
{
    /*Створіть колекцію, в яку можна записувати два значення одного слова, на кшталт польсько-англо-українського словника. 
     * І в ній можна для українського слова знайти або лише польське значення, або лише англійське та вивести його на екран.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            var dictionary = new Dictionary<string, MyDictionary>
            {
                { "один", new MyDictionary("jeden", "one") },
                { "два", new MyDictionary("dwa", "two") },
                { "три", new MyDictionary("trzy", "three") },
                { "чотири", new MyDictionary("cztery", "four") },
                { "пять", new MyDictionary("pięć", "five") },
            };
            Console.WriteLine("Мій словник:");
            foreach (var key in dictionary)
            {
                Console.WriteLine($"{key.Key} - {key.Value.Polish} - {key.Value.English}");
            }

            Console.Write("Введіть українське слово: ");
            string input = Console.ReadLine();

            if (dictionary.ContainsKey(input))
            {
                Console.WriteLine($"Польською: {dictionary.GetValueOrDefault(input).Polish}, англійською: {dictionary.GetValueOrDefault(input).English}");
            }
            else
            {
                Console.WriteLine($"Слово {input} не знайдено.");
            }
        }
    }
}
