using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Good_Store_Project
{
    public partial class CustomerDatagridview : Form
    {
        public CustomerDatagridview()
        {
            InitializeComponent();
        }

        Methods mtd = new Methods();
        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=K:\Databases\SQL Server Database File\CustomerDatabase\CustomerDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            string Qry = "SELECT * FROM CustomerInformation";

            SqlDataAdapter Data = new SqlDataAdapter(Qry, connect);
            DataSet da = new DataSet();

            Data.Fill(da, "CustomerInformation");
            DataGridView1.DataSource = da.Tables["CustomerInformation"];
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerInformation CustomerReg = new CustomerInformation(); //View Database Button 
            CustomerReg.Show();
            this.Hide();
        }

        private void CustomerDatagridview_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
