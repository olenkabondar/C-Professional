using System.Collections;
using System.Text;

namespace _3Task
{
    /*Декількома способами створіть колекцію, в якій можна зберігати тільки цілі та речові значення, 
     * на кшталт «рахунок підприємства – доступна сума» відповідно.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            #region Dictionary <int, double>
            Console.WriteLine("\n Dictionary <int, double>");
            var accountsDictionary = new Dictionary<int, double>();

            accountsDictionary.Add(1, 1500.75);
            accountsDictionary[6] = 250.00;
            accountsDictionary[12] = 36250.00;

            foreach (var account in accountsDictionary) 
            {
                Console.WriteLine($"Рахунок - {account.Key}, Сума - {account.Value}");
            }

            #endregion

            #region SortedDictionary<int, double>
            Console.WriteLine("\n SortedDictionary<int, double>");
            var accountsSortedDictionary = new SortedDictionary<int, double>();

            accountsSortedDictionary[12] = 1500.75;
            accountsSortedDictionary[6] = 250.00;
            accountsSortedDictionary[1] = 25634;

            foreach (var acc in accountsSortedDictionary)
            {
                Console.WriteLine($"Рахунок: {acc.Key}, Сума: {acc.Value}");
            }
            #endregion

            #region List<(int Account, double Amount)>
            Console.WriteLine("\n List<(int Account, double Amount)>");
            var accounts = new List<(int Account, double Amount)>
                {
                    (1, 1500.75),
                    (6, 250.00),
                    (12, 1500)
                };

            // Доступ за індексом
            foreach (var (account, amount) in accounts)
            {
                Console.WriteLine($"Рахунок: {account}, Сума: {amount}");
            }
            #endregion

            #region Hashtable
            Console.WriteLine("\n Hashtable()");
            var accountsHashtable = new Hashtable();
            accountsHashtable.Add(1, 1500.75);
            accountsHashtable[6] = 250.00;
            accountsHashtable[12] = 36250.00;

            foreach (var account in accountsHashtable)
            {
                Console.WriteLine($"{account}");
            }
            #endregion
        }
    }
}
