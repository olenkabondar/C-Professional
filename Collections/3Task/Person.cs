namespace _3Task
{
    internal class Person
    {
        public string PersonName { get; set; }
        public int BirthYear { get; set; }
        public List<Person> Childrens = new List<Person>();

        public Person(string namePerson, int birthYear)
        {
            PersonName = namePerson;
            BirthYear = birthYear;
        }

        public void AddChild(Person children)
        {
            Childrens.Add(children);
        }

        public void RemoveChild(string name)
        {
            Childrens.RemoveAll(c => c.PersonName == name);
        }

        //для пошуку глибини родового дерева
        public IEnumerable<Person> GetChild()
        {
            foreach (var children in Childrens)
            {
                yield return children;
                foreach (var child in children.GetChild())
                { 
                    yield return child; 
                }
            }
        }

        public override string ToString()
        {
            return $"{PersonName} {BirthYear}р.н";
        }
    }
}
