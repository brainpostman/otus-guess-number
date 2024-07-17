namespace GuessNumber.Config.Structs
{
    public struct Configuration
    {
        public int MinVal { get; private set; }

        public int MaxVal { get; private set; }

        public int Tries { get; private set; }

        public Configuration(int minVal, int maxVal, int tries)
        {
            MinVal = minVal;
            MaxVal = maxVal;
            Tries = tries;
        }
    }
}
