using System.Text;

namespace _5Task
{
    /*Створіть атрибут користувача AccessLevelAttribute, який дозволяє визначити рівень доступу користувача до системи. 
     * Сформуйте склад співробітників певної фірми як набору класів, наприклад, Manager, Programmer, Director. 
     * За допомогою атрибута AccessLevelAttribute розподіліть рівні доступу персоналу та відобразіть на екрані реакцію системи на спробу
     * кожного співробітника отримати доступ до захищеної секції.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            var employees = new object[]
               {
                    new Employees.Manager(),
                    new Employees.QAEngineer(),
                    new Employees.Developer(),
                    new Employees.Director()
               };

            int requiredAccessLevel = 3;

            Console.WriteLine($"Захищена секція вимагає рівень доступу ≥ {requiredAccessLevel}\n");

            foreach (var employee in employees)
            {
                AccessControl.CheckAccess(employee, requiredAccessLevel);
            }
        }
    }
}
