namespace GuessNumber.Config.Interfaces
{
    public interface IConfigurator
    {
        Structs.Configuration Configuration { get; }

        void Configure(int minVal, int maxVal, int tries);
    }
}
