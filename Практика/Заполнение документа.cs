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

        }

        //Кнопка добавить без возврата
        private void ch4()
        {
            //Добавление клиента
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `клиент` (`ID_C`, `Имя`, `Паспорт`, `Телефон`) VALUES (NULL, @na, @ph, @pa)", db.GetConnection());
            command.Parameters.Add("@na", MySqlDbType.VarChar).Value = textBox4.Text;
            command.Parameters.Add("@pa", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = textBox5.Text;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1) { MessageBox.Show("Аккаунт был создан"); }

            //Добавление Товара
            MySqlCommand com = new MySqlCommand("INSERT INTO `товар` (`ID_T`, `Name`, `Категория`) VALUES (NULL, @na, @pa)", db.GetConnection());
            com.Parameters.Add("@na", MySqlDbType.VarChar).Value = textBox2.Text;
            com.Parameters.Add("@pa", MySqlDbType.VarChar).Value = textBox3.Text;
            if (com.ExecuteNonQuery() == 1) { MessageBox.Show("Товар был создан"); }

            //Добавление договора
            MySqlCommand com2 = new MySqlCommand("SELECT * FROM `клиент`", db.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter(com2);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            int a = ds.Rows.Count - 1;

            MySqlCommand com3 = new MySqlCommand("SELECT * FROM `товар`", db.GetConnection());
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(com3);
            DataTable ds1 = new DataTable();
            adapter1.Fill(ds1);
            int a1 = ds1.Rows.Count - 1;

            MySqlCommand com1 = new MySqlCommand("INSERT INTO `договор` (`ID_D`, `ID_C`, `ID_T`, `Процент30`, `ДеньгиНаРуки`, `Возврат`, `Дата_выкуп_невозм`, `Дата_процента`) VALUES (NULL, @na, @id, NULL, @na2,0 , NULL, NULL)", db.GetConnection());
            com1.Parameters.Add("@ul", MySqlDbType.VarChar).Value = textBox1.Text;
            com1.Parameters.Add("@na", MySqlDbType.VarChar).Value = ds.Rows[0 + a][0].ToString();
            com1.Parameters.Add("@na1", MySqlDbType.VarChar).Value = textBox3.Text;
            com1.Parameters.Add("@na2", MySqlDbType.VarChar).Value = textBox7.Text;
            com1.Parameters.Add("@id", MySqlDbType.VarChar).Value = ds1.Rows[0 + a1][0].ToString(); ;
            if (com1.ExecuteNonQuery() == 1) { MessageBox.Show("Договор был добавлен"); }
            db.closeConnection();
        }

        //Кнопка добавить с возвратом
        private void ch5()
        {
            //Добавление клиента
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `клиент` (`ID_C`, `Имя`, `Паспорт`, `Телефон`) VALUES (NULL, @na, @ph, @pa)", db.GetConnection());
            command.Parameters.Add("@na", MySqlDbType.VarChar).Value = textBox4.Text;
            command.Parameters.Add("@pa", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = textBox5.Text;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1) { MessageBox.Show("Аккаунт был создан"); }

            //Добавление Товара
            MySqlCommand com = new MySqlCommand("INSERT INTO `товар` (`ID_T`, `Name`, `Категория`) VALUES (NULL, @na, @pa)", db.GetConnection());
            com.Parameters.Add("@na", MySqlDbType.VarChar).Value = textBox2.Text;
            com.Parameters.Add("@pa", MySqlDbType.VarChar).Value = textBox3.Text;
            if (com.ExecuteNonQuery() == 1) { MessageBox.Show("Товар был создан"); }

            //Добавление договора
            MySqlCommand com2 = new MySqlCommand("SELECT * FROM `клиент`", db.GetConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter(com2);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            int a = ds.Rows.Count - 1;

            MySqlCommand com3 = new MySqlCommand("SELECT * FROM `товар`", db.GetConnection());
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(com3);
            DataTable ds1 = new DataTable();
            adapter1.Fill(ds1);
            int a1 = ds1.Rows.Count - 1;

            MySqlCommand com1 = new MySqlCommand("INSERT INTO `договор` (`ID_D`, `ID_C`, `ID_T`, `Процент30`, `ДеньгиНаРуки`, `Возврат`, `Дата_выкуп_невозм`, `Дата_процента`) VALUES (NULL, @na, @id, @pr2, @na2,1, @pr, @pr1) ", db.GetConnection());
            com1.Parameters.Add("@na", MySqlDbType.VarChar).Value = ds.Rows[0 + a][0].ToString();
            com1.Parameters.Add("@na1", MySqlDbType.VarChar).Value = textBox3.Text;
            com1.Parameters.Add("@na2", MySqlDbType.VarChar).Value = textBox7.Text;
            com1.Parameters.Add("@pr", MySqlDbType.VarChar).Value = textBox9.Text;
            com1.Parameters.Add("@pr1", MySqlDbType.VarChar).Value = textBox8.Text;
            com1.Parameters.Add("@pr2", MySqlDbType.VarChar).Value = textBox10.Text;
            com1.Parameters.Add("@id", MySqlDbType.VarChar).Value = ds1.Rows[0 + a1][0].ToString();
            if (com1.ExecuteNonQuery() == 1) { MessageBox.Show("Аккаунт был добавлен"); }
            db.closeConnection();
        }
        private void xuiButton1_Click(object sender, EventArgs e)
        {
            if (xuiSwitch1.SwitchState == XanderUI.XUISwitch.State.Off)
                ch4();
            else
                ch5();

            DB db = new DB();
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root; database=практика");
            connection.Open();
            MySqlCommand com2 = new MySqlCommand("SELECT * FROM `клиент`", db.GetConnection());
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(com2);
            DataTable ds1 = new DataTable();
            adapter1.Fill(ds1);
            int a1 = ds1.Rows.Count - 1;
            MySqlCommand com = new MySqlCommand("SELECT `клиент`.`Имя`,`клиент`.`Паспорт`,`клиент`.`Телефон`,`товар`.`Name`,`товар`.`Категория` ,`договор`.`Дата_выкуп_невозм`,`договор`.`Дата_процента`,`договор`.`ДеньгиНаРуки`,`договор`.`Процент30` FROM `договор`,`клиент`,`товар` WHERE `клиент`.`ID_C`=`договор`.`ID_C` AND `договор`.`ID_T`=`товар`.`ID_T` AND `клиент`.`ID_C`=@id", connection);
            com.Parameters.Add("@id", MySqlDbType.VarChar).Value = ds1.Rows[0 + a1][0].ToString();
            MySqlDataAdapter adapter = new MySqlDataAdapter(com);
            DataTable ds = new DataTable();
            adapter.Fill(ds);



            string row = (ds.Rows.Count + 1).ToString();
            int row1 = Convert.ToInt32(row);
            string col = (ds.Columns.Count).ToString();
            int col1 = Convert.ToInt32(col);

            Word.Application application = new Word.Application();
            Object missing = Type.Missing;
            application.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            Word.Document document = application.ActiveDocument;
            Word.Range range = application.Selection.Range;
            Object behiavor = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            Object autoFitBehiavor = Word.WdAutoFitBehavior.wdAutoFitFixed;
            document.Tables.Add(range, row1, col1, ref behiavor, ref autoFitBehiavor);

            document.Tables[1].Cell(1, 1).Range.Text = "Имя";
            document.Tables[1].Cell(1, 2).Range.Text = "Паспорт";
            document.Tables[1].Cell(1, 3).Range.Text = "Телефон";
            document.Tables[1].Cell(1, 4).Range.Text = "Товар";
            document.Tables[1].Cell(1, 5).Range.Text = "Категория";
            document.Tables[1].Cell(1, 6).Range.Text = "Дата невозможности выкупа";
            document.Tables[1].Cell(1, 7).Range.Text = "Дата начала процента";
            document.Tables[1].Cell(1, 8).Range.Text = "Деньги за товар";
            document.Tables[1].Cell(1, 9).Range.Text = "Процент 30%";


            for (int i = 1; i < row1; i++)
                for (int j = 0; j < col1; j++)
                    document.Tables[1].Cell(i + 1, j + 1).Range.Text = ds.Rows[i - 1][j].ToString();


            application.Visible = true;
        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main form2 = new Main();
            form2.Show();
        }

        private void xuiSwitch1_Click(object sender, EventArgs e)
        {
            if (xuiSwitch1.SwitchState == XanderUI.XUISwitch.State.On)
            {
                textBox10.ReadOnly = false; textBox9.ReadOnly = false; textBox8.ReadOnly = false;
            }
            else
            {
                textBox10.ReadOnly = true; textBox9.ReadOnly = true; textBox8.ReadOnly = true;
                textBox10.Clear(); textBox9.Clear(); textBox8.Clear();
            }
        }

        private void xuiButton3_Click(object sender, EventArgs e)
        {
            Word.Application application = new Word.Application();


            Word.Document doc = null;

            object fileName = @"C:\Users\Vladimir\Desktop\1.docx";
            object falseValue = false;
            object trueValue = true;
            Object missing = Type.Missing;

            doc = application.Documents.Open(ref fileName, ref missing, ref trueValue,
            ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing);


            Microsoft.Office.Interop.Word.Table tbl = application.ActiveDocument.Tables[1];




            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tbl.Rows[i + 3].Cells[j + 1].Range.Text = "0";
                }





            }
        }

        private void xuiButton4_Click(object sender, EventArgs e)
        {
            Word.Application application = new Word.Application();

            Object missing = Type.Missing;
            object fileName = @"C:\Users\Vladimir\Desktop\1.docx";
            
            object trueValue = false;
            application.Documents.Open(ref fileName, ref missing, ref trueValue,
            ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing);

            Word.Document document = application.ActiveDocument;
            Word.Range range = application.Selection.Range;
            Object behiavor = Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            Object autoFitBehiavor = Word.WdAutoFitBehavior.wdAutoFitFixed;
            document.Tables.Add(range, 10, 10, ref behiavor, ref autoFitBehiavor);

            


            for (int i = 1; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    document.Tables[1].Cell(i + 1, j + 1).Range.Text = "0";

            
            application.Visible = true;

        }
    }
}
