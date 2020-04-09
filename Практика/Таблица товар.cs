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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main form2 = new Main();
            form2.Show();
        }

        //Кнопка добавить
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "ID-ТОВАРА") { MessageBox.Show("Введите ID - КЛИЕНТА"); textBox1.Focus(); return; }
            if (textBox2.Text == "ИМЯ") { MessageBox.Show("Введите Имя"); textBox2.Focus(); return; }
            if (textBox3.Text == "ПАСПОРТ") { MessageBox.Show("Введите Паспорт"); textBox3.Focus(); return; }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "ID-ТОВАРА") { MessageBox.Show("Введите ID - КЛИЕНТА"); textBox1.Focus(); return; }
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
    }
}
