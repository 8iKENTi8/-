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

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main form2 = new Main();
            form2.Show();
        }

        private void xuiSwitch1_Click(object sender, EventArgs e)
        {
            if (textBox6.ReadOnly == false && textBox7.ReadOnly == false && textBox4.ReadOnly==false)
            {
                textBox6.ReadOnly = true; textBox7.ReadOnly = true; textBox4.ReadOnly = true; textBox4.Clear(); textBox6.Clear();textBox7.Clear();
            }
            else
            {
                textBox6.ReadOnly = false; textBox7.ReadOnly = false; textBox4.ReadOnly = false;
            }

            
        }
    }
    
}
