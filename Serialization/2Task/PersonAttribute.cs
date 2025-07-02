using System.Xml.Serialization;

namespace _2Task
{
    [Serializable]
    public class PersonAttribute
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string LastName { get; set; }
        [XmlAttribute]
        public string Status { get; set; }

        [XmlAttribute]
        public int Age { get; set; }
    }
}
