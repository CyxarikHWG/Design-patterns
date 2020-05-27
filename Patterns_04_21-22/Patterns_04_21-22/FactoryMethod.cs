using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_04_21_22
{
    // J, I, O, L, Z, T, S
    // C вашего позволения я не буду описывать 14 одинаковых классов и ограничусь
    // тремя creator'ами и тремя фигурами

    abstract class FigureCreator
    {
        private List<Figure> figureList = new List<Figure>() { };

        abstract public Figure Create();

        public void Add(List<Figure> list)
        {
            foreach (var i in list)
            {
                figureList.Add(i);
            }
        }

        public Figure RandomFigure()
        {
            Random rnd = new Random();
            int randIndex = rnd.Next(0, figureList.Count);
            return figureList[randIndex];
        }
    }

    class FigureCreator_J : FigureCreator
    {
        public override Figure Create() { return new Figure_J(); }
    }

    class FigureCreator_I : FigureCreator
    {
        public override Figure Create() { return new Figure_I(); }
    }

    class FigureCreator_Z : FigureCreator
    {
        public override Figure Create() { return new Figure_Z(); }
    }

    // Создан для гибкости при инициализации
    abstract class Figure
    { }

    class Figure_J : Figure
    {
        public Figure_J() { Console.WriteLine("J"); }
    }

    class Figure_I : Figure
    {
        public Figure_I() { Console.WriteLine("I"); }
    }

    class Figure_Z : Figure
    {
        public Figure_Z() { Console.WriteLine("Z"); }
    }
}
