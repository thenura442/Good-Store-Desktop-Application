using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Good_Store_Project
{
    public partial class ItemDatabase : Form
    {
        public ItemDatabase()
        {
            InitializeComponent();
        }
        Methods mtd = new Methods();

        private void ItemDatabase_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            ControlBox = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=K:\Databases\SQL Server Database File\ItemDatabase\ItemDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            string Qry = "SELECT * FROM tbitem";

            SqlDataAdapter Data = new SqlDataAdapter(Qry, connect);
            DataSet da = new DataSet();

            Data.Fill(da, "Itemdb");
            ItemDataGrid.DataSource = da.Tables["Itemdb"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mtd.IF();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
