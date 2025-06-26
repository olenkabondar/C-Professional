using System.Text;
using System.Text.RegularExpressions;

namespace _6Task
{
    /*Напишіть консольну програму, яка дозволяє користувачеві зареєструватися під «Логіном», 
     * що складається тільки з символів латинського алфавіту, і пароля, що складається з цифр і символів.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            string login = "";
            string password = "";

            while (true)
            {
                Console.Write("Введіть логін (тільки латинські літери): ");
                login = Console.ReadLine();

                if (Regex.IsMatch(login, @"^[a-zA-Z]+$"))
                    break;
                else
                    Console.WriteLine("Логін має містити лише латинські літери! Повторіть спробу: ");
            }

            // Перевірка пароля
            while (true)
            {
                Console.Write("Введіть пароль (тільки цифри і символи): ");
                password = Console.ReadLine();

                if (Regex.IsMatch(password, @"^[\d\W]+$"))
                    break;
                else
                    Console.WriteLine("Пароль має містити лише цифри та спеціальні символи! Повторіть спробу: ");
            }

            // Збереження в файл
            File.AppendAllText("6Task.txt", $"{login}:{password}\n");

            Console.WriteLine("Реєстрація завершена, дані збережено в файл 6Task.txt");
        }
    }
}
