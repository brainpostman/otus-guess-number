using GuessNumber.Config;
using GuessNumber.ConsoleControl;
using GuessNumber.ConsoleControl.Interfaces;
using GuessNumber.Game;
using GuessNumber.NumberGeneration;

namespace GuessNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new Configurator();
            var numGen = new NumberGenerator(config);
            var gameState = new GameState(config);
            Console.WriteLine("Шутки от Петросяна ставить? Y\\N");
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey().Key;
                    int currentLineCursor = Console.CursorTop;
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, currentLineCursor);
                    if (key == ConsoleKey.Y)
                    {
                        var consoleControler = new FunnyConsoleController(gameState, config);
                        var gameController = new GameController(consoleControler, numGen, gameState, config);
                        gameController.StartApp();
                        break;
                    } else if (key == ConsoleKey.N)
                    {
                        var consoleControler = new ConsoleController(gameState, config);
                        var gameController = new GameController(consoleControler, numGen, gameState, config);
                        gameController.StartApp();
                        break;
                    }
                }             
            }
          

        }
    }
}
