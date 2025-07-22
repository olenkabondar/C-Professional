using System.Text;

namespace _4Task
{
    /*Створіть масив чисел розмірністю 1000000 або більше. Використовуючи генератор випадкових чисел, проініціалізуйте цей масив значеннями. 
     * Створіть PLINQ запит, який дозволить отримати усі непарні числа з вихідного масиву.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            int size = 1000000;
            int[] numbers = new int[size];

            Random random = new Random();

            // Ініціалізація масиву випадковими числами від 0 до 9999
            for (int i = 0; i < size; i++)
            {
                numbers[i] = random.Next(0, 10000);
            }

            // Використання PLINQ для пошуку непарних чисел
            var oddNumbers = numbers
                .AsParallel()
                .Where(n => n % 2 != 0)
                .ToArray();

            // Вивід кількості знайдених непарних чисел
            Console.WriteLine($"Кількість непарних чисел: {oddNumbers.Length}");

            //виведемо перші 10 чисел
            Console.WriteLine("Перші 10 непарних чисел:");
            foreach (var number in oddNumbers.Take(10))
            {
                Console.Write($"{number} ");
            }

            Console.ReadKey();
        }
    }
}
