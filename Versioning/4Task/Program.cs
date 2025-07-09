using System.Text;

namespace _4Task
{
    //Реалізуйте шаблон NVI у власній ієрархії успадкування.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Animal myCat = new Cat();
            Animal myDog = new Dog();

            Console.Write("Кіт каже: ");
            myCat.Speak();

            Console.Write("\nПес каже: ");
            myDog.Speak();
        }
    }
}
