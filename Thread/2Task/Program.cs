using System.Text;

namespace _2Task
{
    /*Створіть консольну програму, яка в різних потоках зможе отримати доступ до 2-х файлів. 
     * Вважайте з цих файлів вміст і спробуйте записати отриману інформацію в третій файл. 
     * Читання/запис мають здійснюватися одночасно у кожному з дочірніх потоків. 
     * Використовуйте блокування потоків для того, щоб досягти коректного запису в кінцевий файл.*/
    internal class Program
    {
        static readonly object fileLock = new object(); // Об'єкт блокування
        static string saveFile = "result.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            // Потоки для читання і запису
            Thread thread1 = new Thread(ReadAndWriteThread);
            Thread thread2 = new Thread(ReadAndWriteThread);

            // Запускаємо потоки
            thread1.Start("file1.txt");
            thread2.Start("file2.txt");

            // Очікуємо завершення
            thread1.Join();
            thread2.Join();

            Console.WriteLine("Інформація зчитана з 2х файлів записано у файл result.txt");
        }
        static void ReadAndWriteThread(object fileNameObj)
        {
            string inputFile = fileNameObj as string;

            if (inputFile == null)
            {
                Console.WriteLine("Некоректне ім'я файлу.");
                return;
            }

            try
            {
                string content = File.ReadAllText(inputFile);

                lock (fileLock)
                {
                    File.AppendAllText(saveFile, $"[{inputFile}]:\n{content}\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка у потоці для {inputFile}: {ex.Message}");
            }
        }
    }
}
