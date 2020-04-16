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
    public partial class Готовые_отчеты : MetroForm
    {
        public Готовые_отчеты()
        {
            InitializeComponent();
        }

        //Кнопка назад
        private void xuiButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main form2 = new Main();
            form2.Show();
        }

        //Без возврата
        private void xuiButton2_Click(object sender, EventArgs e)
        {

            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();

            MySqlCommand com = new MySqlCommand("SELECT `клиент`.`Имя`,`клиент`.`Паспорт`,`клиент`.`Телефон` FROM `договор`,`клиент` WHERE `клиент`.`ID_C`=`договор`.`ID_C` AND `договор`.`Возврат`=0", connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(com);
            DataTable ds = new DataTable();
            adapter.Fill(ds);



            string row = (ds.Rows.Count + 1).ToString();
            int row1 = Convert.ToInt32(row);
            string col = (ds.Columns.Count).ToString();
            int col1 = Convert.ToInt32(col);

            Word.Document doc = null;
            // Создаём объект приложения
            Word.Application app = new Word.Application();
            // Путь до шаблона документа
            string source = @"C:\Users\Vladimir\Desktop\Клиенты без возврата.docx";
            // Открываем
            doc = app.Documents.Open(source);
            doc.Activate();

            // Добавляем информацию
            // wBookmarks содержит все закладки
            Word.Document document = app.ActiveDocument;
            Word.Range range = app.Selection.Range;
            Object behiavor = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            Object autoFitBehiavor = Word.WdAutoFitBehavior.wdAutoFitFixed;

            document.Tables.Add(range, row1, col1, ref behiavor, ref autoFitBehiavor);

            document.Tables[1].Cell(1, 1).Range.Text = "Имя";
            document.Tables[1].Cell(1, 2).Range.Text = "Паспорт";
            document.Tables[1].Cell(1, 3).Range.Text = "Телефон";



            for (int i = 1; i < row1; i++)
                for (int j = 0; j < col1; j++)
                    document.Tables[1].Cell(i + 1, j + 1).Range.Text = ds.Rows[i - 1][j].ToString();

            doc.Close();
            doc = null;
            connection.Close();
            System.Diagnostics.Process.Start(@"C:\Users\Vladimir\Desktop\Клиенты без возврата.docx");

        }

        //С возвратом
        private void xuiButton3_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();

            MySqlCommand com = new MySqlCommand("SELECT `клиент`.`Имя`,`клиент`.`Паспорт`,`клиент`.`Телефон`, `договор`.`Процент30`, `договор`.`Дата_процента`,`договор`.`Дата_выкуп_невозм` FROM `договор`,`клиент` WHERE `клиент`.`ID_C`=`договор`.`ID_C` AND `договор`.`Возврат`=1", connection);
           
            MySqlDataAdapter adapter = new MySqlDataAdapter(com);
            DataTable ds = new DataTable();
            adapter.Fill(ds);



            string row = (ds.Rows.Count + 1).ToString();
            int row1 = Convert.ToInt32(row);
            string col = (ds.Columns.Count).ToString();
            int col1 = Convert.ToInt32(col);

            Word.Document doc = null;
            // Создаём объект приложения
            Word.Application app = new Word.Application();
            // Путь до шаблона документа
            string source = @"C:\Users\Vladimir\Desktop\Клиенты с возвратом.docx";
            // Открываем
            doc = app.Documents.Open(source);
            doc.Activate();

            // Добавляем информацию
            // wBookmarks содержит все закладки
            Word.Document document = app.ActiveDocument;
            Word.Range range = app.Selection.Range;
            Object behiavor = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            Object autoFitBehiavor = Word.WdAutoFitBehavior.wdAutoFitFixed;

            document.Tables.Add(range, row1, col1, ref behiavor, ref autoFitBehiavor);

            document.Tables[1].Cell(1, 1).Range.Text = "Имя";
            document.Tables[1].Cell(1, 2).Range.Text = "Паспорт";
            document.Tables[1].Cell(1, 3).Range.Text = "Телефон";
            document.Tables[1].Cell(1, 4).Range.Text = "Процент";
            document.Tables[1].Cell(1, 5).Range.Text = "Дата Зачисления процента";
            document.Tables[1].Cell(1, 6).Range.Text = "Дата с которой выкуп товара запрещен";



            for (int i = 1; i < row1; i++)
                for (int j = 0; j < col1; j++)
                    document.Tables[1].Cell(i + 1, j + 1).Range.Text = ds.Rows[i - 1][j].ToString();

            doc.Close();
            doc = null;
            connection.Close();
            System.Diagnostics.Process.Start(@"C:\Users\Vladimir\Desktop\Клиенты с возвратом.docx");
        }

        private void xuiButton4_Click(object sender, EventArgs e)
        {

            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();

            MySqlCommand com = new MySqlCommand("SELECT `товар`.`Name`,`товар`.`Категория`,`хранилище ломбарда`.`количество` FROM `хранилище ломбарда`,`товар` WHERE `товар`.`ID_T`=`хранилище ломбарда`.`ID_T` AND `хранилище ломбарда`.`количество`>0", connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(com);
            DataTable ds = new DataTable();
            adapter.Fill(ds);



            string row = (ds.Rows.Count + 1).ToString();
            int row1 = Convert.ToInt32(row);
            string col = (ds.Columns.Count).ToString();
            int col1 = Convert.ToInt32(col);

            Word.Document doc = null;
            // Создаём объект приложения
            Word.Application app = new Word.Application();
            // Путь до шаблона документа
            string source = @"C:\Users\Vladimir\Desktop\Отчёт по количеству товаров.docx";
            // Открываем
            doc = app.Documents.Open(source);
            doc.Activate();

            // Добавляем информацию
            // wBookmarks содержит все закладки
            Word.Document document = app.ActiveDocument;
            Word.Range range = app.Selection.Range;
            Object behiavor = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            Object autoFitBehiavor = Word.WdAutoFitBehavior.wdAutoFitFixed;

            document.Tables.Add(range, row1, col1, ref behiavor, ref autoFitBehiavor);

            document.Tables[1].Cell(1, 1).Range.Text = "Товар";
            document.Tables[1].Cell(1, 2).Range.Text = "Категория";
            document.Tables[1].Cell(1, 3).Range.Text = "Количество";



            for (int i = 1; i < row1; i++)
                for (int j = 0; j < col1; j++)
                    document.Tables[1].Cell(i + 1, j + 1).Range.Text = ds.Rows[i - 1][j].ToString();

            doc.Close();
            doc = null;
            connection.Close();
            System.Diagnostics.Process.Start(@"C:\Users\Vladimir\Desktop\Отчёт по количеству товаров.docx");
        }
    }
}
