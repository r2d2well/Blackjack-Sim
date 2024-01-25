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
            label.Text = x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
