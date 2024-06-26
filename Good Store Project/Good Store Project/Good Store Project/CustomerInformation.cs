using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Controls;

namespace Good_Store_Project
{
    public partial class CustomerInformation : Form
    {

        public CustomerInformation()
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

        private void button3_Click(object sender, EventArgs e)
        {
            //Delect button Code
            string Customer_Phone_Number = txtCphone.Text;

            if (txtCphone.Text == "")
            {
                //MessageBox.Show("Please Enter the Customer Phone Number");
                txtWarning.Text = "*Please Enter the Customer Phone Number";

            }
            else
            {
                string msg = "Data Deleted Successfully";
                string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=K:\Databases\SQL Server Database File\CustomerDatabase\CustomerDatabase.mdf;Integrated Security=True;Connect Timeout=30";
                string qry = "DELETE FROM CustomerInformation WHERE Customer_Phone_Number  ='" + Customer_Phone_Number + "'"; ;
                mtd.sqlcon(qry, constring, msg);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Save button code 

            string Customer_Phone_Number = txtCphone.Text;
            string Customer_FirstName = txtCfname.Text;
            string Customer_LastName = txtClname.Text;
            string Customer_NIC = txtCNIC.Text;
            string Customer_DOF = txtCdof.Text;
            string Customer_Address = txtCaddress.Text;
            string Customer_Email = txtCemail.Text;
            string Customer_Sex;

            if (m.Checked)
            {
                Customer_Sex = "Male";
            }
            else
            {
                Customer_Sex = "Female";
            }


            if (txtCphone.Text == "" || txtCfname.Text == "" || txtClname.Text == "" || txtCNIC.Text == "" || txtCdof.Text == "" || txtCaddress.Text == "" || txtCemail.Text == "")
            {
                //MessageBox.Show("Please fill all the fields");
                txtWarning.Text = "*Please fill all the fields";
            }
            else
            {
                string qry = "INSERT INTO CustomerInformation values('" + Customer_Phone_Number + "','" + Customer_FirstName + "','" + Customer_LastName + "','" + Customer_NIC + "','" + Customer_DOF + "','" + Customer_Address + "','" + Customer_Sex + "','" + Customer_Email + "')";
                string msg = "Data Saved Successfully";
                string constring = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = K:\Databases\SQL Server Database File\CustomerDatabase\CustomerDatabase.mdf; Integrated Security = True; Connect Timeout = 30";

                mtd.sqlcon(qry, constring, msg);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Customer_Phone_Number = txtCphone.Text;
            string Customer_FirstName = txtCfname.Text;
            string Customer_LastName = txtClname.Text;
            string Customer_NIC = txtCNIC.Text;
            string Customer_DOF = txtCdof.Text;
            string Customer_Address = txtCaddress.Text;
            string Customer_Email = txtCemail.Text;

            if (txtCphone.Text == "")
            {
                //MessageBox.Show("Please Enter Customer Phone Number and Click 'Find'");
                txtWarning.Text = "*Please Enter Customer Phone Number and Click 'Find'";
            }
            else
            {
                string msg = "Data Updated Successfully";
                string constring = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = K:\Databases\SQL Server Database File\CustomerDatabase\CustomerDatabase.mdf; Integrated Security = True; Connect Timeout = 30";
                string qry = "UPDATE CustomerInformation SET Customer_FirstName='" + txtCfname.Text + "',Customer_LastName='" + txtClname.Text + "',Customer_Email='" + txtCemail.Text + "',Customer_Address='" + txtCaddress.Text + "',Customer_NIC='" + txtCNIC.Text + "', Customer_DOF='" + txtCdof.Text + "' WHERE Customer_Phone_Number = '" + Customer_Phone_Number + "'";
                mtd.sqlcon(qry,constring,msg);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Clean all button code
            txtCaddress.Text = "";
            txtCdof.Text = "";
            txtCemail.Text = "";
            txtCfname.Text = "";
            txtClname.Text = "";
            txtCNIC.Text = "";
            txtCphone.Text = "";

        }

        private void button5_Click(object sender, EventArgs e)
        {


            string Customer_Phone_Number = txtCphone.Text;
            string Customer_FirstName = txtCfname.Text;
            string Customer_LastName = txtClname.Text;
            string Customer_NIC = txtCNIC.Text;
            string Customer_DOF = txtCdof.Text;
            string Customer_Address = txtCaddress.Text;
            string Customer_Email = txtCemail.Text;

            if (txtCphone.Text == "")
            {
                //MessageBox.Show("Please Enter the Customer Phone Number");
                txtWarning.Text = "*Please Enter the Customer Phone Number";

            }
            else
            {
                SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=K:\Databases\SQL Server Database File\CustomerDatabase\CustomerDatabase.mdf;Integrated Security=True;Connect Timeout=30");
                string Qry = "SELECT Customer_FirstName,Customer_LastName,Customer_Address,Customer_DOF,Customer_Email,Customer_NIC From CustomerInformation WHERE Customer_Phone_Number= " + Customer_Phone_Number + "";

                SqlCommand cmd = new SqlCommand(Qry, connect);

                try
                {
                    connect.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    sdr.Read();

                    txtCfname.Text = sdr["Customer_FirstName"].ToString();
                    txtClname.Text = sdr["Customer_LastName"].ToString();
                    txtCaddress.Text = sdr["Customer_Address"].ToString();
                    txtCNIC.Text = sdr["Customer_NIC"].ToString();
                    txtCemail.Text = sdr["Customer_Email"].ToString();
                    txtCdof.Text = sdr["Customer_DOF"].ToString();

                }
                catch (SqlException se)
                {
                    MessageBox.Show("" + se);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mtd.CD();
            this.Hide();
        }

        private void CustomerInformation_Load(object sender, EventArgs e)
        {

        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            mtd.H();
            this.Hide();
        }

        private void btnitem_Click(object sender, EventArgs e)
        {
            mtd.IF();
            this.Hide();
        }

        private void btnuser_Click(object sender, EventArgs e)
        {
            mtd.UF();
            this.Hide();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            mtd.L();
            this.Hide();
        }

        private void txtCfname_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}