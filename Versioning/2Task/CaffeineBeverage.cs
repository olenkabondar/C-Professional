using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Task
{
    abstract class CaffeineBeverage
    {
        // Template Method
        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            AddCondiments();
        }

        private void BoilWater()
        {
            Console.WriteLine("Кип'ятимо воду.");
        }

        private void PourInCup()
        {
            Console.WriteLine("Наливаємо в чашку воду.");
        }

        // Абстрактні кроки реалізовані в дочірних класах
        protected abstract void Brew();
        protected abstract void AddCondiments();
    }
    class Tea : CaffeineBeverage
    {
        protected override void Brew()
        {
            Console.WriteLine("Додаємо чайний пакетик до чашки.");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Додаємо лимон.");
        }
    }

    class Coffee : CaffeineBeverage
    {
        protected override void Brew()
        {
            Console.WriteLine("Насипаємо до чашки мелену каву.");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Додаємо молоко та цукор.");
        }
    }
}
