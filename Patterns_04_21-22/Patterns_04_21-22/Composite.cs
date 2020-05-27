using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_04_21_22
{
    enum ERace { Squad, Ork, Elf, Minotaur, Kentavr, Ciklop, Dragon, Girda, Knight }

    abstract class Component
    {
        protected ERace Name { get; set; }

        public Component(ERace Name)
        {
            this.Name = Name;
        }
        // Как вариант, можно было бы воспользоваться интерфейсом, тогда 
        // нереализованные методы у солдата отпали бы
        public abstract void Add(List<Component> Soldiers);
        public abstract void Remove(Component foo);
        public abstract void Info();
    }

    class Soldier : Component
    {
        public Soldier(ERace Name) : base(Name) { }

        public override void Add(List<Component> Soldiers)
        {
            throw new ArgumentException("Soldier can't be a group");
        }

        public override void Remove(Component foo)
        {
            throw new ArgumentException("Soldier can't be a group");
        }

        public override void Info()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }

    class Group : Component
    {
        public List<Component> GroupContent;

        public Group(ERace Name) : base(Name)
        {
            this.Name = ERace.Squad;
            GroupContent = new List<Component>() { };
        }

        public override void Add(List<Component> Soldiers)
        {
            foreach (var i in Soldiers)
            {
                this.GroupContent.Add(i);
            }
        }

        public override void Remove(Component foo)
        {
            GroupContent.Remove(foo);
        }

        public override void Info()
        {
            Group group;
            Soldier soldier;
            Console.WriteLine(this.ToString());
            foreach (var i in GroupContent)
            {
                group = i as Group;
                if (group != null)
                {
                    i.Info();
                    break;
                }

                soldier = i as Soldier;
                if (soldier != null)
                {
                    i.Info();
                }
            }
        }

        public override string ToString()
        {
            return $"\t{Name}";
        }
    }
}
