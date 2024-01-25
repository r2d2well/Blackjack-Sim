using System.Windows.Forms;

namespace BlackJack_Simulator
{
    public partial class MainForm : Form
    {
        private Stack<Card> deck;
        private List<Card> player;
        private List<Card> dealer;
        private List<PictureBox> playerList;
        private List<PictureBox> dealerList;
        private byte playerTotal;
        private byte dealerTotal;
        public MainForm(Stack<Card> deck)
        {
            player = new List<Card>();
            dealer = new List<Card>();
            playerList = new List<PictureBox>();
            dealerList = new List<PictureBox>();
            this.deck = deck;
            InitializeComponent();
            DrawPlayerCard();
            DrawDealerCard();
            DrawPlayerCard();
            playerTotal = GetPlayerTotal(player);
            SetPlayerTotalLabel();
            if (playerTotal == 21)
            {
                PlayerWins();
            }

            DrawDealerCard();
            dealerTotal = DealerAgent.GetDealerTotal(dealer);
            SetDealerTotalLabel();
            if (dealerTotal == 21)
            {
                DealerWins();
            }
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
                        case "ace":
                            total += 11;
                            break;

                        case "jack":
                        case "queen":
                        case "king":
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
                            case "ace":
                                total++;
                                break;

                            case "jack":
                            case "queen":
                            case "king":
                                total += 10;
                                break;
                        }
                    }
                }
            }
            return total;
        }
        private void DrawPlayerCard()
        {
            Card card = deck.Pop();
            player.Add(card);
            MakeCards(50 + (150 * player.Count), 250, card, true);
        }

        public void DrawDealerCard()
        {
            Card card = deck.Pop();
            dealer.Add(card);
            MakeCards(50 + (150 * dealer.Count), 10, card, false);
        }

        private void HitButton_Click(object sender, EventArgs e)
        {
            PlayerHit();
        }

        private void StayButton_Click(object sender, EventArgs e)
        {
            PlayerStay();
        }

        public void PlayerHit()
        {
            DrawPlayerCard();
            SetPlayerTotalLabel();
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

        public void PlayerStay()
        {
            if (dealerTotal < 17)
            {
                DealerTurn();
                PlayerStay();
            }
            else if (dealerTotal > playerTotal)
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

        private void DealerWins()
        {
            WinnerForm form = new WinnerForm("Dealer Wins!");
            form.ShowDialog();
            NewGame();
        }
        private void PlayerWins()
        {
            WinnerForm form = new WinnerForm("Player Wins!");
            form.ShowDialog();
            NewGame();
        }

        private void Tie()
        {
            WinnerForm form = new WinnerForm("Tie!");
            form.ShowDialog();
            NewGame();
        }

        private void DealerTurn()
        {
            if (DealerAgent.DealerMove(dealer))
            {
                DrawDealerCard();
            }
            SetDealerTotalLabel();
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
            foreach (PictureBox box in playerList)
            {
                this.Controls.Remove(box);
            }
            foreach (PictureBox box in dealerList)
            {
                this.Controls.Remove(box);
            }
            deck = Program.ShuffleDeck();
            player = new List<Card>();
            dealer = new List<Card>();
            DrawPlayerCard();
            DrawDealerCard();
            DrawPlayerCard();
            playerTotal = GetPlayerTotal(player);
            if (playerTotal == 21)
            {
                PlayerWins();
            }
            SetPlayerTotalLabel();
            DrawDealerCard();
            dealerTotal = DealerAgent.GetDealerTotal(dealer);
            SetDealerTotalLabel();
            if (dealerTotal == 21)
            {
                DealerWins();
            }
        }

        private void MakeCards(int x, int y, Card card, bool player)
        {
            PictureBox pictureBox = new PictureBox();
            string filePath = "C:\\Users\\r2d2w\\source\\repos\\BlackJack Simulator\\BlackJack Simulator\\bin\\Debug\\net7.0-windows\\Cards\\";
            filePath += card.value;
            switch (card.set)
            {
                case 0:
                    filePath += "_of_clubs.png";
                    break;

                case 1:
                    filePath += "_of_diamonds.png";
                    break;

                case 2:
                    filePath += "_of_hearts.png";
                    break;

                case 3:
                    filePath += "_of_spades.png";
                    break;
            }
            Bitmap bitmap = new Bitmap(filePath);
            pictureBox.Image = (Image)bitmap;

            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Size = new Size(125, 182);
            pictureBox.Location = new Point(x, y);
            if (player)
            {
                playerList.Add(pictureBox);
            }
            else
            {
                dealerList.Add(pictureBox);
            }
            this.Controls.Add(pictureBox);
        }
    }
}