using System.Text;

namespace _2Task
{
    /*Вивчіть опис шаблону Template method (Шаблонний метод). 
     * Зверніть увагу на застосування шаблону, а також на склад його учасників і зв'язку відносини між ними. 
     * Напишіть невелику програму мовою C#, що є абстрактною реалізацією даного шаблону.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            CaffeineBeverage tea = new Tea();
            Console.WriteLine("Приготування чаю:");
            tea.PrepareRecipe();

            Console.WriteLine();

            CaffeineBeverage coffee = new Coffee();
            Console.WriteLine("Приготування кави:");
            coffee.PrepareRecipe();
        }
    }
}
