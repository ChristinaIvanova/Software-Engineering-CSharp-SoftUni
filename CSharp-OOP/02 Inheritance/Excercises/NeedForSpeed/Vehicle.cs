namespace NeedForSpeed
{
    public class Vehicle
    {
        public const double DefaultConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.Fuel = fuel;
            this.HorsePower = HorsePower;
        }

        public double Fuel { get; set; }

        public int HorsePower { get; set; }

        public virtual double FuelConsumption => DefaultConsumption;
        
        public virtual void Drive(double kilometers)
        {
            var neededFuel = kilometers * this.FuelConsumption;

            if (this.Fuel >= neededFuel)
            {
                this.Fuel -= kilometers * this.FuelConsumption;
            }
        }
    }
}
