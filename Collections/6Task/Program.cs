using System.Text;

namespace _6Task
{
    /*Створіть метод, який як аргумент приймає масив цілих чисел і повертає колекцію квадратів усіх непарних чисел масиву. 
     * Для формування колекції використовуйте оператор yield.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine("\n Початковий масив чисел:");
            foreach (int number in numbers)
            {
                Console.Write($"{number},");
            }
            var squareNumber = GetSquare(numbers);

            Console.WriteLine("\n Масив квадратів непарних чисел:");
            foreach (int number in squareNumber)
            {
                Console.Write($"{number},");
            }
        }

        public static IEnumerable<int> GetSquare (int[] numbers)
        {
            foreach (int num in numbers)
            {
                if (num % 2 != 0)
                {
                    yield return num * num;
                }
            }
        }
    }
}
