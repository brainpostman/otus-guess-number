namespace GuessNumber.ConsoleControl.Interfaces
{
    public interface IConsoleController
    {
        void PrintGreeting();

        void PrintToStart();

        void PrintToEnd();

        void PrintEnterNumber();

        void PrintNumIsLower();

        void PrintNumIsHigher();

        void PrintWin();

        void PrintLoss();

        void PrintGoodbye();

        void PrintTryAgain();

        void PrintToReconfigure();

        void PrintIncorrectConfigs();

        void PrintMaxVal();

        void PrintMinVal();

        void PrintTries();

        int ReadNumber(Action action);

        ConsoleKey ReadKey();
    }
}
