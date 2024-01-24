namespace BlackJack_Simulator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PlayerDeck = new Label();
            HitButton = new Button();
            StayButton = new Button();
            PlayerTotalLabel = new Label();
            WinnerLabel = new Label();
            DealerDeck = new Label();
            DealerTotalLabel = new Label();
            SuspendLayout();
            // 
            // PlayerDeck
            // 
            PlayerDeck.AutoSize = true;
            PlayerDeck.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PlayerDeck.Location = new Point(339, 284);
            PlayerDeck.Name = "PlayerDeck";
            PlayerDeck.Size = new Size(113, 28);
            PlayerDeck.TabIndex = 0;
            PlayerDeck.Text = "Player Deck";
            // 
            // HitButton
            // 
            HitButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            HitButton.Location = new Point(461, 375);
            HitButton.Name = "HitButton";
            HitButton.Size = new Size(142, 63);
            HitButton.TabIndex = 1;
            HitButton.Text = "Hit";
            HitButton.UseVisualStyleBackColor = true;
            HitButton.Click += HitButton_Click;
            // 
            // StayButton
            // 
            StayButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            StayButton.Location = new Point(192, 375);
            StayButton.Name = "StayButton";
            StayButton.Size = new Size(142, 63);
            StayButton.TabIndex = 2;
            StayButton.Text = "Stay";
            StayButton.UseVisualStyleBackColor = true;
            StayButton.Click += StayButton_Click;
            // 
            // PlayerTotalLabel
            // 
            PlayerTotalLabel.AutoSize = true;
            PlayerTotalLabel.Location = new Point(339, 344);
            PlayerTotalLabel.Name = "PlayerTotalLabel";
            PlayerTotalLabel.Size = new Size(56, 20);
            PlayerTotalLabel.TabIndex = 3;
            PlayerTotalLabel.Text = "Total =";
            // 
            // WinnerLabel
            // 
            WinnerLabel.AutoSize = true;
            WinnerLabel.Location = new Point(345, 203);
            WinnerLabel.Name = "WinnerLabel";
            WinnerLabel.Size = new Size(0, 20);
            WinnerLabel.TabIndex = 4;
            // 
            // DealerDeck
            // 
            DealerDeck.AutoSize = true;
            DealerDeck.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DealerDeck.Location = new Point(339, 90);
            DealerDeck.Name = "DealerDeck";
            DealerDeck.Size = new Size(116, 28);
            DealerDeck.TabIndex = 5;
            DealerDeck.Text = "Dealer Deck";
            // 
            // DealerTotalLabel
            // 
            DealerTotalLabel.AutoSize = true;
            DealerTotalLabel.Location = new Point(339, 146);
            DealerTotalLabel.Name = "DealerTotalLabel";
            DealerTotalLabel.Size = new Size(56, 20);
            DealerTotalLabel.TabIndex = 6;
            DealerTotalLabel.Text = "Total =";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DealerTotalLabel);
            Controls.Add(DealerDeck);
            Controls.Add(WinnerLabel);
            Controls.Add(PlayerTotalLabel);
            Controls.Add(StayButton);
            Controls.Add(HitButton);
            Controls.Add(PlayerDeck);
            Name = "MainForm";
            Text = "Table";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label PlayerDeck;
        private Button HitButton;
        private Button StayButton;
        private Label PlayerTotalLabel;
        private Label WinnerLabel;
        private Label DealerDeck;
        private Label DealerTotalLabel;
    }
}