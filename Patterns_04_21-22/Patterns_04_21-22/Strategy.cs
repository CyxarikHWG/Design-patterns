using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_04_21_22
{
    interface IUnit
    {
        void Walk();
        void Fly();
    }

    class Unit
    {
        protected IUnit Hero;

        public Unit(IUnit hero)
        {
            Hero = hero;
        }

        public void UnitInfo()
        {
            Hero.Fly();
            Hero.Walk();
            Console.WriteLine(new string('-', 25));
        }
    }

    // По сути, у нас есть две категории персонажей: которые не могут летать,
    // но могут использовать магию для полета, и те, которые могут летать самостоятельно.
    // Можно было бы свести эти два типа к Фабричному методу, но мне лень :)

    class Orc : IUnit
    {
        public bool isMagician { get; set; }

        public Orc(bool _isMagician)
        {
            this.isMagician = _isMagician;
        }

        public void Fly()
        {
            if (isMagician)
                Console.WriteLine($"{this.GetType().Name} can use magic to fly");
            else
                Console.WriteLine($"{this.GetType().Name} can't fly");
        }

        public void Walk()
        {
            Console.WriteLine($"{this.GetType().Name} can walk");
        }
    }

    class Troll : IUnit
    {
        public bool isMagician { get; set; }

        public Troll(bool _isMagician)
        {
            this.isMagician = _isMagician;
        }

        public void Fly()
        {
            if (isMagician)
                Console.WriteLine($"{this.GetType().Name} can use magic to fly");
            else
                Console.WriteLine($"{this.GetType().Name} can't fly");
        }

        public void Walk()
        {
            Console.WriteLine($"{this.GetType().Name} can walk");
        }
    }

    class Pegasus : IUnit
    {
        public Pegasus() { }

        public void Fly()
        {
            Console.WriteLine($"{this.GetType().Name} can fly");
        }

        public void Walk()
        {
            Console.WriteLine($"{this.GetType().Name} can walk");
        }
    }

    class Elf : IUnit
    {
        public bool isMagician { get; set; }

        public Elf(bool _isMagician)
        {
            this.isMagician = _isMagician;
        }

        public void Fly()
        {
            if (isMagician)
                Console.WriteLine($"{this.GetType().Name} can use magic to fly");
            else
                Console.WriteLine($"{this.GetType().Name} can't fly");
        }

        public void Walk()
        {
            Console.WriteLine($"{this.GetType().Name} can walk");
        }
    }

    class Vampire : IUnit
    {
        public Vampire() { }

        public void Fly()
        {
            Console.WriteLine($"{this.GetType().Name} can fly");
        }

        public void Walk()
        {
            Console.WriteLine($"{this.GetType().Name} can walk");
        }
    }

    class Harpy : IUnit
    {
        public Harpy() { }

        public void Fly()
        {
            Console.WriteLine($"{this.GetType().Name} can fly");
        }

        public void Walk()
        {
            Console.WriteLine($"{this.GetType().Name} can walk");
        }
    }
}
