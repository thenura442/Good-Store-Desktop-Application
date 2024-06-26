using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Good_Store_Project
{
    public partial class UserDataBase : Form
    {
        public UserDataBase()
        {
            InitializeComponent();
        }
        Methods mtd = new Methods();
        private void UserDataBase_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mtd.UF();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=K:\Databases\SQL Server Database File\UserDatabase\UserDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            string Qry = "SELECT * FROM UserInformation";

            SqlDataAdapter Data = new SqlDataAdapter(Qry, connect);
            DataSet da = new DataSet();

            Data.Fill(da, "UserInformation");
            UserDataGrid.DataSource = da.Tables["UserInformation"];

        }

        private void UserDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
