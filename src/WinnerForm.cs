using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack_Simulator
{
    public partial class WinnerForm : Form
    {
        public WinnerForm(string x)
        {
            InitializeComponent();
            this.Text = x;
            label.Text = x;
            //Sets the form's text and the label text to be equal to the string it is given
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            //When button 1 is clicked the form will close itself
        }
    }
}
