using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Good_Store_Project
{
    class Methods
    {
        public void H()
        {
            Home hm = new Home();
            hm.Show();
        }

        public void IF()
        {
            ItemForm iform = new ItemForm();
            iform.Show();
        }

        public void PL()
        {
            PreLogin pl = new PreLogin();
            pl.Show();
        }

        public void L()
        {
            Login l = new Login();
            l.Show();
        }

        public void ID()
        {
            ItemDatabase id = new ItemDatabase();
            id.Show();
        }

        public void CF()
        {
            CustomerInformation cf = new CustomerInformation();
            cf.Show();
        }

        public void CD()
        {
            CustomerDatagridview cd = new CustomerDatagridview();
            cd.Show();
        }

        public void UF()
        {
            User uf = new User();
            uf.Show();
        }

        public void UD()
        {
            UserDataBase ud = new UserDataBase();
            ud.Show();
        }

        public void sqlcon(string qry, string constring, string msg)
        {
            SqlConnection con = new SqlConnection(@"" + constring);
            SqlCommand cmd = new SqlCommand(qry, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show(""+ msg);
            }
            catch (SqlException SE)
            {
                MessageBox.Show(SE.ToString());
            }
            finally
            {
                con.Close();
            }
        }
    }
}
