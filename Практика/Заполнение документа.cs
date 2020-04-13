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
using Word = Microsoft.Office.Interop.Word;



namespace Практика
{
    public partial class Заполнение_документа : MetroForm
    {
        public Заполнение_документа()
        {
            InitializeComponent();
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `клиент`", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "клиент");
            

        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            

            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com = new MySqlCommand("SELECT * FROM `клиент`", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(com);
            DataTable ds = new DataTable();
            adapter.Fill(ds);



            string row = (ds.Rows.Count+1 ).ToString();
            int row1 = Convert.ToInt32(row);
            string col = (ds.Columns.Count ).ToString();
            int col1 = Convert.ToInt32(col);

            Word.Application application = new Word.Application();
            Object missing = Type.Missing;
            application.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            Word.Document document = application.ActiveDocument;
            Word.Range range = application.Selection.Range;
            Object behiavor = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            Object autoFitBehiavor = Word.WdAutoFitBehavior.wdAutoFitFixed;
            document.Tables.Add(range, row1, col1, ref behiavor, ref autoFitBehiavor);

            document.Tables[1].Cell(1, 1).Range.Text = "ID-КЛИЕНТА";
            document.Tables[1].Cell(1, 2).Range.Text = "ИМЯ";
            document.Tables[1].Cell(1, 3).Range.Text = "Паспорт";
            document.Tables[1].Cell(1, 4).Range.Text = "Телефон";

            for (int i = 1; i < row1; i++)
                for (int j = 0; j < col1; j++)
                    document.Tables[1].Cell(i + 1, j + 1).Range.Text = ds.Rows[i-1][j].ToString();

           
            application.Visible = true;
        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main form2 = new Main();
            form2.Show();
        }

        private void xuiButton3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
