using GuessNumber.Config.Interfaces;
using GuessNumber.ConsoleControl.Interfaces;
using GuessNumber.Game.Interfaces;
using GuessNumber.NumberGeneration.Interfaces;

namespace GuessNumber.Game
{
    public class GameController(IConsoleController consoleController, INumberGenerator numberGenerator, IGameState gameState, IConfigurator configurator)
    {
        public void StartApp()
        {
            consoleController.PrintGreeting();
            ShowOptions();
        }

        private void StartGame()
        {
            var config = configurator.Configuration;
            var number = numberGenerator.GetNumber();
            gameState.ResetGame(number);
            while (true)
            {
                gameState.Guess = consoleController.ReadNumber(() => consoleController.PrintEnterNumber());
                CheckGuess();
            }
        }

        private void CheckGuess()
        {
            bool lower = true;
            if (gameState.Guess == gameState.Number)
            {
                consoleController.PrintWin();
                ShowOptions(true);
                return;
            }
            else if (gameState.Guess > gameState.Number)
            {
                gameState.SpendTry();
            }
            else if (gameState.Guess < gameState.Number)
            {
                lower = false;
                gameState.SpendTry();
            }
            if (gameState.TriesLeft == 0)
            {
                consoleController.PrintLoss();
                ShowOptions(true);
                return;
            }
            else if (lower)
            {
                consoleController.PrintNumIsLower();
            }
            else
            {
                consoleController.PrintNumIsHigher();
            }
        }

        private void ShowOptions(bool interlude = false)
        {
            consoleController.PrintToReconfigure();
            if (interlude)
            {
                consoleController.PrintTryAgain();
            }
            else
            {
                consoleController.PrintToStart();
            }
            consoleController.PrintToEnd();
            while (true)
            {
                var key = consoleController.ReadKey();
                switch (key)
                {
                    case ConsoleKey.C:
                        Reconfigure();
                        break;
                    case ConsoleKey.S:
                        StartGame();
                        break;
                    case ConsoleKey.Q:
                        consoleController.PrintGoodbye();
                        Environment.Exit(0);
                        return;
                }
            }
        }

        private void Reconfigure()
        {
            int minVal, maxVal, tries;
            while (true)
            {
                minVal = consoleController.ReadNumber(consoleController.PrintMinVal);
                maxVal = consoleController.ReadNumber(consoleController.PrintMaxVal);
                if (minVal > maxVal || maxVal < minVal)
                {
                    consoleController.PrintIncorrectConfigs();
                    continue;
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                tries = consoleController.ReadNumber(consoleController.PrintTries);
                if (tries <= 0)
                {
                    consoleController.PrintIncorrectConfigs();
                    continue;
                }
                else
                {
                    break;
                }
            }
            configurator.Configure(minVal, maxVal, tries);
            ShowOptions();
        }
    }
}
