namespace _2Task
{
    /*Створіть колекцію, до якої можна додавати покупців та категорію придбаної ними продукції. 
     * З колекції можна отримувати категорії товарів, які купив покупець або за категорією визначити покупців.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            var collection = new MyCollection();

            collection.Add("User1", "Books");
            collection.Add("User1", "Toys");
            collection.Add("User2", "Books");
            collection.Add("User2", "Cars");
            collection.Add("User3", "Books");

            Console.WriteLine("Categories for user User1:");
            foreach (var category in collection.GetCategoriesByCustomer("User1"))
            {
                Console.WriteLine($"+{category}");
            }

            Console.WriteLine("\nCustomers, who buy category Books:");
            foreach (var customer in collection.GetCustomersByCategory("Books"))
            {
                Console.WriteLine($"+{customer}");
            }
        }
    }
}
