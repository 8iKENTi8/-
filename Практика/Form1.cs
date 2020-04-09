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
using MetroFramework.Components;

namespace Практика
{
    public partial class Main : MetroForm
    {
        public Main()
        {
            InitializeComponent();
            начало1.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Height = button4.Height;
            panel2.Top = button4.Top;
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Height = button2.Height;
            panel2.Top = button2.Top;
            работа_с_бд1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Height = button1.Height;
            panel2.Top = button1.Top;
            работа_с_док1.BringToFront();
        }
    }
}
