using GuessNumber.Config.Interfaces;
using GuessNumber.NumberGeneration.Interfaces;

namespace GuessNumber.NumberGeneration
{
    public class NumberGenerator(IConfigurator configurator) : INumberGenerator
    {
        private Random random = new Random();

        public int GetNumber()
        {
            var configuration = configurator.Configuration;

            return random.Next(configuration.MinVal, configuration.MaxVal);
        }
    }
}
