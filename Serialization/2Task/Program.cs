using System.Xml.Serialization;

namespace _2Task
{
    /*Створіть клас, який підтримує серіалізацію. Виконайте серіалізацію цього об'єкта у форматі XML. 
     * Спочатку використовуйте формат за промовчанням, а потім змініть його таким чином, щоб значення полів збереглися як атрибути елементів XML.*/
    internal class Program
    {
        static void Main(string[] args)
        {

            //Serialized like element
            PersonElement person = new PersonElement { Name = "Olena", LastName = "Bondar", Status = "Student", Age = 34 };

            XmlSerializer serializer = new XmlSerializer(typeof(PersonElement));

            using (FileStream fs = new FileStream("PersonElement.xml", FileMode.Create))
            {
                serializer.Serialize(fs, person);
            }

            Console.WriteLine("Serialized like element.");

            //Serialized like attribute
            PersonAttribute personAttribute = new PersonAttribute { Name = "Olena", LastName = "Bondar", Status = "Student", Age = 34 };

            XmlSerializer serializerAtribute = new XmlSerializer(typeof(PersonAttribute));

            using (FileStream fs = new FileStream("PersonAttribute.xml", FileMode.Create))
            {
                serializerAtribute.Serialize(fs, personAttribute);
            }

            Console.WriteLine("Serialized like attribute.");
        }
    }
}
