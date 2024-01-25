namespace BlackJack_Simulator
{
    internal static class Program
    {
        public static Stack<Card> ShuffleDeck()
        {
            List<Card> list = new List<Card>();
            string[] array = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king", "ace"};
            for (byte i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    list.Add(new Card(i, array[j]));
                }
            }
            list = list.OrderBy(x => Random.Shared.Next()).ToList();
            Stack<Card> deck = new Stack<Card>();
            foreach (Card x in list)
            {
                deck.Push(x);
            }
            return deck;
        }
        ///  The main entry point for the application.
        [STAThread]
        static void Main()
        {
            Console.WriteLine(ShuffleDeck());
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(ShuffleDeck()));
        }
    }
}
