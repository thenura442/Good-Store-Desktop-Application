using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Good_Store_Project
{
    public partial class Login : Form
    {
        
        public static string username;
        public static string id;
        public string password;

        public Login()
        {
            InitializeComponent();
        }
        Methods mtd = new Methods();
        private void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtuserid.Text) && txtuserid.Text.Contains("[a-zA-Z]+") == false && txtuserid.Text.Length > 0)
                {
                    id = txtuserid.Text;

                    password = txtpassword.Text;
                    SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=K:\Databases\SQL Server Database File\UserDatabase\UserDatabase.mdf;Integrated Security=True;Connect Timeout=30");

                    string qry= "SELECT UserName FROM UserInformation WHERE UserID = '" + id + "' and Password = '"+ password +"'";

                    SqlCommand cmd1 = new SqlCommand(qry, connect);

                    try
                    {
                        connect.Open();

                        SqlDataReader sdr = cmd1.ExecuteReader();

                        if (sdr.Read())
                        {
                            try
                            {
                                username = sdr["UserName"].ToString();
                                txtuserid.Text = "";
                                txtpassword.Text = "";
                                mtd.H();
                                this.Hide();

                            }
                            catch (Exception blank)
                            {
                                MessageBox.Show(blank.ToString());

                            }
                        }
                        else
                        {
                            lblwarning.Text = "*Please Recheck Username and Password3";
                        }




                    }
                    catch (SqlException se)
                    {
                        MessageBox.Show(se.ToString());
                    }
                }
                else
                {
                    lblwarning.Text = "*Please Recheck Username and Password1";
                }
            }
            catch(Exception d)
            {
                MessageBox.Show(d.ToString());
            }
            
        }

        private void Login_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            mtd.PL();
            this.Hide();
        }
    }
}
