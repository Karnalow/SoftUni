using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catch_The_Button
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Peder si");
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Random rand = new Random();
            var maxWidth = this.ClientSize.Width - Button.ClientSize.Width;
            var maxHeight = this.ClientSize.Height - Button.ClientSize.Height;
            this.Button.Location = new Point(rand.Next(maxWidth), rand.Next(maxHeight));
        }
    }
}
