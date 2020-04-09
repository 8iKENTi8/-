using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Практика
{
    public partial class ТабКлиент : UserControl
    {
        public ТабКлиент()
        {
            InitializeComponent();
            textBox1.Text = "ID-КЛИЕНТА";
            textBox2.Text = "ИМЯ";
            textBox3.Text = "ПАСПОРТ";
            textBox4.Text = "ТЕЛЕФОН";
            textBox5.Text = "ID-КЛИЕНТА";
            textBox1.ForeColor = Color.Gray;
            textBox2.ForeColor = Color.Gray;
            textBox3.ForeColor = Color.Gray;
            textBox4.ForeColor = Color.Gray;
            textBox5.ForeColor = Color.Gray;

        }

       

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "ID-КЛИЕНТА")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "ID-КЛИЕНТА";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Таблица_клиент someForm = (Таблица_клиент)this.Parent;
            someForm.Hide();
            Main form2 = new Main();
            form2.Show();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "ИМЯ")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "ИМЯ";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "ТЕЛЕФОН")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "ТЕЛЕФОН";
                textBox4.ForeColor = Color.Gray;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "ПАСПОРТ")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "ПАСПОРТ";
                textBox3.ForeColor = Color.Gray;
            }
        }

        //Проверка клиента
        public Boolean logincheck_c()
        {
            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `клиент` WHERE `ID_C` = @ul ", db.GetConnection());
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
            if(textBox1.Text== "ID-КЛИЕНТА") { MessageBox.Show("Введите ID - КЛИЕНТА"); textBox1.Focus(); return; }
            if (textBox2.Text == "ИМЯ") { MessageBox.Show("Введите Имя"); textBox2.Focus(); return; }
            if (textBox3.Text == "ПАСПОРТ") { MessageBox.Show("Введите Паспорт"); textBox3.Focus(); return; }
            if (textBox4.Text == "ТЕЛЕФОН") { MessageBox.Show("Введите Телефон"); textBox4.Focus(); return; }
            if (logincheck_c())
                return;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `клиент` (`ID_C`, `Имя`, `Паспорт`, `Телефон`) VALUES (@ul, @na, @pa, @ph)", db.GetConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@na", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@pa", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = textBox4.Text;


            db.openConnection();
            if (command.ExecuteNonQuery() == 1) { MessageBox.Show("Аккаунт был создан");  }

            db.closeConnection();


        }

        //Проверить сушествование
        public Boolean logincheck_c_u()
        {
            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `клиент` WHERE `ID_C` = @ul ", db.GetConnection());
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

            if (textBox1.Text == "ID-КЛИЕНТА") { MessageBox.Show("Введите ID - КЛИЕНТА"); textBox1.Focus(); return; }

            String idUser = textBox1.Text;
            String Name = textBox2.Text;
            String Pasport = textBox3.Text;
            String Phone = textBox4.Text;
            if (logincheck_c_u())
                return;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("UPDATE `клиент` SET `ID_C` = @ul, `Имя` = @na, `Паспорт` = @pa, `Телефон` = @ph WHERE `клиент`.`ID_C` = @ul ", db.GetConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = idUser;
            command.Parameters.Add("@na", MySqlDbType.VarChar).Value = Name;
            command.Parameters.Add("@pa", MySqlDbType.VarChar).Value = Pasport;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = Phone;

            
            
                db.openConnection();
                if (command.ExecuteNonQuery() == 1) { MessageBox.Show("Аккаунт был изменен"); }

                db.closeConnection();
            

           
        }

        //Проверка на символы
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b' && l != '.')
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        //Проверка на удаление

        public Boolean logincheck_c_d()
        {
            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `клиент` WHERE `ID_C` = @ul ", db.GetConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = textBox1.Text;


            adapter.SelectCommand = command;
            adapter.Fill(dt);



            if (dt.Rows.Count == 0) { MessageBox.Show("Такого логина нет"); return true; }
            else
                return false;
        }

        //кнопка удалить
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "ID-КЛИЕНТА") { MessageBox.Show("Введите ID - КЛИЕНТА"); textBox1.Focus(); return; }
            if (textBox2.Text == "ИМЯ") { MessageBox.Show("Введите Имя"); textBox2.Focus(); return; }
            if (textBox3.Text == "ПАСПОРТ") { MessageBox.Show("Введите Паспорт"); textBox3.Focus(); return; }
            if (textBox4.Text == "ТЕЛЕФОН") { MessageBox.Show("Введите Телефон"); textBox4.Focus(); return; }
            if (logincheck_c_d())
                return;


            DB db = new DB();
            MySqlCommand command = new MySqlCommand("DELETE FROM `клиент` WHERE `клиент`.`ID_C` = @ul " , db.GetConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = textBox1.Text;
            


            db.openConnection();
            if (command.ExecuteNonQuery() == 1) { MessageBox.Show("Аккаунт был Удален"); }

            db.closeConnection();
        }

        //Кнопка поиск
        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "ID-КЛИЕНТА") { MessageBox.Show("Введите ID - КЛИЕНТА"); textBox1.Focus(); return; }

            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `клиент`", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(com);
            DataTable ds = new DataTable();
            adapter.Fill(ds);

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
                        textBox3.Text = ds.Rows[0 + i][2].ToString();
                        textBox4.Text = ds.Rows[0 + i][3].ToString();
                        return;
                    }

                }
            }

            

            
        }

        //кнопка в начало
        private void button4_Click(object sender, EventArgs e)
        {
           

            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `клиент`", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(com);
            DataTable ds = new DataTable();
            adapter.Fill(ds);

            textBox1.Text = ds.Rows[0][0].ToString();
            textBox2.Text = ds.Rows[0][1].ToString();
            textBox3.Text = ds.Rows[0][2].ToString();
            textBox4.Text = ds.Rows[0][3].ToString();
        }

        //кнопка вперед
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `клиент`", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(com);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            int i, j;
            string k, k1;
            k1 = textBox1.Text.ToString();
            
            for ( i = 0; i < ds.Rows.Count; i++)
            {
                for ( j = 0; j < ds.Columns.Count; j++)
                {
                     k= ds.Rows[0 + i][0+j].ToString();

                    if (k1 == k )
                    {


                        string row = (ds.Rows.Count-1).ToString();
                        int row1 = Convert.ToInt32(row);
                        

                        int i2 = Convert.ToInt32(k);
                        string i3 = ds.Rows[0+row1][0].ToString();
                        int i4 = Convert.ToInt32(i3);
                        if (i2 == i4)
                        {
                            MessageBox.Show("Выход за пределы");
                            return;
                        }

                        textBox1.Text = ds.Rows[0 + i+1][0].ToString();
                        textBox2.Text = ds.Rows[0 + i+1][1].ToString();
                        textBox3.Text = ds.Rows[0 + i+1][2].ToString();
                        textBox4.Text = ds.Rows[0 + i+1][3].ToString();
                        return;
                    }
                  
                }
            }

        }

        //кнопка вконец
        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `клиент`", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(com);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            int a = ds.Rows.Count-1;
            textBox1.Text = ds.Rows[0+a][0].ToString();
            textBox2.Text = ds.Rows[0+a][1].ToString();
            textBox3.Text = ds.Rows[0+a][2].ToString();
            textBox4.Text = ds.Rows[0+a][3].ToString();
           
        }

        //кнопка назад
        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `клиент`", connection);
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
                        if (i2 == i4 )
                        {
                            MessageBox.Show("Выход за пределы");
                            return;
                        }

                        textBox1.Text = ds.Rows[0 + i - 1][0].ToString();
                        textBox2.Text = ds.Rows[0 + i - 1][1].ToString();
                        textBox3.Text = ds.Rows[0 + i - 1][2].ToString();
                        textBox4.Text = ds.Rows[0 + i - 1][3].ToString();
                        return;
                    }

                }
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "ID-КЛИЕНТА")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "ID-КЛИЕНТА";
                textBox5.ForeColor = Color.Gray;
            }
        }
    }
    
}
