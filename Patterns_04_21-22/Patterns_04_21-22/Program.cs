using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_04_21_22
{
    class Program
    {
        static void CompositeMethod()
        {
            Component MainSquad = new Group(ERace.Squad);

            Component Soldier1 = new Soldier(ERace.Dragon);
            Component Squad1 = new Group(ERace.Squad);
            MainSquad.Add(new List<Component> { Soldier1, Squad1 });

            Component Soldier2 = new Soldier(ERace.Knight);
            Component Soldier3 = new Soldier(ERace.Elf);
            Component Squad2 = new Group(ERace.Squad);
            Squad1.Add(new List<Component> { Soldier2, Soldier3, Squad2 });

            Component Soldier4 = new Soldier(ERace.Minotaur);
            Component Soldier5 = new Soldier(ERace.Minotaur);
            Squad2.Add(new List<Component> { Soldier4, Soldier5 });

            MainSquad.Info();
        }

        static void Task1()
        {
            CompositeMethod();
        }

        static void BuilderMethod()
        {
            Director director = new Director();
            ConcreteBuilder builder = new ConcreteBuilder();
            director.Builder = builder;

            director.buildSummerCar();
            Console.WriteLine(builder.GetProduct().Info());

            director.buildWinterCar();
            Console.WriteLine(builder.GetProduct().Info());

            builder.BuildBody(EBody.Universal);
            builder.BuildEngine(EEngine.Diesel);
            builder.BuildWheels(EWheels.AllSeason);
            Console.WriteLine(builder.GetProduct().Info());
        }

        static void FactoryMethod()
        {
            FigureCreator creator = new FigureCreator_I();
            Figure I = creator.Create();

            creator = new FigureCreator_J();
            Figure J = creator.Create();

            creator = new FigureCreator_Z();
            Figure Z = creator.Create();

            creator.Add(new List<Figure>() { I, J, Z});
            Console.WriteLine(creator.RandomFigure());
        }

        static void Task2()
        {
            BuilderMethod();
            FactoryMethod();
        }

        static void StrategyMethod()
        {
            Unit SMorc = new Unit(new Orc(false));
            SMorc.UnitInfo();

            Unit Pegas = new Unit(new Pegasus());
            Pegas.UnitInfo();

            Unit Troll = new Unit(new Troll(true));
            Troll.UnitInfo();
        }

        static void ObserverMethod()
        {
            Newspaper foo = new Newspaper();

            Observer bar1 = new Observer();
            foo.Follow(bar1);

            Observer bar2 = new Observer();
            foo.Follow(bar2);

            foo.Notify();

            foo.Unfollow(bar2);

            foo.Notify();
        }

        static void StateMethod()
        {
            Context context = new Context(new NotPassed());
            context.Give();
            context.Give();
            context.Take();
            context.Take();
        }

        static void Task3()
        {
            StrategyMethod();
            ObserverMethod();
            StateMethod();
        }

        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
        }
    }
}
