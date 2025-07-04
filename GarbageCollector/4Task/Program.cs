using System.Text;

namespace _4Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            using (var obj = new BigMemoryHolder(100)) // 100 МБ
            {
                obj.Use();
            }

            Console.WriteLine("Натисніть Enter для завершення.");
            Console.ReadLine();
        }
    }
}
