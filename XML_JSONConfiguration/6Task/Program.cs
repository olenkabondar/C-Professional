using System.Text;
using System.Xml;

namespace _6Task
{
    /*Створіть .xml файл, який би відповідав наступним вимогам:
    • ім'я файлу: TelephoneBook.xml
    • кореневий елемент: “MyContacts”
    • тег “Contact”, і в ньому має бути записано ім'я контакту та атрибут “TelephoneNumber” зі значенням номера телефону.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            XmlDocument xml = new XmlDocument();
            XmlDeclaration xmlDeclaration = xml.CreateXmlDeclaration("1.0", "utf-8", null);
            xml.AppendChild(xmlDeclaration);

            // Створюємо кореневий елемент MyContacts
            XmlElement root = xml.CreateElement("MyContacts");
            xml.AppendChild(root);

            // Додаємо кілька контактів
            AddContact(xml, root, "Олена", "+380635621478");
            AddContact(xml, root, "Сергій", "+380445896745");
            AddContact(xml, root, "Олексій", "+380678512396");
            AddContact(xml, root, "Микита", "0967451234");

            xml.Save("TelephoneBook.xml");
            Console.WriteLine("Файл TelephoneBook.xml створено.");
        }

        static void AddContact(XmlDocument xml, XmlElement root, string name, string phone)
        {
            XmlElement contact = xml.CreateElement("Contact");
            contact.SetAttribute("TelephoneNumber", phone);
            contact.InnerText = name;
            root.AppendChild(contact);
        }
    }
}
