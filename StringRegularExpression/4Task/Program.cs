using System.Globalization;
using System.Text;

namespace _4Task
{
    /*Створіть текстовий файл-чек на кшталт «Найменування товару – 0.00(ціна)грн.» з певною кількістю найменувань товарів та датою здійснення покупки. 
     * Виведіть на екран інформацію з чека у форматі поточної локалі користувача та у форматі локалі en-US.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            var items = new List<ProductInfo>
            {
                new ProductInfo { ProductName = "Телефон Samsung", Price = 26000.00m },
                new ProductInfo { ProductName = "Планшет", Price = 25000.80m },
                new ProductInfo { ProductName = "Навушники", Price = 3000.00m },
                new ProductInfo { ProductName = "Клавіатура та мишка", Price = 190.99m },
            };

            DateTime purchaseDate = DateTime.Now;

            string filePath = "4Task.txt";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var item in items)
                {
                    writer.WriteLine($"{item.ProductName} – {item.Price:0.00} грн.");
                }
                writer.WriteLine($"Дата покупки: {purchaseDate}");
            }

            // Вивід у поточній локалі
            Console.WriteLine("Чек (вивід з локалізації користувача):");
            OutputFormatted(items, purchaseDate, CultureInfo.CurrentCulture);

            Console.WriteLine();
            // Вивід у локалі en-US
            Console.WriteLine("Чек (вивід з локалізації en-US):");
            OutputFormatted(items, purchaseDate, new CultureInfo("en-US"));
        }
        static void OutputFormatted(List<ProductInfo> items, DateTime date, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            foreach (var item in items)
            {
                string formattedPrice = item.Price.ToString("C", culture);
                Console.WriteLine($"{item.ProductName} – {formattedPrice}");
            }

            Console.WriteLine("Дата покупки: " + date.ToString(culture));
        }
    }
    class ProductInfo
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
