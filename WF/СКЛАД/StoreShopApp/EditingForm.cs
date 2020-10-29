using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace StoreShopApp
{
    public partial class EditingForm : Form
    {
        
        public EditingForm()
        {
            InitializeComponent(); // Инициализация формы EditingForm
        }


        private void TextBoxes_TextChanged(object sender, EventArgs e) // метод (событие) определяющий состояние кнопок поиска, редактирования, создания и удаления
        {
            // если текстбоксы заполнены, то кнопки создания и редактирования активны. В противном случае - не активны
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox6.Text != "") 
            {
                button2.Enabled = true; 
                button4.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
                button4.Enabled = false;
            }
            // если текстбокс 1 заполнен, то кнопки поиска и удаления активны. В противном случае - не активны
            if (textBox1.Text != "")
            {
                button1.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)  // поиск по коду товара
        {
            MySqlConnection connection = new MySqlConnection(AuthorizationForm.connStr); 
            connection.Open(); // открываем коннект
            try
            {   
                // серия запросов из БД, реализующих поиск по коду товара введенного в textbox1
                MySqlCommand n = new MySqlCommand("SELECT Name FROM instore WHERE Code = " + textBox1.Text + ";", connection);
                MySqlCommand d = new MySqlCommand("SELECT Description FROM instore WHERE Code = " + textBox1.Text + ";", connection);
                MySqlCommand pp = new MySqlCommand("SELECT Purchase FROM instore WHERE Code = " + textBox1.Text + ";", connection);
                MySqlCommand ps = new MySqlCommand("SELECT Sale FROM instore WHERE Code = " + textBox1.Text + ";", connection);
                MySqlCommand qs = new MySqlCommand("SELECT qshop FROM instore WHERE Code = " + textBox1.Text + ";", connection);
                MySqlCommand q1 = new MySqlCommand("SELECT qstore1 FROM instore WHERE Code = " + textBox1.Text + ";", connection);
                MySqlCommand q2 = new MySqlCommand("SELECT qstore2 FROM instore WHERE Code = " + textBox1.Text + ";", connection);
                MySqlCommand q3 = new MySqlCommand("SELECT qstore3 FROM instore WHERE Code = " + textBox1.Text + ";", connection);
                // присваивание значений товара текстбоксам 2-9
                textBox2.Text = n.ExecuteScalar().ToString();
                textBox3.Text = d.ExecuteScalar().ToString();
                textBox4.Text = pp.ExecuteScalar().ToString();
                textBox5.Text = ps.ExecuteScalar().ToString();
                textBox6.Text = qs.ExecuteScalar().ToString();
                textBox7.Text = q1.ExecuteScalar().ToString();
                textBox8.Text = q2.ExecuteScalar().ToString();
                textBox9.Text = q3.ExecuteScalar().ToString();
            }
            catch
            {
                // в случае некорректного запроса возникнет исключение, программа откроет окно с текстом об ошибке
                MessageBox.Show("Товара с таким кодом не существует");
            }
            finally
            {
                // независимо от выполнения/невыполнения запросов закрываем коннект
                connection.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e) // создание товара
        {
            MySqlConnection connection = new MySqlConnection(AuthorizationForm.connStr);
            connection.Open(); //открываем коннект
            try
            {
                // создаем запрос к БД, реализующий создание нового значения в таблице. Значения берутся из текстбоксов
                MySqlCommand ins = new MySqlCommand("INSERT INTO instore (Code, Name, Description, Purchase, Sale, qshop, qstore1, qstore2, qstore3) VALUES ('" + int.Parse(textBox1.Text) + "','" + textBox2.Text + "','" + textBox3.Text + "','" + int.Parse(textBox4.Text) + "','" + int.Parse(textBox5.Text) + "','" + int.Parse(textBox6.Text) + "','" + int.Parse(textBox7.Text) + "','" + int.Parse(textBox8.Text) + "','" + int.Parse(textBox9.Text) + "')", connection);
                ins.ExecuteNonQuery();
                MessageBox.Show("Товар - " + textBox2.Text + " с кодом " + textBox1.Text + " создан"); // сообщение об успешном создании товара

                StreamWriter sw = new StreamWriter("LogStore.txt", true); // создаем запись в текстовый файл LogUsers.txt
                sw.WriteLine(DateTime.Now + "- Товар - " + textBox2.Text + " с кодом " + textBox1.Text + " создан - by - " + AuthorizationForm.login);
                sw.WriteLine();
                sw.Close(); // закрываем текстовый файл

            }
            catch
            {
                // в случае некорректного запроса возникнет исключение, программа откроет окно с текстом об ошибке
                MessageBox.Show("Товар с данным кодом уже существует или код товара введен в неверном формате");
            }
            finally
            {
                // независимо от выполнения/невыполнения запросов закрываем коннект
                connection.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(AuthorizationForm.connStr);
            connection.Open(); // открываем коннект
            try
            {
                // создаем запрос к БД, реализующий удаление товара из таблицы. Значение берётся из текстбокса 1
                MySqlCommand del = new MySqlCommand("DELETE FROM instore WHERE Code = " + textBox1.Text + ";", connection);
                del.ExecuteNonQuery();
                MessageBox.Show("Товар - " + textBox2.Text + " с кодом " + textBox1.Text + " удален"); // сообщение об успешном удалении товара

                StreamWriter sw = new StreamWriter("LogStore.txt", true); // создаем запись в текстовый файл LogUsers.txt
                sw.WriteLine(DateTime.Now + " - Товар - " + textBox2.Text + " с кодом " + textBox1.Text + " удален - by - " + AuthorizationForm.login);
                sw.WriteLine();
                sw.Close(); // закрываем текстовый файл
            }
            catch
            {
                // в случае некорректного запроса возникнет исключение, программа откроет окно с текстом об ошибке
                MessageBox.Show("Товара с данным кодом не существует");
            }
            finally
            {
                // независимо от выполнения/невыполнения запросов закрываем коннект
                connection.Close();
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(AuthorizationForm.connStr);
            connection.Open(); //открываем коннект
            try
            {
                // создаем запрос к БД, реализующий редактирование товара. Значения берутся из текстбоксов
                MySqlCommand upd = new MySqlCommand("UPDATE instore SET Name = '" + textBox2.Text + "', Description = '" + textBox3.Text + "', Purchase = '" + textBox4.Text + "', Sale = '" + textBox5.Text + "', qshop = '" + textBox6.Text + "', qstore1 = '" + textBox7.Text + "', qstore2 = '" + textBox8.Text + "', qstore3 = '" + textBox9.Text + "' WHERE Code = " + textBox1.Text + ";", connection);
                upd.ExecuteNonQuery();
                MessageBox.Show("Товар - " + textBox2.Text + " с кодом " + textBox1.Text + " отредактирован"); // сообщение об успешном редактировании товара

                StreamWriter sw = new StreamWriter("LogStore.txt", true); // создаем запись в текстовый файл LogUsers.txt
                sw.WriteLine(DateTime.Now + " - Товар - " + textBox2.Text + " с кодом " + textBox1.Text + " отредактирован - by - " + AuthorizationForm.login);
                sw.WriteLine();
                sw.Close(); // закрываем текстовый файл
            }
            catch
            {
                // в случае некорректного запроса возникнет исключение, программа откроет окно с текстом об ошибке
                MessageBox.Show("Товара с данным кодом не существует");
            }
            finally
            {
                // независимо от выполнения/невыполнения запросов закрываем коннект
                connection.Close();
            }
        }
    }
}
