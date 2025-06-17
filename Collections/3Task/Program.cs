using System.Text;

namespace _3Task
{
    /*Створіть колекцію, яка б за своєю структурою нагадувала «родове дерево» (ім'я людини, рік народження), 
     * причому до неї можна додавати/вилучати нового родича, є можливість побачити всіх спадкоємців обраної людини, 
     * відібрати родичів за роком народження. */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            // початок дерева
            var root = new Person("Олександр", 1962);

            // додавання дітей
            var yulia = new Person("Юлія", 1986);
            var olena = new Person("Олена", 1991);
           
            root.AddChild(yulia);
            root.AddChild(olena);

            // додавання дітей дітей
            yulia.AddChild(new Person("Данило", 2007));
            yulia.AddChild(new Person("Захар", 2014));
            olena.AddChild(new Person("Тимур", 2016));

            // всі спадкоємці Олександра
            Console.WriteLine("Спадкоємці Олександра:");
            foreach (var child in root.GetChild())
                Console.WriteLine(child);

            // пошук за роком народження
            Console.Write("Введіть рік народження: ");
            if (int.TryParse(Console.ReadLine(), out int yearBirth))
            {
                Console.WriteLine($"Спадкоємці, народжені у {yearBirth} році:");
                var allChild = root.GetChild().Where(p => p.BirthYear == yearBirth);
                foreach (var child in allChild)
                    Console.WriteLine(child);
            }

            // видалення дитини
            root.RemoveChild("Юлія");
            Console.WriteLine("Після видалення Юлія:");
            foreach (var child in root.GetChild())
                Console.WriteLine(child);
        }
    }
}
