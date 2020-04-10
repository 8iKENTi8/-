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
    public partial class Хранилище_ломбарда : MetroForm
    {
        public Хранилище_ломбарда()
        {
            InitializeComponent();
            textBox5.Text = "ID-ТОВАРА";
            textBox5.ForeColor = Color.Gray;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main form2 = new Main();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `хранилище ломбарда`", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(com);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            int a = ds.Rows.Count - 1;
            textBox1.Text = ds.Rows[0 + a][0].ToString();
            textBox2.Text = ds.Rows[0 + a][1].ToString();
            
        }

        //Кнопка в начало
        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `хранилище ломбарда`", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(com);
            DataTable ds = new DataTable();
            adapter.Fill(ds);

            textBox1.Text = ds.Rows[0][0].ToString();
            textBox2.Text = ds.Rows[0][1].ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `хранилище ломбарда`", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(com);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            int i, j;
            string k, k1;
            k1 = textBox1.Text.ToString();

            for (i = 0; i < ds.Rows.Count; i++)
            {
                for (j = 0; j < ds.Columns.Count; j++)
                {
                    k = ds.Rows[0 + i][0 + j].ToString();

                    if (k1 == k)
                    {

                        int i2 = Convert.ToInt32(k);
                        string i3 = ds.Rows[0][0].ToString();
                        int i4 = Convert.ToInt32(i3);
                        if (i2 == i4)
                        {
                            MessageBox.Show("Выход за пределы");
                            return;
                        }

                        textBox1.Text = ds.Rows[0 + i - 1][0].ToString();
                        textBox2.Text = ds.Rows[0 + i - 1][1].ToString();
                       
                        return;
                    }

                }
            }
        }

        //Кнопка вперед
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `хранилище ломбарда`", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(com);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            int i, j;
            string k, k1;
            k1 = textBox1.Text.ToString();

            for (i = 0; i < ds.Rows.Count; i++)
            {
                for (j = 0; j < ds.Columns.Count; j++)
                {
                    k = ds.Rows[0 + i][0 + j].ToString();

                    if (k1 == k)
                    {


                        string row = (ds.Rows.Count - 1).ToString();
                        int row1 = Convert.ToInt32(row);


                        int i2 = Convert.ToInt32(k);
                        string i3 = ds.Rows[0 + row1][0].ToString();
                        int i4 = Convert.ToInt32(i3);
                        if (i2 == i4)
                        {
                            MessageBox.Show("Выход за пределы");
                            return;
                        }

                        textBox1.Text = ds.Rows[0 + i + 1][0].ToString();
                        textBox2.Text = ds.Rows[0 + i + 1][1].ToString();
                        
                        return;
                    }

                }
            }
        }

        //Проверка поиска
        public Boolean logincheck_c_u()
        {
            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `товар` WHERE `ID_T` = @ul ", db.GetConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = textBox5.Text;


            adapter.SelectCommand = command;
            adapter.Fill(dt);



            if (dt.Rows.Count == 0) { MessageBox.Show("Такого логина нет"); return true; }
            else
                return false;
        }

        //Кнопка поиск
        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "ID-КЛИЕНТА") { MessageBox.Show("Введите ID - КЛИЕНТА"); textBox1.Focus(); return; }

            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `хранилище ломбарда`", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(com);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            if (logincheck_c_u())
                return;

            int i, j;
            string k, k1;
            k1 = textBox5.Text.ToString();


            for (i = 0; i < ds.Rows.Count; i++)
            {
                for (j = 0; j < ds.Columns.Count; j++)
                {
                    k = ds.Rows[0 + i][0 + j].ToString();

                    if (k1 == k)
                    {

                        textBox1.Text = ds.Rows[0 + i][0].ToString();
                        textBox2.Text = ds.Rows[0 + i][1].ToString();
                        
                        return;
                    }

                }
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "ID-ТОВАРА")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "ID-ТОВАРА";
                textBox5.ForeColor = Color.Gray;
            }
        }
    }
}
