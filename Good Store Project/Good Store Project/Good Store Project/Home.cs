using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;


namespace Good_Store_Project
{
    public partial class Home : Form
    {
        public Home()
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
        public int tprice = 0;
        public int flag = 0;
        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            mtd.L();
            this.Hide();
        }

        private void btnuser_Click(object sender, EventArgs e)
        {
            mtd.UF();
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

        private void button1_Click_1(object sender, EventArgs e)
        {

            string Id = txtitemid.Text;
            if(txtitemid.Text == "")
            {
                lblwarning1.Text = "*Please Enter a Valid Item ID";
            }
            else
            {
                try
                {
                    
                    SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=K:\Databases\SQL Server Database File\ItemDatabase\ItemDatabase.mdf;Integrated Security=True;Connect Timeout=30");
                    string qry = "SELECT ItemName, ItemDescription, ItemPrice FROM tbitem Where Id ='" + Id + "'";

                    SqlCommand cmd = new SqlCommand(qry , connect);

                    try
                    {
                        connect.Open();

                        SqlDataReader sdr = cmd.ExecuteReader();

                        if (sdr.Read())
                        {
                            try
                            {
                                label6.Text = "-";
                                label2.Text = "X";
                                label3.Text = "=";
                                label5.Text = "=";
                                label4.Text = "Total Price";
                                string p = sdr["ItemPrice"].ToString();
                                string iname = sdr["ItemName"].ToString();
                                string idescription = sdr["ItemDescription"].ToString();
                                lbldescription.Text = idescription;
                                lblitem.Text = iname;
                                lblprice.Text = p;
                                int Price = Convert.ToInt32(p);
                                int quant;
                                quant = Convert.ToInt32(txtquantity.Text);

                                lblquantity.Text = quant.ToString();

                                int qprice = 0;

                                tprice = tprice + quant * Price;
                                lbltprice.Text = tprice.ToString();

                                qprice = qprice + quant * Price;

                                lblqp.Text = qprice.ToString();

                                flag = 0;
                            }
                            catch
                            {
                                lblwarning1.Text = "*Please include a value for Quantity";
                                flag = 1;
                            }
                            if (flag == 0)
                            {
                                lblwarning1.Text = "";
                                txtitemid.Text = "";
                                txtquantity.Text = "1";
                            }
                        }
                        else
                        {
                            lblwarning1.Text = "*Please Enter a Valid Item ID";
                        }
                        

                        

                    }
                    catch(SqlException se)
                    {
                        MessageBox.Show(se.ToString());
                    }
                    finally 
                    {
                        connect.Close();
                    }
                }
                catch(SqlException se)
                {
                    MessageBox.Show(se.ToString());
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(tprice > 0)
            {
                Checkout objcheck = new Checkout(tprice);

                objcheck.Show();
                this.Hide();
            }
            
        }
    }
}
