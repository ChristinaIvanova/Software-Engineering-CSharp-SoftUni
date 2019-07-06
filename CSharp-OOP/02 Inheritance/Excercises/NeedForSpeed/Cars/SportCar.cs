namespace NeedForSpeed.Cars
{
    public class SportCar : Car
    {
        private const double DefaultConsumption = 10;

        public SportCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => DefaultConsumption;
    }
}
