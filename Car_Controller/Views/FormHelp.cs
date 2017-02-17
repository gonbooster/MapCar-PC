using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Controller.View
{
    public partial class FormHelp : Form
    {
        private Form main=null;
        public FormHelp()
        {
            InitializeComponent();
        }
        public FormHelp(Form f)
        {
            main = f;
            InitializeComponent();
        }
        private void FormHelp_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Enabled = true;
        }

        private void FormHelp_Load(object sender, EventArgs e)
        {
            this.Location = main.Location;
            this.Left += main.ClientSize.Width / 2 - this.Width / 2;
            this.Top += main.ClientSize.Height / 2 - this.Height / 2;
        }
    }
}
