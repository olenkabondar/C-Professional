using System.Text;

namespace _2Task
{
    /*Створіть колекцію, в якій зберігалися б найменування 12 місяців, порядковий номер і кількість днів у відповідному місяці. 
     * Реалізуйте можливість вибору місяців як за порядковим номером, так і кількістю днів у місяці, при цьому результатом може бути не тільки один місяць.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            List<Month> months = new List<Month>
            {
                new Month { MonthName = "Січень", Number = 1, CountDays = 31 },
                new Month { MonthName = "Лютий", Number = 2, CountDays = 28 },
                new Month { MonthName = "Березень", Number = 3, CountDays = 31 },
                new Month { MonthName = "Квітень", Number = 4, CountDays = 30 },
                new Month { MonthName = "Травень", Number = 5, CountDays = 31 },
                new Month { MonthName = "Червень", Number = 6, CountDays = 30 },
                new Month { MonthName = "Липень", Number = 7, CountDays = 31 },
                new Month { MonthName = "Серпень", Number = 8, CountDays = 31 },
                new Month { MonthName = "Вересень", Number = 9, CountDays = 30 },
                new Month { MonthName = "Жовтень", Number = 10, CountDays = 31 },
                new Month { MonthName = "Листопад", Number = 11, CountDays = 30 },
                new Month { MonthName = "Грудень", Number = 12, CountDays = 31 }
            };

            // Вибір за кількістю днів
            Console.WriteLine("\nВведіть кількість днів у місяці: ");
            if (int.TryParse(Console.ReadLine(), out int countDays))
            {
                var monthsByDays = months.Where(m => m.CountDays == countDays).ToList();
                if (monthsByDays.Count != 0)
                {
                    Console.WriteLine($"Місяці з кількістю днів {countDays}:");
                    foreach (var m in monthsByDays)
                        Console.WriteLine(m);
                }
                else
                    Console.WriteLine($"Немає місяців з кількістю днів {countDays}.");
            }

            // Вибір за номером місяця
            Console.WriteLine("Введіть номер місяця: ");
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                var monthByNumber = months.FirstOrDefault(m => m.Number == num);
                if (monthByNumber != null)
                    Console.WriteLine($"Місяць з № {num} це {monthByNumber.MonthName} з {monthByNumber.CountDays} днів.");
                else
                    Console.WriteLine($"Місяця з № {num} не знайдено.");
            }
        }
    }
}
