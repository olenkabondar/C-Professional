using System.Text;
using System.Text.RegularExpressions;

namespace _3Task
{
    /*Напишіть жартівливу програму «Дешифратор», яка в текстовому файлі могла б замінити всі прийменники слово «ГАВ!».*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Програма-дешифратор прийменників на слово «ГАВ!»");

            // Шлях до файлів
            string inputPath = "3TaskInput.txt";
            string outputPath = "3TaskOutput.txt";

            string[] prepositions = {
            "в", "у", "на", "до", "з", "із", "при", "перед", "через", "після", "біля", "для", "над", "під", "поза", "о", "об", "по", "про", "між", "коло", "без"
        };

            string text = File.ReadAllText(inputPath);

            // Замінити кожен прийменник (як окреме слово)
            foreach (var prep in prepositions)
            {
                string pattern = $@"\b{prep}\b"; // \b означає границю слова — не чіпає схожі частини в інших словах
                text = Regex.Replace(text, pattern, "ГАВ!", RegexOptions.IgnoreCase);
            }

            // Записати результат
            File.WriteAllText(outputPath, text);

            Console.WriteLine("Текст дешифровано!");
        }
    }
}
