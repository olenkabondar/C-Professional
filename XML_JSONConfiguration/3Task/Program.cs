using System.Text;
using System.Xml;

namespace _3Task
{
    /*З файлу TelephoneBook.xml (файл повинен був бути створений у процесі виконання додаткового завдання) виведіть на екран лише номери телефонів.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            
            string filePath = @"C://STUDY//С#Professional//HWProffesional//XML_JSONConfiguration//6Task//bin//Debug//net8.0//TelephoneBook.xml";

            XmlDocument xml = new XmlDocument();

            try
            {
                xml.Load(filePath);

                XmlNodeList contacts = xml.SelectNodes("/MyContacts/Contact");

                if (contacts != null)
                {
                    Console.WriteLine("Номери телефонів:");

                    foreach (XmlNode contact in contacts)
                    {
                        if (contact.Attributes != null)
                        {
                            var phoneAttr = contact.Attributes["TelephoneNumber"];
                            if (phoneAttr != null)
                            {
                                Console.WriteLine(phoneAttr.Value);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Контактів не знайдено.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при читанні файлу: {ex.Message}");
            }       
        }
    }
}
