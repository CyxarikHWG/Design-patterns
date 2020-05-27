using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_04_21_22
{
    public enum EBody { Sedan, hatchback, Universal }
    public enum EEngine { Petrol, Diesel, Gas }
    public enum EWheels { Summer, Winter, AllSeason }

    public interface IBuilder
    {
        void BuildBody(EBody body);
        void BuildEngine(EEngine engine);
        void BuildWheels(EWheels wheels);
    }

    class ConcreteBuilder : IBuilder    // Конкретная машина
    {
        private Product _product = new Product();

        public ConcreteBuilder()
        {
            this.Reset();
        }

        public void Reset()     // Может одновременно производиться только один
        {
            this._product = new Product();
        }

        public void BuildBody(EBody body)
        {
            this._product.AddBody(body);
        }

        public void BuildEngine(EEngine engine)
        {
            this._product.AddEngine(engine);
        }

        public void BuildWheels(EWheels wheels)
        {
            this._product.AddWheels(wheels);
        }

        public Product GetProduct()     // Можно получить доступ к классу Product
        {
            Product result = this._product;

            this.Reset();

            return result;
        }
    }

    class Product   // Какая-то абстрактная машина
    {
        private List<object> _parts = new List<object>();

        public void AddBody(EBody body)
        {
            this._parts.Add(body);
        }

        public void AddEngine(EEngine engine)
        {
            this._parts.Add(engine);
        }

        public void AddWheels(EWheels wheels)
        {
            this._parts.Add(wheels);
        }
        
        public string Info()
        {
            string info = "";
            foreach (var i in _parts)
            {
                info += $"{i.ToString()}\n";
            }
            info += "\n";

            return info;
        }
    }

    class Director  // Создан для производства готовых шаблонов машин
    {
        private IBuilder _builder;

        public IBuilder Builder
        {
            set { _builder = value; }
        }

        public void buildSummerCar()
        {
            this._builder.BuildBody(EBody.hatchback);
            this._builder.BuildEngine(EEngine.Gas);
            this._builder.BuildWheels(EWheels.Summer);
        }

        public void buildWinterCar()
        {
            this._builder.BuildBody(EBody.Sedan);
            this._builder.BuildEngine(EEngine.Petrol);
            this._builder.BuildWheels(EWheels.Winter);
        }
    }
}
