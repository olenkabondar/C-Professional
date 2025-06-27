using System.Text;
using System.Xml;
using static System.Reflection.Metadata.BlobBuilder;

namespace _2Task
{
    /*Створіть програму, яка виводить на екран всю інформацію про вказаний .xml файл.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            //path file enter user

            //Console.Write("Введіть шлях до XML файлу: ");
            //string path = Console.ReadLine();


            //xml file near exe
            string exeFolder = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "books.xml";
            string path = Path.Combine(exeFolder, fileName);


            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не знайдено.");
                return;
            }

            FileInfo fileInfo = new FileInfo(path);
            Console.WriteLine($"Ім'я файлу: {fileInfo.Name}");
            Console.WriteLine($"Повний шлях: {fileInfo.FullName}");
            Console.WriteLine($"Розмір файлу: {fileInfo.Length} байт");
            Console.WriteLine($"Дата створення: {fileInfo.CreationTime}");
            Console.WriteLine($"Дата останньої зміни: {fileInfo.LastWriteTime}");
            Console.WriteLine();

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path);

                Console.WriteLine("Вміст XML файлу:");
                // Виводимо відформатований XML
                Console.WriteLine(FormatXml(xmlDoc));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при читанні файлу: {ex.Message}");
            }
        }

        static string FormatXml(XmlDocument xmlDoc)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (XmlTextWriter xtw = new XmlTextWriter(sw))
                {
                    xtw.Formatting = Formatting.Indented;
                    xmlDoc.WriteTo(xtw);
                    return sw.ToString();
                }
            }
        }
    }
}
