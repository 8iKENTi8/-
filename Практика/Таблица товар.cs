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
    public partial class Таблица_товар : MetroForm
    {
        public Таблица_товар()
        {
            InitializeComponent();
            textBox1.Text = "ID-ТОВАРА";
            textBox2.Text = "НАЗВАНИЕ";
            textBox3.Text = "КАТЕГОРИЯ";
            Search.Text = "ID-ТОВАРА";
            textBox1.ForeColor = Color.Gray;
            textBox2.ForeColor = Color.Gray;
            textBox3.ForeColor = Color.Gray;
            Search.ForeColor = Color.Gray;
            
        }

       

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main form2 = new Main();
            form2.Show();
        }

        //Проверка на наличие товара 
        public Boolean logincheck_c()
        {
            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `товар` WHERE `ID_T` = @ul ", db.GetConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = textBox1.Text;


            adapter.SelectCommand = command;
            adapter.Fill(dt);

            if (dt.Rows.Count > 0) { MessageBox.Show("Такой логни уже есть"); return true; }
            else
                return false;
        }

        //Кнопка добавить
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "ID-ТОВАРА") { MessageBox.Show("Введите ID - ТОВАРА"); textBox1.Focus(); return; }
            if (textBox2.Text == "НАЗВАНИЕ") { MessageBox.Show("Введите НАЗВАНИЕ"); textBox2.Focus(); return; }
            if (textBox3.Text == "КАТЕГОРИЯ") { MessageBox.Show("Введите КАТЕГОРИЮ"); textBox3.Focus(); return; }
            if (logincheck_c())
                return;


            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `товар` (`ID_T`, `Name`, `Категория`) VALUES (@ul, @na, @pa)", db.GetConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@na", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@pa", MySqlDbType.VarChar).Value = textBox3.Text;
            


            db.openConnection();
            if (command.ExecuteNonQuery() == 1) { MessageBox.Show("Аккаунт был создан"); }

            db.closeConnection();
        }

        //Проверка на удаление

        public Boolean logincheck_c_d()
        {
            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `товар` WHERE `ID_T` = @ul ", db.GetConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = textBox1.Text;


            adapter.SelectCommand = command;
            adapter.Fill(dt);



            if (dt.Rows.Count == 0) { MessageBox.Show("Такого логина нет"); return true; }
            else
                return false;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "ID-ТОВАРА") { MessageBox.Show("Введите ID - ТОВАРА"); textBox1.Focus(); return; }
            
            if (logincheck_c_d())
                return;


            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM `товар` WHERE `товар`.`ID_T` = @ul", db.GetConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = textBox1.Text;



            db.openConnection();
            if (command.ExecuteNonQuery() == 1) { MessageBox.Show("Аккаунт был Удален"); }

            db.closeConnection();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "ID-ТОВАРА")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "ID-ТОВАРА";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "НАЗВАНИЕ";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "НАЗВАНИЕ")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "КАТЕГОРИЯ";
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "КАТЕГОРИЯ")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void Search_Enter(object sender, EventArgs e)
        {
            if (Search.Text == "ID-ТОВАРА")
            {
                Search.Text = "";
                Search.ForeColor = Color.Black;
            }
        }

        private void Search_Leave(object sender, EventArgs e)
        {
            if (Search.Text == "")
            {
                Search.Text = "ID-ТОВАРА";
                Search.ForeColor = Color.Gray;
            }
        }

        private void begin_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `товар`", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(com);
            DataTable ds = new DataTable();
            adapter.Fill(ds);

            textBox1.Text = ds.Rows[0][0].ToString();
            textBox2.Text = ds.Rows[0][1].ToString();
            textBox3.Text = ds.Rows[0][2].ToString();
            connection.Close();
           
        }

        private void end_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `товар`", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(com);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            int a = ds.Rows.Count - 1;
            textBox1.Text = ds.Rows[0 + a][0].ToString();
            textBox2.Text = ds.Rows[0 + a][1].ToString();
            textBox3.Text = ds.Rows[0 + a][2].ToString();
          
        }

        private void next_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `товар`", connection);
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
                        textBox3.Text = ds.Rows[0 + i + 1][2].ToString();
                        
                        return;
                    }

                }
            }
        }

        //кнопка назад
        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `товар`", connection);
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
                        textBox3.Text = ds.Rows[0 + i - 1][2].ToString();
                        
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
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = Search.Text;


            adapter.SelectCommand = command;
            adapter.Fill(dt);



            if (dt.Rows.Count == 0) { MessageBox.Show("Такого логина нет"); return true; }
            else
                return false;
        }

        //Поиск
        private void button9_Click(object sender, EventArgs e)
        {
            if (Search.Text == "ID-ТОВАРА") { MessageBox.Show("Введите ID - ТОВАРА"); Search.Focus(); return; }

            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `товар`", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(com);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            if (logincheck_c_u())
                return;

            int i, j;
            string k, k1;
            k1 = Search.Text.ToString();


            for (i = 0; i < ds.Rows.Count; i++)
            {
                for (j = 0; j < ds.Columns.Count; j++)
                {
                    k = ds.Rows[0 + i][0 + j].ToString();

                    if (k1 == k)
                    {

                        textBox1.Text = ds.Rows[0 + i][0].ToString();
                        textBox2.Text = ds.Rows[0 + i][1].ToString();
                        textBox3.Text = ds.Rows[0 + i][2].ToString();
                       
                        return;
                    }

                }
            }
        }

        //Проверка обновить
        public Boolean logincheck_c_u1()
        {
            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `товар` WHERE `ID_T` = @ul ", db.GetConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = textBox1.Text;


            adapter.SelectCommand = command;
            adapter.Fill(dt);



            if (dt.Rows.Count == 0) { MessageBox.Show("Такого логина нет"); return true; }
            else
                return false;
        }

        //Кнопка обновить
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "ID-ТОВАРА") { MessageBox.Show("Введите ID - ТОВАРА"); textBox1.Focus(); return; }


            if (logincheck_c_u1())
                return;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("UPDATE `товар` SET `ID_T` = @ul, `Name` = @na, `Категория` = @pa WHERE `товар`.`ID_T` = @ul ", db.GetConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@na", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@pa", MySqlDbType.VarChar).Value = textBox3.Text;
           

            db.openConnection();
            if (command.ExecuteNonQuery() == 1) { MessageBox.Show("Аккаунт был изменен"); }

            db.closeConnection();
        }
    }
}
