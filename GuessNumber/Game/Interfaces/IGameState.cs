namespace GuessNumber.Game.Interfaces
{
    public interface IGameState
    {
        int Number { get; }

        int TriesLeft { get; }

        int Guess { get; set; }

        void ResetGame(int number);

        void SpendTry();
    }
}
