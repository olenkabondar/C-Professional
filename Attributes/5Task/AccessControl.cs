using System.Reflection;

namespace _5Task
{
    internal class AccessControl
    {
        public static void CheckAccess(object employee, int requiredLevel)
        {
            Type type = employee.GetType();
            var attribute = type.GetCustomAttribute<AccessLevelAttribute>();

            if (attribute == null)
            {
                Console.WriteLine($"{type.Name} не має рівня доступу. Доступ заборонено.");
                return;
            }

            Console.Write($"{type.Name} (рівень {attribute.Level}) → ");

            if (attribute.Level >= requiredLevel)
                Console.WriteLine("Доступ дозволено.");
            else
                Console.WriteLine("Доступ заборонено.");
        }
    }
}
