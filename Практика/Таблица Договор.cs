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
    public partial class Таблица_Договор : MetroForm
    {
       
        public Таблица_Договор()
        {
            InitializeComponent();
            textBox1.MaxLength = 3;
            textBox2.MaxLength = 3;
            textBox3.MaxLength = 3;
            textBox6.MaxLength = 10;
            textBox7.MaxLength = 10;
            textBox1.Text = "ID-ДОГОВОРА";
            textBox2.Text = "ID-КЛИЕНТА";
            textBox3.Text = "ID-ТОВАРА";
            textBox4.Text = "ПРОЦЕНТ 30%";
            textBox5.Text = "ДЕНЬГИ ЗА ВЕШЬ";
            textBox6.Text = "ВЫКУПИТЬ НЕВОЗМОЖНО";
            textBox7.Text = "ДАТА ПРОЦЕНТА";
            textBox1.ForeColor = Color.Gray;
            textBox2.ForeColor = Color.Gray;
            textBox3.ForeColor = Color.Gray;
            textBox4.ForeColor = Color.Gray;
            textBox5.ForeColor = Color.Gray;
            textBox6.ForeColor = Color.Gray;
            textBox7.ForeColor = Color.Gray;
            }

        private void ch1(string i)
        {
            if (i=="False")
            {
                textBox6.ReadOnly = true; textBox7.ReadOnly = true; textBox4.ReadOnly = true; textBox4.Clear(); textBox6.Clear(); textBox7.Clear();
                xuiSwitch1.SwitchState = XanderUI.XUISwitch.State.Off;
            }
            else
            {
                textBox6.ReadOnly = false; textBox7.ReadOnly = false; textBox4.ReadOnly = false;
                xuiSwitch1.SwitchState = XanderUI.XUISwitch.State.On;
            }
        }

        //Кнопка обновить без возврата
        private void ch2()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
         
            MySqlCommand command = new MySqlCommand("UPDATE `договор` SET  `Процент30` = NULL, `ДеньгиНаРуки` = @na, `Возврат` = 0, `Дата_выкуп_невозм` = NULL , `Дата_процента` = NULL WHERE `договор`.`ID_D` = @ul ", db.GetConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@na", MySqlDbType.VarChar).Value = textBox5.Text;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1) { MessageBox.Show("Аккаунт был изменен"); }

            db.closeConnection();
        }

        //Кнопка обновить с возвратом
        private void ch3()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            

            MySqlCommand command = new MySqlCommand("UPDATE `договор` SET  `Процент30` = @ph1, `ДеньгиНаРуки` = @na, `Возврат` = 1, `Дата_выкуп_невозм` = @pa , `Дата_процента` = @ph WHERE `договор`.`ID_D` = @ul ", db.GetConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@na", MySqlDbType.VarChar).Value = textBox5.Text;
            command.Parameters.Add("@pa", MySqlDbType.VarChar).Value = textBox6.Text;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = textBox7.Text;
            command.Parameters.Add("@ph1", MySqlDbType.VarChar).Value = textBox4.Text;
            

            db.openConnection();
            if (command.ExecuteNonQuery() == 1) { MessageBox.Show("Аккаунт был изменен"); }

            db.closeConnection();
        }

        //Кнопка добавить без возврата
        private void ch4()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

          
            MySqlCommand command = new MySqlCommand("INSERT INTO `договор` (`ID_D`, `ID_C`, `ID_T`, `Процент30`, `ДеньгиНаРуки`, `Возврат`, `Дата_выкуп_невозм`, `Дата_процента`) VALUES (@ul, @na, @na1, NULL, @na2,0 , NULL, NULL)", db.GetConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@na", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@na1", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@na2", MySqlDbType.VarChar).Value = textBox5.Text;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1) { MessageBox.Show("Аккаунт был добавлен"); }

            db.closeConnection();
        }

        //Кнопка добавить с возвратом
        private void ch5()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();


            MySqlCommand command = new MySqlCommand("INSERT INTO `договор` (`ID_D`, `ID_C`, `ID_T`, `Процент30`, `ДеньгиНаРуки`, `Возврат`, `Дата_выкуп_невозм`, `Дата_процента`) VALUES (@ul, @na, @na1, @pr2, @na2,1, @pr1, @pr) ", db.GetConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@na", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@na1", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@na2", MySqlDbType.VarChar).Value = textBox5.Text;
            command.Parameters.Add("@pr", MySqlDbType.VarChar).Value = textBox7.Text;
            command.Parameters.Add("@pr1", MySqlDbType.VarChar).Value = textBox6.Text;
            command.Parameters.Add("@pr2", MySqlDbType.VarChar).Value = textBox4.Text;


            db.openConnection();
            if (command.ExecuteNonQuery() == 1) { MessageBox.Show("Аккаунт был добавлен"); }

            db.closeConnection();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main form2 = new Main();
            form2.Show();
        }

        private void begin_Click(object sender, EventArgs e)
        {

            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `договор`", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(com);
            DataTable ds = new DataTable();
            adapter.Fill(ds);

            textBox1.Text = ds.Rows[0][0].ToString();
            textBox2.Text = ds.Rows[0][1].ToString();
            textBox3.Text = ds.Rows[0][2].ToString();
            textBox4.Text = ds.Rows[0][3].ToString();
            textBox5.Text = ds.Rows[0][4].ToString();
            textBox6.Text = ds.Rows[0][6].ToString();
            textBox7.Text = ds.Rows[0][7].ToString();
            string b = ds.Rows[0][5].ToString();
            ch1(b);
        }

        private void end_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `договор`", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(com);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            int a = ds.Rows.Count - 1;
            textBox1.Text = ds.Rows[0 + a][0].ToString();
            textBox2.Text = ds.Rows[0 + a][1].ToString();
            textBox3.Text = ds.Rows[0 + a][2].ToString();
            textBox4.Text = ds.Rows[0 + a][3].ToString();
            textBox5.Text = ds.Rows[0+a][4].ToString();
            textBox6.Text = ds.Rows[0+a][6].ToString();
            textBox7.Text = ds.Rows[0+a][7].ToString();
            string b = ds.Rows[0 + a][5].ToString();
            ch1(b);
           

        }

        private void next_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `договор`", connection);
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
                        textBox4.Text = ds.Rows[0 + i + 1][3].ToString();
                        textBox5.Text = ds.Rows[0 + i + 1][4].ToString();
                        textBox6.Text = ds.Rows[0 + +i + 1][6].ToString();
                        textBox7.Text = ds.Rows[0 + i + 1][7].ToString();
                        string b = ds.Rows[0 + i+1][5].ToString();
                        ch1(b);
                        return;
                    }

                }
            }
        }


        //Проверить сушествование
        public Boolean logincheck_c_u()
        {
            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `договор` WHERE `ID_D` = @ul ", db.GetConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = textBox1.Text;

            adapter.SelectCommand = command;
            adapter.Fill(dt);

            if (dt.Rows.Count == 0) { MessageBox.Show("Такого логина нет"); return true; }
            else
                return false;
        }

        //Button update
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "ID-ДОГОВОРА") { MessageBox.Show("Введите ID-ДОГОВОРА"); textBox1.Focus(); return; }
            if (logincheck_c_u())
                return;
            if (xuiSwitch1.SwitchState == XanderUI.XUISwitch.State.Off)
                ch2();
            else
                ch3();

        }

        //Кнопка назад
        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `договор`", connection);
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
                        textBox4.Text = ds.Rows[0 + i - 1][3].ToString();
                        textBox5.Text = ds.Rows[0 + i - 1][4].ToString();
                        textBox6.Text = ds.Rows[0  +i - 1][6].ToString();
                        textBox7.Text = ds.Rows[0 + i - 1][7].ToString();
                        string b = ds.Rows[0 + i -1][5].ToString();
                        ch1(b);
                        return;
                    }

                }
            }
        }

        //Проверка поиска
        public Boolean logincheck_c_u1()
        {
            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `договор` WHERE `ID_D` = @ul ", db.GetConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = Search.Text;


            adapter.SelectCommand = command;
            adapter.Fill(dt);

            if (dt.Rows.Count == 0) { MessageBox.Show("Такого логина нет"); return true; }
            else
                return false;
        }

        //кнопка поиск
        private void button9_Click(object sender, EventArgs e)
        {
          

            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `договор`", connection);
         
            MySqlDataAdapter adapter = new MySqlDataAdapter(com);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            if (logincheck_c_u1())
                return;

            int i, j;
            string k, k1;
            k1 = Search.Text.ToString();


            for (i = 0; i < ds.Rows.Count; i++)
            {
                for (j = 0; j < ds.Columns.Count; j++)
                {
                    k = ds.Rows[0 + i][0 ].ToString();

                    if (k1 == k)
                    {

                        textBox1.Text = ds.Rows[0 + i ][0].ToString();
                        textBox2.Text = ds.Rows[0 + i ][1].ToString();
                        textBox3.Text = ds.Rows[0 + i ][2].ToString();
                        textBox4.Text = ds.Rows[0 + i ][3].ToString();
                        textBox5.Text = ds.Rows[0 + i ][4].ToString();
                        textBox6.Text = ds.Rows[0 + i ][6].ToString();
                        textBox7.Text = ds.Rows[0 + i ][7].ToString();
                        string b = ds.Rows[0 + i ][5].ToString();
                        ch1(b);

                        return;
                    }

                }
            }
        }

        //Проверка договора
        public Boolean logincheck_c()
        {
            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `договор` WHERE `ID_D` = @ul ", db.GetConnection());
            command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = textBox1.Text;


            adapter.SelectCommand = command;
            adapter.Fill(dt);

            if (dt.Rows.Count > 0) { MessageBox.Show("Такой договор уже есть"); return true; }
            else
                return false;
        }

        //Button add
        private void button5_Click(object sender, EventArgs e)
        {
            if (logincheck_c())
                return;
            if (xuiSwitch1.SwitchState == XanderUI.XUISwitch.State.Off)
                ch4();
            else
                ch5();
        }

        private void xuiSwitch1_Click(object sender, EventArgs e)
        {
            if (xuiSwitch1.SwitchState == XanderUI.XUISwitch.State.On)
            {
                textBox4.ReadOnly =false; textBox6.ReadOnly = false; textBox7.ReadOnly = false;
            }
            else
            {
                textBox4.ReadOnly = true; textBox6.ReadOnly = true; textBox7.ReadOnly = true;
                textBox4.Clear(); textBox6.Clear(); textBox7.Clear();
            }
        }

     

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "ID-ДОГОВОРА";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "ID-ДОГОВОРА")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "ID-КЛИЕНТА";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "ID-КЛИЕНТА")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "ID-ТОВАРА")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "ID-ТОВАРА";
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "ПРОЦЕНТ 30%";
                textBox4.ForeColor = Color.Gray;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "ПРОЦЕНТ 30%")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.Text = "ВЫКУПИТЬ НЕВОЗМОЖНО";
                textBox6.ForeColor = Color.Gray;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "ВЫКУПИТЬ НЕВОЗМОЖНО")
            {
                textBox6.Text = "";
                textBox6.ForeColor = Color.Black;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "ДЕНЬГИ ЗА ВЕШЬ";
                textBox5.ForeColor = Color.Gray;
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "ДЕНЬГИ ЗА ВЕШЬ")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.Text = "ДАТА ПРОЦЕНТА";
                textBox7.ForeColor = Color.Gray;
            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox7.Text == "ДАТА ПРОЦЕНТА")
            {
                textBox7.Text = "";
                textBox7.ForeColor = Color.Black;
            }
        }

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
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
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
    }
    
}
