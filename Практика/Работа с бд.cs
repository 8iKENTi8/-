using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практика
{
    public partial class Работа_с_бд : UserControl
    {
        public Работа_с_бд()
        {
            InitializeComponent();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        //Таблицы клиент
        private void button2_Click(object sender, EventArgs e)
        {
            Main someForm = (Main)this.Parent;
            someForm.Hide();
            Таблица_клиент form2 = new Таблица_клиент();
            form2.Show();
            
        }

        //Таблицы товар
        private void button4_Click(object sender, EventArgs e)
        {
            Main someForm = (Main)this.Parent;
            someForm.Hide();
            Таблица_товар form2 = new Таблица_товар();
            form2.Show();
        }

        //Хранилище ломбарда
        private void button5_Click(object sender, EventArgs e)
        {
            Main someForm = (Main)this.Parent;
            someForm.Hide();
            Хранилище_ломбарда form2 = new Хранилище_ломбарда();
            form2.Show();
        }
    }
}
