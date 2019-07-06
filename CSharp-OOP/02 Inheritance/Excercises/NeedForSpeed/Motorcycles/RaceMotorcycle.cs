namespace NeedForSpeed.Motorcycles
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double DefaultConsumption = 8;

        public RaceMotorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => DefaultConsumption;
    }
}
