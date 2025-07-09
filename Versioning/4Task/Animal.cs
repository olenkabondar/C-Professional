using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Task
{
    abstract class Animal
    {
        public void Speak()
        {
            DoSpeak();  
        }

        protected abstract void DoSpeak();
    }
    class Cat : Animal
    {
        protected override void DoSpeak()
        {
            Console.Write("Мяу!");
        }
    }

    class Dog : Animal
    {
        protected override void DoSpeak()
        {
            Console.Write("Гав!");
        }
    }
}
