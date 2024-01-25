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
            HitButton = new Button();
            StayButton = new Button();
            PlayerTotalLabel = new Label();
            DealerTotalLabel = new Label();
            SuspendLayout();
            // 
            // HitButton
            // 
            HitButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            HitButton.Location = new Point(548, 477);
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
            StayButton.Location = new Point(307, 477);
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
            PlayerTotalLabel.Location = new Point(470, 455);
            PlayerTotalLabel.Name = "PlayerTotalLabel";
            PlayerTotalLabel.Size = new Size(56, 20);
            PlayerTotalLabel.TabIndex = 3;
            PlayerTotalLabel.Text = "Total =";
            // 
            // DealerTotalLabel
            // 
            DealerTotalLabel.AutoSize = true;
            DealerTotalLabel.Location = new Point(470, 215);
            DealerTotalLabel.Name = "DealerTotalLabel";
            DealerTotalLabel.Size = new Size(56, 20);
            DealerTotalLabel.TabIndex = 6;
            DealerTotalLabel.Text = "Total =";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(991, 550);
            Controls.Add(DealerTotalLabel);
            Controls.Add(PlayerTotalLabel);
            Controls.Add(StayButton);
            Controls.Add(HitButton);
            Name = "MainForm";
            Text = "Table";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button HitButton;
        private Button StayButton;
        private Label PlayerTotalLabel;
        private Label DealerTotalLabel;
    }
}