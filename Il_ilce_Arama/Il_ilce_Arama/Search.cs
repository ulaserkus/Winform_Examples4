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
    public partial class Search : Form
    {
        static string cs = @"Data Source=USER\LOCAL;Initial Catalog=turkiye;Integrated Security=True";
        public Search()
        {
            InitializeComponent();
        }
     
        private void Search_Load(object sender, EventArgs e)
        {
            string command = "select * from tbl_il";
            comboBox1.DisplayMember = "il_ad";
            comboBox1.ValueMember = "il_id";
            comboBox1.DropDownHeight = 150;
            comboBox1.DataSource = Command(command, cs);

        }

        public static DataTable Command(string command, string cs)
        {
            SqlDataAdapter data = new SqlDataAdapter(command, cs);
            DataTable dataTable = new DataTable();
            data.Fill(dataTable);

            return dataTable;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            short SelectedCountryId = (short)comboBox1.SelectedValue;
            string cmd = "select ilce_ad from tbl_ilce where il_id="+SelectedCountryId.ToString();
            comboBox2.DisplayMember = "ilce_ad";
            comboBox2.DropDownHeight = 150;
            comboBox2.DataSource = Command(cmd, cs);
        }
    }
}
