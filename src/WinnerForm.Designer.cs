namespace BlackJack_Simulator
{
    partial class WinnerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label.Location = new Point(153, 49);
            label.Name = "label";
            label.Size = new Size(130, 54);
            label.TabIndex = 0;
            label.Text = "label1";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(190, 118);
            button1.Name = "button1";
            button1.Size = new Size(120, 52);
            button1.TabIndex = 1;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // WinnerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 182);
            Controls.Add(button1);
            Controls.Add(label);
            Name = "WinnerForm";
            Text = "WinnerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label;
        private Button button1;
    }
}
