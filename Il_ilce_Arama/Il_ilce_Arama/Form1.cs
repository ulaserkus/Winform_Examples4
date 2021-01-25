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

namespace Il_ilce_Arama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection();

        private void btn_connect_Click(object sender, EventArgs e)
        {
            string adress = @"Data Source=USER\LOCAL;Initial Catalog=turkiye;Integrated Security=True";
            if (connection.State == ConnectionState.Open)
            {
                MessageBox.Show("Bağlantı zaten açık");
            }
            else if(connection.State == ConnectionState.Closed)
            {
                connection.ConnectionString = adress;
                connection.Open();
            }
            else
            {
                MessageBox.Show(connection.State.ToString());
            }
        }

        private void btn_gettbl_Click(object sender, EventArgs e)
        {
            SqlDataAdapter data = new SqlDataAdapter("select * from tbl_il",connection);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Search = new Search();
            Search.Show();
        }
    }
}
