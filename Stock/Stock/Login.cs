using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewMethod();
        }

        private void NewMethod()
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TO:DO: Check Login username and password
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=SD0003;Integrated Security=True");
            SqlDataAdapter sqa = new SqlDataAdapter(@"SELECT *
                FROM [SD0003].[dbo].[Login] Where UserName = '"+textBox1.Text+"' and Password = '"+textBox2.Text+"'",con);
            DataTable dt = new DataTable();
            sqa.Fill(dt);
            if(dt.Rows.Count == 1)
            {
                this.Hide();
                StockMain main = new StockMain();
                main.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username & Password..!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NewMethod();
            }
        }
    }
}
