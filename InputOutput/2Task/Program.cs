using System.Text;

namespace _2Task
{
    /*Створіть файл, запишіть у нього довільні дані та закрийте файл. Потім знову відкрийте цей файл, прочитайте дані і виведіть їх на консоль.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            var streamFile = new FileStream("2Task.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            var writer = new StreamWriter(streamFile, Encoding.Unicode);
            writer.WriteLine("Привіт, це перший рядок тексту.");
            writer.WriteLine("Другий рядок тексту.");
            writer.Close();
            streamFile.Close();

            Console.WriteLine($"Файл {streamFile.Name} створено та в нього записаний текст.");

            Console.WriteLine($"Виводимо вміст файлу {streamFile.Name}:\n");

            StreamReader reader = File.OpenText("2Task.txt");
            string input;

            while ((input = reader.ReadLine()) != null)
            {
                Console.WriteLine(input);
            }
            reader.Close();
        }
    }
}
