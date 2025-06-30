namespace _2Task
{
    /*Створіть клас і застосуйте до його методів атрибут Obsolete спочатку у формі, 
     * що просто виводить попередження, а потім у формі, що перешкоджає компіляції.
     * Продемонструйте роботу атрибута з прикладу виклику даних методів.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            var manager = new UserManager();

            //Буде попередження, але зкомпілюється
            manager.CreateUserByName("Olena");

            //Новий метод працюючий без зауважень
            manager.CreateUser("Olena", "olena@example.com");

            //Помилку компіляції та написання — метод застарілий і заборонений
            //manager.DeleteUserById(123);

            //Новий метод працюючий без помилок
            manager.DeleteUser(Guid.NewGuid());
        }
    }
}
