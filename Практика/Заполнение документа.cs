using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;

namespace Практика
{
    public partial class Заполнение_документа : MetroForm
    {
        public Заполнение_документа()
        {
            InitializeComponent();
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `клиент`", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "клиент");
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
           // if(dataGridView1.Rows.Count>0)

        }
    }
}
