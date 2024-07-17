using GuessNumber.Config.Interfaces;
using GuessNumber.Game.Interfaces;

namespace GuessNumber.Game
{
    public class GameState(IConfigurator configurator) : IGameState
    {
        public int Number { get; private set; }

        public int TriesLeft { get; private set; }

        public int Guess { get; set; }

        public void ResetGame(int number)
        {
            Number = number;
            TriesLeft = configurator.Configuration.Tries;
        }

        public void SpendTry()
        {
            TriesLeft--;
        }
    }
}
