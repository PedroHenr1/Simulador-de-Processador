using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormEquipe : Form
    {
        public FormEquipe()
        {
            InitializeComponent();
        }

        private void pedroNome_MouseEnter(object sender, EventArgs e)
        {
            painelNome.Height = pedroNome.Height;
            painelNome.Top = pedroNome.Top;
            pedroNome.BackColor = Color.AntiqueWhite;
        }

        private void pedroNome_MouseLeave(object sender, EventArgs e)
        {
            pedroNome.BackColor = Color.Transparent;
        }
    }
}
