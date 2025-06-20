using System.IO.Compression;
using System.Text;

namespace _3Task
{
    /*Напишіть програму для пошуку заданого файлу на диску. Додайте код, який використовує клас FileStream і дозволяє переглядати файл у текстовому вікні. 
     * Насамкінець додайте можливість стиснення знайденого файлу.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.Write("Введіть назву файлу (наприклад, text.txt): ");
            string fileName = Console.ReadLine();

            string rootDirectory = AppDomain.CurrentDomain.BaseDirectory; //вказую ту ж директорію де ехе файл
            string foundFile = FindFile(rootDirectory, fileName);
            string fullPathWithoutExtension = Path.Combine(Path.GetDirectoryName(foundFile), Path.GetFileNameWithoutExtension(foundFile));

            if (foundFile != null)
            {
                Console.WriteLine($"\n Файл знайдено: {foundFile}");

                // Читання через FileStream
                using (FileStream fs = new FileStream(foundFile, FileMode.Open, FileAccess.Read))
                using (StreamReader reader = new StreamReader(fs))
                {
                    Console.WriteLine("Вміст файлу:\n");
                    string content = reader.ReadToEnd();
                    Console.WriteLine(content);
                }

                string compressedFile = fullPathWithoutExtension + ".gz";
                CompressFile(foundFile, compressedFile);
                Console.WriteLine($"Файл стиснуто в: {compressedFile}");
            }
            else
            {
                Console.WriteLine("Файл не знайдено.");
            }
        }

        // Метод пошуку файлу рекурсивно
        static string FindFile(string directory, string targetFile)
        {
            try
            {
                foreach (var file in Directory.GetFiles(directory))
                {
                    if (Path.GetFileName(file).Equals(targetFile, StringComparison.OrdinalIgnoreCase))
                        return file;
                }

                foreach (var dir in Directory.GetDirectories(directory))
                {
                    string result = FindFile(dir, targetFile);
                    if (result != null)
                        return result;
                }
            }
            catch (UnauthorizedAccessException) { /* ігнорувати закриті директорії */ }

            return null;
        }

        // Метод стиснення
        static void CompressFile(string sourcePath, string destinationPath)
        {
            using (FileStream sourceStream = new FileStream(sourcePath, FileMode.OpenOrCreate, FileAccess.Read))
            using (FileStream destinationStream = new FileStream(destinationPath, FileMode.Create))
            using (GZipStream compressionStream = new GZipStream(destinationStream, CompressionMode.Compress))
            {
                sourceStream.CopyTo(compressionStream);
            }
        }
    }
}