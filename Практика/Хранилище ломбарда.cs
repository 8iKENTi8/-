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
            textBox2.Text = "КОЛИЧЕСТВО";
            textBox2.ForeColor = Color.Gray;

            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `хранилище ломбарда`", connection);
            MySql.Data.MySqlClient.MySqlDataAdapter adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(com);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            int i;
            for (i = 0; i < ds.Rows.Count; i++)
            {
                metroComboBox1.Items.Add(ds.Rows[i][0].ToString());
            }

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
            textBox2.Text = ds.Rows[0 + a][1].ToString();
          
            metroComboBox1.SelectedIndex = ds.Rows.Count-1 ;
            
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
            textBox2.Text = ds.Rows[0][1].ToString();
            metroComboBox1.SelectedIndex = 0;

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
            k1 = metroComboBox1.SelectedItem.ToString();
           

            for (i = 0; i < ds.Rows.Count; i++)
            {
                for (j = 0; j < ds.Columns.Count; j++)
                {
                    k = ds.Rows[0 + i][0].ToString();

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

                        metroComboBox1.SelectedIndex--;
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
           
           k1= metroComboBox1.SelectedItem.ToString();

            for (i = 0; i < ds.Rows.Count; i++)
            {
                for (j = 0; j < ds.Columns.Count; j++)
                {
                    k = ds.Rows[0 + i][0].ToString();

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

                        metroComboBox1.SelectedIndex++;
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

            MySqlCommand command = new MySqlCommand("SELECT * FROM `хранилище ломбарда` WHERE `ID_T` = @ul ", db.GetConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = metroComboBox1.SelectedItem.ToString();

            adapter.SelectCommand = command;
            adapter.Fill(dt);

            if (dt.Rows.Count == 0) { MessageBox.Show("Такого логина нет"); return true; }
            else
                return false;
        }

        //Кнопка поиск
        private void button9_Click(object sender, EventArgs e)
        {
            

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
            k1 = metroComboBox1.SelectedItem.ToString();


            for (i = 0; i < ds.Rows.Count; i++)
            {
                for (j = 0; j < ds.Columns.Count; j++)
                {
                    k = ds.Rows[0 + i][0 ].ToString();

                    if (k1 == k)
                    {

                        textBox2.Text = ds.Rows[0 + i][1].ToString();
                        
                        return;
                    }

                }
            }
        }

     

        //Кнопка обновить 
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "КОЛИЧЕСТВО") { MessageBox.Show("Введите Количетсво"); textBox2.Focus(); return; }

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("UPDATE `хранилище ломбарда` SET `количество` = @ul1 WHERE `хранилище ломбарда`.`ID_T` = @ul", db.GetConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = metroComboBox1.SelectedItem.ToString();
            command.Parameters.Add("@ul1", MySqlDbType.VarChar).Value = textBox2.Text;


            db.openConnection();
            if (command.ExecuteNonQuery() == 1) { MessageBox.Show("Аккаунт был изменен"); }

            db.closeConnection();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "КОЛИЧЕСТВО";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "КОЛИЧЕСТВО")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }
    }

        
    
}
