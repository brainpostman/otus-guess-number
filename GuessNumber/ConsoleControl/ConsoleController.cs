using GuessNumber.Config.Interfaces;
using GuessNumber.ConsoleControl.Interfaces;
using GuessNumber.Game.Interfaces;

namespace GuessNumber.ConsoleControl
{
    public class ConsoleController : IConsoleController
    {
        private IGameState _gameState;
        private IConfigurator _configurator;
        protected string greet = "Добро пожаловать в \"Угадай число\"!";
        protected string changeConfig = "Чтобы изменить настройки, нажмите \"C\".";
        protected string incorrectConfig = "Введены некорректные настройки. Попробуйте ещё раз.";
        protected string toStart = "Чтобы начать игру, нажмите \"S\".";
        protected string toEnd = "Чтобы выйти из игры, нажмите \"Q\".";
        protected string enterNumber = "Введите число";
        protected string win = "Вы угадали!";
        protected string loss = "Вы не угадали!";
        protected string goodbye = "Спасибо за игру! Пока!";
        protected string tryAgain = "Чтобы сыграть ещё раз, нажмите \"S\".";
        protected string maxVal = "Введите нижнюю границу загадываемого числа: ";
        protected string minVal = "Введите верхнюю границу загадываемого числа: ";
        protected string tries = "Введите количество попыток: ";

        public ConsoleController(IGameState gameState, IConfigurator configurator)
        {
            _gameState = gameState;
            _configurator = configurator;
        }

        public void PrintGreeting()
        {
            Console.WriteLine(greet);
        }

        public void PrintNumIsHigher()
        {
            Console.WriteLine($"Загаданное число больше, чем {_gameState.Guess}. Оставшееся число попыток: {_gameState.TriesLeft}"); ;
        }

        public void PrintNumIsLower()
        {
            Console.WriteLine($"Загаданное число меньше, чем {_gameState.Guess}. Оставшееся число попыток: {_gameState.TriesLeft}");
        }

        public void PrintToReconfigure()
        {
            Console.WriteLine(changeConfig);
        }

        public void PrintIncorrectConfigs()
        {
            Console.WriteLine(incorrectConfig);
        }

        public void PrintMaxVal()
        {
            Console.Write(maxVal);
        }

        public void PrintMinVal()
        {
            Console.Write(minVal);
        }

        public void PrintTries()
        {
            Console.Write(tries);
        }

        public void PrintToStart()
        {
            Console.WriteLine(toStart);
        }

        public void PrintToEnd()
        {
            Console.WriteLine(toEnd);
        }

        public void PrintEnterNumber()
        {
            Console.Write($"{enterNumber} между {_configurator.Configuration.MinVal} и {_configurator.Configuration.MaxVal}: ");
        }

        public void PrintTryAgain()
        {
            Console.WriteLine(tryAgain);
        }

        public void PrintLoss()
        {
            Console.WriteLine($"{loss} Правильный ответ: {_gameState.Number}.");
        }

        public void PrintWin()
        {
            Console.WriteLine(win);
        }

        public void PrintGoodbye()
        {
            Console.WriteLine(goodbye);
        }

        public int ReadNumber(Action action)
        {
            int num;
            while (true)
            {
                action();
                string? input = Console.ReadLine();
                if (input != null && int.TryParse(input, out num))
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("Введенное значение не является числом, попробуйте ещё раз.");
                }
            }
        }

        public ConsoleKey ReadKey()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey().Key;
                    int currentLineCursor = Console.CursorTop;
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, currentLineCursor);
                    return key;
                }
            }
        }
    }
}
