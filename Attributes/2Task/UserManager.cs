namespace _2Task
{
    internal class UserManager
    {
        // Метод застарів але дозволено викликати (буде попередження)
        [Obsolete("CreateUserByName is obsolete. Use CreateUser instead.")]
        public void CreateUserByName(string name)
        {
            Console.WriteLine($"User '{name}' created (old method).");
        }

        // Метод заборонений до використання (буде помилка компіляції)
        [Obsolete("DeleteUserById is deprecated. Use DeleteUser(Guid id) instead.", true)]
        public void DeleteUserById(int id)
        {
            Console.WriteLine($"User with ID {id} deleted (old method).");
        }

        // Правильний метод для створення користувача
        public void CreateUser(string name, string email)
        {
            Console.WriteLine($"User '{name}' with email '{email}' created (new method).");
        }

        // Правильний метод для видалення користувача
        public void DeleteUser(Guid id)
        {
            Console.WriteLine($"User with GUID {id} deleted.");
        }
    }
}
