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
    public partial class Checkout : Form
    {
        public int Tprice;
        public string No;
        public double discountprice;
        public double fprice;
        public Checkout(int tprice)
        {
            InitializeComponent();
            Tprice = tprice;
            lbltprice.Text = "Rs " +Tprice.ToString()+ ".00";
            lbldiscountprice.Text = "Rs 0.00";
            lblfp.Text = "Rs " + Tprice.ToString() + ".00";
            lbllastname.Text = "Thank You for the Purchase Valued Customer!";
            lbluname.Text = Login.username;
        }
        Methods mtd = new Methods();

        private void Checkout_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            mtd.H();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtcus.Text) && txtcus.Text.All(char.IsDigit))
            {
                lblwarning.Text = "";
                No = txtcus.Text;
                string Id = txtcus.Text;
                string lname;
                if (txtcus.Text.Length != 10)
                {
                    lblwarning.Text = "*Please Enter a Valid Number";
                }
                else
                {
                    lblwarning.Text = "";
                    try
                    {
                        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=K:\Databases\SQL Server Database File\CustomerDatabase\CustomerDatabase.mdf;Integrated Security=True;Connect Timeout=30");

                        string qryno = "SELECT Customer_LastName FROM CustomerInformation Where Customer_Phone_Number =" + No + "";
                        SqlCommand cmd = new SqlCommand(qryno, connect);


                        try
                        {
                            connect.Open();

                            SqlDataReader sdr = cmd.ExecuteReader();

                            if (sdr.Read())
                            {
                                try
                                {
                                    lname = sdr["Customer_LastName"].ToString();
                                    lbllastname.Text = lname;

                                    discountprice = double.Parse(Tprice.ToString()) * 10 / 100;
                                    lbldiscountprice.Text = "Rs "+discountprice.ToString();
                                    fprice = Tprice - discountprice;

                                    lblfp.Text = "Rs "+fprice.ToString();
                                    lbllastname.Text = "Thank You for the Purchase Mr/Mrs " + lname + "!";
                                }
                                catch (Exception blank)
                                {
                                    MessageBox.Show(blank.ToString());

                                }

                            }




                        }
                        catch (SqlException se)
                        {
                            MessageBox.Show(se.ToString());
                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                    catch (SqlException se)
                    {
                        MessageBox.Show(se.ToString());
                    }
                }

            }
            else
            {
                lblwarning.Text = "*Please Enter a Valid Number";
            }

            txtcus.Text = "";

        }
    }
}
