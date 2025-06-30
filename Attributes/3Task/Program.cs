using System.Reflection;
using System.Text;

namespace _3Task
{
    /*Розширте можливості програми-рефлектора з попереднього уроку таким чином:
    1. Додайте можливість вибирати, які саме члени типу мають бути показані користувачеві. 
    При цьому має бути можливість вибирати відразу кілька членів типу, наприклад, методи та властивості.
    2. Додайте можливість виводу інформації про атрибути для типів та всіх членів типу, які можуть бути декоровані атрибутами.*/

    //опишу завдання не з минулого рефлектора а зроблю консольний варіант
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            string assemblyPath = @"C://STUDY//С#Professional//HWProffesional//Attributes//TemperatureLibrary//bin//Release//net8.0//TemperatureLibrary.dll";

            //Console.Write("Введіть повний шлях до збірки: ");
            //string assemblyPath = Console.ReadLine();

            if (!File.Exists(assemblyPath))
            {
                Console.WriteLine("Файл не знайдено.");
                return;
            }

            Assembly assembly = Assembly.LoadFrom(assemblyPath);
            Console.WriteLine("Збірка завантажена: " + assembly.FullName);

            foreach (Type type in assembly.GetTypes())
            {
                Console.WriteLine($"\nТип: {type.FullName}");

                PrintAttributes("Атрибути типу", type.GetCustomAttributes());

                Console.WriteLine("Оберіть, які члени типу показати:");
                Console.WriteLine("1 - Методи\n2 - Властивості\n3 - Поля\n4 - Конструктори\n5 - Все\nВведіть кілька чисел через кому:");

                string[] options = Console.ReadLine()?.Split(',') ?? Array.Empty<string>();

                if (options.Contains("1") || options.Contains("5"))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Методи:");
                    foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
                    {
                        Console.WriteLine(method);
                        PrintAttributes("  [Атрибути]", method.GetCustomAttributes());
                    }
                }

                if (options.Contains("2") || options.Contains("5"))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Властивості:");
                    foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
                    {
                        Console.WriteLine(prop);
                        PrintAttributes("  [Атрибути]", prop.GetCustomAttributes());
                    }
                }

                if (options.Contains("3") || options.Contains("5"))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Поля:");
                    foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
                    {
                        Console.WriteLine(field);
                        PrintAttributes("  [Атрибути]", field.GetCustomAttributes());
                    }
                }

                if (options.Contains("4") || options.Contains("5"))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Конструктори:");
                    foreach (var ctor in type.GetConstructors())
                    {
                        Console.WriteLine(ctor);
                        PrintAttributes("  [Атрибути]", ctor.GetCustomAttributes());
                    }
                }
            }
        }

        static void PrintAttributes(string label, IEnumerable<Attribute> attributes)
        {
            foreach (var attr in attributes)
            {
                Console.WriteLine($"{label}: {attr.GetType().Name}");
            }
        }
    }
}
