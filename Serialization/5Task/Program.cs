using System.Text.Json;
using System.Text;

namespace _5Task
{
    /*Створіть тип користувача (наприклад, клас) і виконайте серіалізацію об'єкта цього типу, враховуючи той факт,
     * що стан об'єкта необхідно буде передати по мережі.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            // Об'єкт користувача
            User user = new User
            {
                FirstName = "Olena",
                LastName = "Bondar",
                Age = 34,
                Status = "Student",
                Email = "olena@gmail.com",
                Password = "12345"
            };

            // Серіалізація в JSON
            string json = JsonSerializer.Serialize(user);
            Console.WriteLine("JSON serealize: " + json);
        }
    }
}
