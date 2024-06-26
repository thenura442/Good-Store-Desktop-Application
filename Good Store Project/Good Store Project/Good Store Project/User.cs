using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Good_Store_Project
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
            lbluname.Text = Login.username;
            if (Login.id == "199942452345")
            {
                btnuser.Enabled = true;
            }
            else
            {
                btnuser.Enabled = false;
                btnuser.BackColor = Color.LightSlateGray;
            }
        }
        Methods mtd = new Methods();

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void User_Load(object sender, EventArgs e)
        {

        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            mtd.H();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Save button code 
            string UserID = txtID.Text;
            string FristName = txtfname.Text;
            string LastName = txtlname.Text;
            string PhoneNumber = txtphone.Text;
            string Address = txtaddress.Text;
            string UserName = txtuname.Text;
            string Password = txtpass.Text;
            string DateOfBirth = txtbirth.Text;
            string Sex;

            if (m.Checked)
            {
                Sex = "Male";
            }
            else
            {
                Sex = "Female";
            }


            if (txtID.Text == "" || txtfname.Text == "" || txtlname.Text == "" || txtphone.Text == "" || txtaddress.Text == "" || txtuname.Text == "" || txtpass.Text == "")
            {
                //MessageBox.Show("Please fill all the fields")
                txtWarning.Text = "*Please fill all the fields";
            }
            else
            {
                string msg = "Data Saved Successfully";
                string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=K:\Databases\SQL Server Database File\UserDatabase\UserDatabase.mdf;Integrated Security=True;Connect Timeout=30";
                string qry = "INSERT INTO UserInformation values('" + UserID + "','" + FristName + "','" + LastName + "','" + PhoneNumber + "','" + Address + "','" + DateOfBirth + "','" + Sex + "','" + UserName + "','" + Password + "')";
                mtd.sqlcon(qry, constring, msg);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Delect button Code
            string UserID = txtID.Text;

            if (txtID.Text == "")
            {
                //MessageBox.Show("Please Enter the User ID Number");
                txtWarning.Text = "*Please Enter the User ID Number";

            }
            else
            {
                string msg = "Data Deleted Successfully";
                string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=K:\Databases\SQL Server Database File\UserDatabase\UserDatabase.mdf;Integrated Security=True;Connect Timeout=30";
                string qry = "DELETE FROM UserInformation WHERE UserID ='" + UserID + "'";
                mtd.sqlcon(qry, constring, msg);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Clean all button code
            txtID.Text = "";
            txtfname.Text = "";
            txtlname.Text = "";
            txtphone.Text = "";
            txtaddress.Text = "";
            txtuname.Text = "";
            txtpass.Text = "";
            txtbirth.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Update button code
            string UserID = txtID.Text;
            string FristName = txtfname.Text;
            string LastName = txtlname.Text;
            string PhoneNumber = txtphone.Text;
            string Address = txtaddress.Text;
            string UserName = txtuname.Text;
            string Password = txtpass.Text;
            string DateOfBirth = txtbirth.Text;

            if (txtID.Text == "")
            {
                //MessageBox.Show("Please Enter Your ID Number and Click 'Find'");
                txtWarning.Text = "*Please Enter Your ID Number and Click 'Find'";
            }
            else
            {
                string msg = "Data Updated Successfully";
                string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=K:\Databases\SQL Server Database File\UserDatabase\UserDatabase.mdf;Integrated Security=True;Connect Timeout=30";
                string qry = "UPDATE UserInformation SET FirstName='" + txtfname.Text + "',LastName='" + txtlname.Text + "',PhoneNumber='" + txtphone.Text + "',Address='" + txtaddress.Text + "',UserName='" + txtuname.Text + "', Password='" + txtpass.Text + "' WHERE UserID = '" + UserID + "'";
                mtd.sqlcon(qry, constring, msg);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Find button code
            string UserID = txtID.Text;
            string FristName = txtfname.Text;
            string LastName = txtlname.Text;
            string PhoneNumber = txtphone.Text;
            string Address = txtaddress.Text;
            string UserName = txtuname.Text;
            string Password = txtpass.Text;
            string DateOfBirth = txtbirth.Text;

            if (txtID.Text == "")
            {
                //MessageBox.Show("Please Enter the User ID Number");
                txtWarning.Text = "*Please Enter the User ID Number";

            }
            else
            {
                SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=K:\Databases\SQL Server Database File\UserDatabase\UserDatabase.mdf;Integrated Security=True;Connect Timeout=30");
                string Qry = "SELECT FirstName,LastName,PhoneNumber,Address,UserName,Password,DateOfBirth From UserInformation WHERE UserID= " + UserID + "";

                SqlCommand cmd = new SqlCommand(Qry, connect);

                try
                {
                    connect.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    sdr.Read();

                    txtfname.Text = sdr["FirstName"].ToString();
                    txtlname.Text = sdr["LastName"].ToString();
                    txtaddress.Text = sdr["Address"].ToString();
                    txtuname.Text = sdr["UserName"].ToString();
                    txtpass.Text = sdr["Password"].ToString();
                    txtbirth.Text = sdr["DateOfBirth"].ToString();
                    txtphone.Text = sdr["PhoneNumber"].ToString();
                }
                catch (SqlException se)
                {
                    MessageBox.Show("" + se);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            mtd.UD();
            this.Hide();



        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            mtd.L();
            this.Hide();
        }

        private void btnitem_Click(object sender, EventArgs e)
        {
            mtd.IF();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mtd.CF();
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

        private void btnuser_Click(object sender, EventArgs e)
        {

        }
    }
}

