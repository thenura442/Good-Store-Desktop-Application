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
    public partial class ItemForm : Form
    {
        public ItemForm()
        {
            InitializeComponent();
            lbluname.Text = Login.username;
            if(Login.id == "199942452345")
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

        private void button1_Click(object sender, EventArgs e)
        {
            string Id = txtid.Text;
            string ItemName = txtname.Text;
            string ItemPrice = txtprice.Text;
            string PaymentMethod = txtpay.Text;
            string ItemQuantity = txtqua.Text;
            string ItemDescription = txtdes.Text;


            if (txtid.Text == "" || txtname.Text == "" || txtprice.Text == "" || txtpay.Text == "" || txtqua.Text == "" || txtdes.Text == "")
            {
                lblwarning.Text = "*Please Fill All The Item Details Fields";
            }

            else
            {
                string msg = "Data Saved Successfully";
                string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=K:\Databases\SQL Server Database File\ItemDatabase\ItemDatabase.mdf;Integrated Security=True;Connect Timeout=30";
                string qry = "INSERT INTO tbitem values('" + Id + "','" + ItemName + "','" + ItemPrice + "','" + PaymentMethod + "','" + ItemQuantity + "','" + ItemDescription + "')";
                mtd.sqlcon(qry, constring, msg);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Id = txtid.Text;
            string ItemName = txtname.Text;
            string ItemPrice = txtprice.Text;
            string PaymentMethod = txtpay.Text;
            string ItemQuantity = txtqua.Text;
            string ItemDescription = txtdes.Text;


            if (txtid.Text == "")
            {
                lblwarning.Text = "*Please Select An Item Code to Update The System";

            }
            else
            {
                string msg = "Data Updated Successfully";
                string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=K:\Databases\SQL Server Database File\ItemDatabase\ItemDatabase.mdf;Integrated Security=True;Connect Timeout=30";
                string qry = "UPDATE tbitem SET ItemName='" + txtname.Text + "',ItemPrice='" + txtprice.Text + "',PaymentMethod='" + txtpay.Text + "',ItemQuantity='" + txtqua.Text + "',ItemDescription='" + txtdes.Text + "' WHERE Id = '" + Id + "'";
                mtd.sqlcon(qry, constring, msg);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Id = txtid.Text;

            if (txtid.Text == "")
            {
                lblwarning.Text = "*Please Select An Item To Delete From The System";

            }
            else
            {
                string msg = "Data Deleted Successfully";
                string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=K:\Databases\SQL Server Database File\ItemDatabase\ItemDatabase.mdf;Integrated Security=True;Connect Timeout=30";
                string qry = "DELETE FROM tbitem WHERE Id ='" + Id + "'";
                mtd.sqlcon(qry, constring, msg);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string Id = txtid.Text;
            string ItemName = txtname.Text;
            string ItemPrice = txtprice.Text;
            string PaymentMethod = txtpay.Text;
            string ItemQuantity = txtqua.Text;
            string ItemDescription = txtdes.Text;


            if (txtid.Text == "")
            {
                lblwarning.Text = "*Please Enter Item Code then Click 'Search'";

            }
            else
            {
                SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=K:\Databases\SQL Server Database File\ItemDatabase\ItemDatabase.mdf;Integrated Security=True;Connect Timeout=30");
                string Qry = "SELECT ItemName,ItemPrice,PaymentMethod,ItemQuantity,ItemDescription From tbitem WHERE Id= " + Id + "";

                SqlCommand cmd = new SqlCommand(Qry, connect);



                try
                {
                    connect.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    sdr.Read();

                    txtname.Text = sdr["ItemName"].ToString();
                    txtprice.Text = sdr["ItemPrice"].ToString();
                    txtpay.Text = sdr["PaymentMethod"].ToString();
                    txtqua.Text = sdr["ItemQuantity"].ToString();
                    txtdes.Text = sdr["ItemDescription"].ToString();

                }
                catch (SqlException se)
                {
                    MessageBox.Show("" + se);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtname.Text = "";
            txtprice.Text = "";
            txtpay.Text = "";
            txtqua.Text = "";
            txtdes.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mtd.ID();
            this.Hide();
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            mtd.H();
            this.Hide();
        }

        private void btnuser_Click(object sender, EventArgs e)
        {
            mtd.UF();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mtd.CF();
            this.Hide();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            mtd.L();
            this.Hide();
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
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
