namespace _2Task
{
    internal class MyCollection
    {
        //один замовник - багато категорій
        private readonly Dictionary<string, HashSet<string>> customerForCategories
        = new Dictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);

        //одна категорія - багато замовників
        private readonly Dictionary<string, HashSet<string>> categoryForCustomers
            = new Dictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);

        // додати покупця з категорією товару
        public void Add(string customer, string category)
        {
            if (string.IsNullOrWhiteSpace(customer))
                throw new ArgumentException("Customer name cannot be empty.", nameof(customer));
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Category cannot be empty.", nameof(category));

            // Додаємо категорію покупцю
            if (!customerForCategories.TryGetValue(customer, out var categories))
            {
                categories = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                customerForCategories[customer] = categories;
            }
            categories.Add(category);

            // Додаємо покупця до категорії
            if (!categoryForCustomers.TryGetValue(category, out var customers))
            {
                customers = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                categoryForCustomers[category] = customers;
            }
            customers.Add(customer);
        }

        // взяти категорії за покупцем
        public IEnumerable<string> GetCategoriesByCustomer(string customer)
        {
            if (customerForCategories.TryGetValue(customer, out var categories))
                return categories;
            return Enumerable.Empty<string>();//порожній список
        }

        // взяти покупців за категорією
        public IEnumerable<string> GetCustomersByCategory(string category)
        {
            if (categoryForCustomers.TryGetValue(category, out var customers))
                return customers;
            return Enumerable.Empty<string>();
        }
    }
}
