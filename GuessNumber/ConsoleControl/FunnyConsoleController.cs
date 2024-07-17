using GuessNumber.Config.Interfaces;
using GuessNumber.Game.Interfaces;

namespace GuessNumber.ConsoleControl
{
    public class FunnyConsoleController : ConsoleController
    {
        public FunnyConsoleController(IGameState gameState, IConfigurator configurator) : base(gameState, configurator)
        {
            greet = "Это какие люди! Ты же тот самый чел! Ну проходи.";
            changeConfig = "Если сложностей в жизни и так много нажми \"C\".";
            incorrectConfig = "Ну написано же что вводить, ну что ты так. Давай с начала.";
            toStart = "Если не боишься, жми \"S\". Не замануха, отвечаю.";
            toEnd = "Угадывать числа научились, можно и в блэк-джек, жми \"Q\".";
            enterNumber = "Введи число, любое число...";
            win = "Угадал! Чистый скилл, никакой удачи.";
            loss = "Мда, я бы на твоём месте закрыл бы программу. Не угадал.";
            goodbye = "Устал? Сдаёшься? А я тут буду, запускай если скучно будет.";
            tryAgain = "Не наигрался? Тогда жми \"S\".";
            maxVal = "Введи максимальную границу для загадывания. Если меньше 1000 - трус: ";
            minVal = "Введи минимальную границу для загадывания. Ну или размер своего... ааа не важно: ";
            tries = "Введи число пыток, эээ, попыток: ";
        }
    }
}
