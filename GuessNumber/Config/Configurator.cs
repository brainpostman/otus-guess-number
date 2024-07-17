using GuessNumber.Config.Interfaces;
using GuessNumber.Config.Structs;

namespace GuessNumber.Config
{
    public class Configurator : IConfigurator
    {
        public Configuration Configuration { get; private set; }

        public Configurator()
        {
            Configuration = new Configuration(1, 10, 4);
        }

        public void Configure(int minVal, int maxVal, int tries)
        {
            Configuration = new Configuration(minVal, maxVal, tries);
        }
    }
}
