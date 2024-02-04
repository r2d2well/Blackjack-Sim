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
        //Creates all the varables that we will be needing later on
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
            //Initializes all the components
            DrawPlayerCard();
            DrawDealerCard();
            //Draws a player card then draws a dealer card
            DrawPlayerCard();
            playerTotal = AIAgent.GetPlayerTotal(player);
            SetPlayerTotalLabel();
            if (playerTotal == 21)
            {
                PlayerWins();
            }
            //Draws the player's 2nd card then checks if they win

            DrawDealerCard();
            dealerTotal = DealerAgent.GetDealerTotal(dealer);
            SetDealerTotalLabel();
            if (dealerTotal == 21)
            {
                DealerWins();
            }
            //Does the same thing but for the dealer
        }

        private void SetPlayerTotalLabel()
        {
            if (PlayerTotalLabel.InvokeRequired)
            {
                PlayerTotalLabel.Invoke(new MethodInvoker(delegate
                {
                    PlayerTotalLabel.Text = "Total: " + AIAgent.GetPlayerTotal(player);
                }));
                //Invokes if it is nessacary other's wise just change the text directly
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
                //Operates the same as the SetPlayerTotalLabel
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
            //Gets the top card from the deck stack then add it to the player's deck and call MakeCard method
        }

        public void DrawDealerCard()
        {
            Card card = deck.Pop();
            dealer.Add(card);
            MakeCards(50 + (150 * dealer.Count), 10, card, false);
            //Same as DrawPlayerCard but for dealer
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
            //Draws card and update the player's total
            if (playerTotal > 21)
            {
                DealerWins();
                //If player busts dealer wins
            }
            else if (playerTotal == 21)
            {
                PlayerWins();
                //If player hits blackjack they win
            }
            else
            {
                DealerTurn();
                //Otherwise it is the dealer's turn
            }
        }

        public void PlayerStay()
        {
            if (dealerTotal < 17)
            {
                DealerTurn();
                PlayerStay();
                //If dealer is under 17 then he hits and recursivly calls the method
            }
            else if (dealerTotal > playerTotal)
            {
                DealerWins();
                //If dealer is higher then player then the dealer wins
            }
            else if (dealerTotal == playerTotal)
            {
                Tie();
                //If they have the same value then it is a tie
            }
            else
            {
                PlayerWins();
                //If player has higher value they win
            }
        }

        private void DealerWins()
        {
            WinnerForm form = new WinnerForm("Dealer Wins!");
            form.ShowDialog();
            NewGame();
            //Creates a new WinnerForm with apporaite text then starts a new game
        }

        private void PlayerWins()
        {
            WinnerForm form = new WinnerForm("Player Wins!");
            form.ShowDialog();
            NewGame();
            //Creates a new WinnerForm with apporaite text then starts a new game
        }

        private void Tie()
        {
            WinnerForm form = new WinnerForm("Tie!");
            form.ShowDialog();
            NewGame();
            //Creates a new WinnerForm with apporaite text then starts a new game
        }

        private void DealerTurn()
        {
            if (DealerAgent.DealerMove(dealer))
            {
                DrawDealerCard();
            }
            SetDealerTotalLabel();
            dealerTotal = DealerAgent.GetDealerTotal(dealer);
            //Hits or stays depending on what the DealerAgent says
            if (dealerTotal > 21)
            {
                PlayerWins();
            }
            else if (dealerTotal == 21)
            {
                DealerWins();
            }
            //Checks if dealer bust or got a blackjack
        }

        private void NewGame()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(this.NewGame));
                //Calls an Invoke if required
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
                //Removes all the picture box in the player and dealer lists
                deck = Program.ShuffleDeck();
                player = new List<Card>();
                dealer = new List<Card>();
                //Shuffles the deck and resets the player and dealers hand
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
                //Draws cards and check wins like in the constructor
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
            //Creates a new picture box and set the image in it to a png found in a local directory
            //coordinating with the card being draw

            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Size = new Size(125, 182);
            pictureBox.Location = new Point(x, y);
            //Sets the picturebox's sizemode, size, and location
            if (player)
            {
                playerList.Add(pictureBox);
            }
            else
            {
                dealerList.Add(pictureBox);
            }
            ///adds the picturebox to either playerList or dealerList depenting on who drew the card
            if (this.InvokeRequired)
            {
                Invoke((MethodInvoker)delegate ()
                {
                    this.Controls.Add(pictureBox);
                });
                //Adds the picturebox to the controls and Invokes if it is required
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
                    //Loops whenever the AIenabled boolean is true
                    if (AIAgent.DetermineMove(playerTotal, dealerTotal))
                    {
                        PlayerHit();
                        Thread.Sleep(2000);
                        //If the AIAgent decided to hit then calls the PlayerHit method then sleep for 2 seconds
                    }
                    else
                    {
                        PlayerStay();
                        Thread.Sleep(2000);
                        //If the AIAgent decided to stay then calls the PlayerStay method then sleep for 2 seconds
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
                //Enables the AIthread and Starts it if nessacary
            }
            else
            {
                HitButton.Visible = true;
                StayButton.Visible = true;
                AIButton.Text = "Enable AI";

                AIenabled = false;
                //temporarly disables the AIThread
            }
        }
    }
}