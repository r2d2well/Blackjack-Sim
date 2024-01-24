namespace BlackJack_Simulator
{
    public partial class MainForm : Form
    {
        private Stack<Card> deck;
        private List<Card> player;
        private List<Card> dealer;
        private byte playerTotal;
        private byte dealerTotal;
        private bool gameOver;
        public MainForm(Stack<Card> deck)
        {
            gameOver = false;
            player = new List<Card>();
            dealer = new List<Card>();
            this.deck = deck;
            InitializeComponent();
            DrawCard(player);
            DrawCard(dealer);
            DrawCard(player);
            playerTotal = GetPlayerTotal(player);
            if (playerTotal == 21)
            {
                PlayerWins();
            }
            DrawCard(dealer);
            dealerTotal = DealerAgent.GetDealerTotal(dealer);
            if (dealerTotal == 21)
            {
                DealerWins();
            }
            SetLabelText(PlayerDeck, player);
            SetLabelText(DealerDeck, dealer);
        }

        private void SetLabelText(Label label, List<Card> list)
        {
            string text = "";
            foreach (Card x in list)
            {
                text += (x.value + " ");
            }
            label.Text = text;
            SetPlayerTotalLabel();
            SetDealerTotalLabel();
        }
        private void SetPlayerTotalLabel()
        {
            PlayerTotalLabel.Text = "Total: " + GetPlayerTotal(player);
        }

        private void SetDealerTotalLabel()
        {
            DealerTotalLabel.Text = "Total: " + DealerAgent.GetDealerTotal(dealer);
        }

        private byte GetPlayerTotal(List<Card> list)
        {
            byte total = 0;
            foreach (Card x in list)
            {
                try
                {
                    total += byte.Parse(x.value);
                }
                catch (Exception e)
                {
                    switch (x.value)
                    {
                        case "A":
                            total += 11;
                            break;

                        case "J":
                        case "Q":
                        case "K":
                            total += 10;
                            break;
                    }
                }
            }
            if (total > 21)
            {
                total = 0;
                foreach (Card x in list)
                {
                    try
                    {
                        total += byte.Parse(x.value);
                    }
                    catch (Exception e)
                    {
                        switch (x.value)
                        {
                            case "A":
                                total++;
                                break;

                            case "J":
                            case "Q":
                            case "K":
                                total += 10;
                                break;
                        }
                    }
                }
            }
            return total;
        }
        private void DrawCard(List<Card> list)
        {
            list.Add(deck.Pop());
        }

        private void HitButton_Click(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                DrawCard(player);
                SetLabelText(PlayerDeck, player);
                playerTotal = GetPlayerTotal(player);
                if (playerTotal > 21)
                {
                    DealerWins();
                }
                else if (playerTotal == 21)
                {
                    PlayerWins();
                }
                else
                {
                    DealerTurn();
                }
            }
            else
            {
                NewGame();
            }
        }

        private void StayButton_Click(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                if (dealerTotal < 17)
                {
                    DealerTurn();
                    StayButton_Click(sender, e);
                }
                else if (!gameOver)
                {
                    if (dealerTotal > playerTotal)
                    {
                        DealerWins();
                    }
                    else if (dealerTotal == playerTotal)
                    {
                        Tie();
                    }
                    else
                    {
                        PlayerWins();
                    }
                }
            }
            else
            {
                NewGame();
            }
        }

        private void DealerWins()
        {
            WinnerLabel.Text = "Dealer Wins";
            gameOver = true;
        }
        private void PlayerWins()
        {
            WinnerLabel.Text = "Player Wins";
            gameOver = true;
        }

        private void Tie()
        {
            WinnerLabel.Text = "Tie";
            gameOver = true;
        }

        private void DealerTurn()
        {
            DealerAgent.DealerMove(deck, dealer);
            SetLabelText(DealerDeck, dealer);
            dealerTotal = DealerAgent.GetDealerTotal(dealer);
            if (dealerTotal > 21)
            {
                PlayerWins();
            }
            else if (dealerTotal == 21)
            {
                DealerWins();
            }
        }

        private void NewGame()
        {
            deck = Program.ShuffleDeck();
            player = new List<Card>();
            dealer = new List<Card>();
            DrawCard(player);
            DrawCard(dealer);
            DrawCard(player);
            playerTotal = GetPlayerTotal(player);
            if (playerTotal == 21)
            {
                PlayerWins();
            }
            DrawCard(dealer);
            dealerTotal = DealerAgent.GetDealerTotal(dealer);
            if (dealerTotal == 21)
            {
                DealerWins();
            }
            SetLabelText(PlayerDeck, player);
            SetLabelText(DealerDeck, dealer);
            WinnerLabel.Text = "";
            gameOver = false;
        }
    }
}