namespace _03Ferrari
{
    public interface IFerrari
    {
        string Model { get; }

        string Driver { get; }

        string PushBrakes();

        string Gas();
    }
}