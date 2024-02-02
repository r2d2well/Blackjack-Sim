using System.Windows.Forms;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace BlackJack_Simulator
{
    public partial class MainForm : Form
    {
        private Stack<Card> deck;
        private List<Card> player;
        private List<Card> dealer;
        private List<PictureBox> playerList;
        private List<PictureBox> dealerList;
        private Thread AIthread;
        private byte playerTotal;
        private byte dealerTotal;
        private bool AIenabled;
        public MainForm(Stack<Card> deck)
        {
            player = new List<Card>();
            dealer = new List<Card>();
            playerList = new List<PictureBox>();
            dealerList = new List<PictureBox>();
            AIenabled = false;
            AIthread = new Thread(new ThreadStart(this.ThreadTask));
            AIthread.IsBackground = true;
            this.deck = deck;
            InitializeComponent();
            DrawPlayerCard();
            DrawDealerCard();
            DrawPlayerCard();
            playerTotal = AIAgent.GetPlayerTotal(player);
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
            if (PlayerTotalLabel.InvokeRequired)
            {
                PlayerTotalLabel.Invoke(new MethodInvoker(delegate
                {
                    PlayerTotalLabel.Text = "Total: " + AIAgent.GetPlayerTotal(player);
                }));
            }
            else
            {
                PlayerTotalLabel.Text = "Total: " + AIAgent.GetPlayerTotal(player);
            }
        }

        private void SetDealerTotalLabel()
        {
            if (DealerTotalLabel.InvokeRequired)
            {
                DealerTotalLabel.Invoke(new MethodInvoker(delegate
                {
                    DealerTotalLabel.Text = "Total: " + DealerAgent.GetDealerTotal(dealer);
                }));
            }
            else
            {
                DealerTotalLabel.Text = "Total: " + DealerAgent.GetDealerTotal(dealer);
            }
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
            playerTotal = AIAgent.GetPlayerTotal(player);
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
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.NewGame));
            }
            else
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
                playerTotal = AIAgent.GetPlayerTotal(player);
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
        }

        private void MakeCards(int x, int y, Card card, bool player)
        {
            PictureBox pictureBox = new PictureBox();
            string filePath = "Cards\\";
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
            if (this.InvokeRequired)
            {
                Invoke((MethodInvoker)delegate ()
                {
                    this.Controls.Add(pictureBox);
                });
            }
            else
            {
                this.Controls.Add(pictureBox);
            }
        }

        private void ThreadTask()
        {
            while (true)
            {
                while (AIenabled)
                {
                    if (AIAgent.DetermineMove(playerTotal, dealerTotal))
                    {
                        PlayerHit();
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        PlayerStay();
                        Thread.Sleep(2000);
                    }
                }
            }
        }

        private void AIButton_Click(object sender, EventArgs e)
        {
            if (!AIenabled)
            {
                HitButton.Visible = false;
                StayButton.Visible = false;
                AIButton.Text = "Disable AI";

                if (!AIthread.IsAlive)
                {
                    AIthread.Start();
                }

                AIenabled = true;
            }
            else
            {
                HitButton.Visible = true;
                StayButton.Visible = true;
                AIButton.Text = "Enable AI";

                AIenabled = false;
            }
        }
    }
}