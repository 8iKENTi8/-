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
    public partial class работа_с_док : UserControl
    {
        public работа_с_док()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main someForm = (Main)this.Parent;
            someForm.Hide();
            Заполнение_документа form2 = new Заполнение_документа();
            form2.Show();
        }
    }
}
