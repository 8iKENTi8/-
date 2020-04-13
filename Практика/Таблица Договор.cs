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

            textBox1.Text = "ID-ДОГОВОРА";
            textBox2.Text = "ID-КЛИЕНТА";
            textBox3.Text = "ID-ТОВАРА";
            textBox4.Text = "ПРРОЦЕНТ 30%";
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
                xuiSwitch1.SwitchState = XanderUI.XUISwitch.State.On;
            }
            else
            {
                textBox6.ReadOnly = false; textBox7.ReadOnly = false; textBox4.ReadOnly = false;
                xuiSwitch1.SwitchState = XanderUI.XUISwitch.State.Off;
            }
        }

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

        //Button update
        private void button6_Click(object sender, EventArgs e)
        {
            if (xuiSwitch1.SwitchState == XanderUI.XUISwitch.State.On)
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

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
    
}
