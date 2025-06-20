using System.Text;

namespace _6Task
{
    /*Створіть на диску 100 директорій із іменами від Folder_0 до Folder_99, потім видаліть їх.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            string basePath = AppDomain.CurrentDomain.BaseDirectory + @"\ForFolder";

            Directory.CreateDirectory(basePath);
            Console.WriteLine("Створення директорій.");

            for (int i = 0; i < 100; i++)
            {
                string folderName = Path.Combine(basePath, $"Folder_{i}");
                Directory.CreateDirectory(folderName);
            }

            Console.WriteLine("100 папок створено.");

            Console.WriteLine("Видалення директорій.");

            for (int i = 0; i < 100; i++)
            {
                string folderName = Path.Combine(basePath, $"Folder_{i}");
                if (Directory.Exists(folderName))
                {
                    Directory.Delete(folderName);
                }
            }

            Console.WriteLine("Усі папки видалено.");
        }
    }
}
