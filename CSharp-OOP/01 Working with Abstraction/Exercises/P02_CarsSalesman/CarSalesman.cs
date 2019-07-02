using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
    public class CarSalesman
    {
        private CarFactory carFactory;
        private EngineFactory engineFactory;
        private List<Car> cars;
        private List<Engine> engines;

        public CarSalesman(CarFactory carFactory, EngineFactory engineFactory)
        {
            this.carFactory = carFactory;
            this.engineFactory = engineFactory;
            this.cars = new List<Car>();
            this.engines = new List<Engine>();
        }

        public void AddEngine(string[] parameters)
        {
            Engine engine = this.engineFactory.Create(parameters);

            this.engines.Add(engine);
        }

        public void AddCar(string[] parameters)
        {
            Car car = this.carFactory.Create(parameters, this.engines);

            this.cars.Add(car);
        }

        public List<Car> GetCars()
        {
            return this.cars;
        }
    }
}
