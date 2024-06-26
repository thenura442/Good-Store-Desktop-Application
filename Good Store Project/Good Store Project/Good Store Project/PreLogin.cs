using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Good_Store_Project
{
    public partial class PreLogin : Form
    {
        public PreLogin()
        {
            InitializeComponent();
        }
        Methods mtd = new Methods();
        private void button2_Click(object sender, EventArgs e)
        {

            mtd.L();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void PreLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
