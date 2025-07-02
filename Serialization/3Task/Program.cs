using _2Task;
using System.Xml.Serialization;

namespace _3Task
{
    /*Створіть нову програму, в якій виконайте десеріалізацію об'єкта з попереднього прикладу. Відобразіть стан об'єкта на екрані.*/
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializerElement = new XmlSerializer(typeof(PersonElement));
            using (FileStream fs = new FileStream("PersonElement.xml", FileMode.Open))
            {
                PersonElement personElement = (PersonElement)serializerElement.Deserialize(fs);
                Console.WriteLine($"(Deserealize like element) Name: {personElement.Name}, " +
                    $"LastName: {personElement.LastName}, Status: {personElement.Status}, Age: {personElement.Age}");
            }

            XmlSerializer serializerAttribute = new XmlSerializer(typeof(PersonAttribute));
            using (FileStream fs = new FileStream("PersonAttribute.xml", FileMode.Open))
            {
                PersonAttribute personAttribute = (PersonAttribute)serializerAttribute.Deserialize(fs);
                Console.WriteLine($"(Deserealize like attribute) Name: {personAttribute.Name}, " +
                    $"LastName: {personAttribute.LastName}, Status: {personAttribute.Status}, Age: {personAttribute.Age}");
            }
        }
    }
}
