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
using System.Xml;
using System.IO;


namespace StoreShopApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent(); // инициализация формы
            linkLabel1.Text = AuthorizationForm.login; // лейблу приписывается значение поля login (значение показывает, какой пользователь авторизован в данный момент) 
            if (AuthorizationForm.ch == true) // проверка на права Администратора (при значении поля ch = true - Юзеру открываются возможности редактирования, просмотра логов товара и авторизации)
            {
                button2.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
            }
            else // при значении поля ch = false кнопки редактирования, просмотра логов товара и авторизации неактивны
            {
                button2.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e) // textBox1_Leave и textBox1_Click -  методы (события), отвечающие за состояние текстбокса 1 при разных значениях
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Введите код товара";
            }
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите код товара")
            {
                textBox1.Text = "";
            }
        }
        private void limit_number(object sender, KeyPressEventArgs e) // метод (событие), отвечающий за ограничение вводимого текста в текстбокс1. Макс. длина текста составляет 9 символов, вводимый текст должен состоять только из цифр
        {
            textBox1.MaxLength = 9;
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == '\b'))
            {
                return;
            }
            else
            {
                e.Handled = true; // в случае, если вводимый текст не отвечает требованию условия, ввод блокируется
            }
        }
        private void link_event(object sender, LinkLabelLinkClickedEventArgs e) // метод (событие), позволяющее просмотреть информацию об авторизованном Юзере
        {
            UserForm u = new UserForm(); // открывает форму UserForm
            u.ShowDialog();
        }

        private void MainForm_Closed(object sender, FormClosedEventArgs e) // метод (событие), закрывающий программу при закрытии формы
        {
            Application.Exit(); 
        }

        private void button1_Click(object sender, EventArgs e) // метод (событие), обновляющий таблицу при нажатии на кнопку 1
        {
            MySqlConnection connection = new MySqlConnection(AuthorizationForm.connStr);
            connection.Open(); // открываем коннект
            MySqlCommand com = new MySqlCommand("select * from instore", connection); // запрос таблицы из БД
            MySqlDataAdapter dg = new MySqlDataAdapter(com);
            DataTable t = new DataTable();
            dg.Fill(t);
            dataGridView1.DataSource = t; // присваивание DataGridView 1 значений из таблицы
            button6.Enabled = true; // приводит кнопку 6 в активное состояние
            connection.Close(); // закрываем коннект
        }

        private void button2_Click(object sender, EventArgs e) // метод (событие), открывающий форму редактирования при нажатии на кнопку 2
        {
            EditingForm f = new EditingForm();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("LogUsers.txt", true);
            sw.WriteLine(DateTime.Now + " - смена пользователя");
            sw.WriteLine();
            sw.Close();
            Hide();
            AuthorizationForm a = new AuthorizationForm();
            a.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e) // метод (событие), позволяющий показать лог пользователей при нажатии на кнопку 4
        {
            
            StreamReader sr = new StreamReader("LogUsers.txt"); // открываем файл LogUsers.txt
            string line;
            listBox1.Items.Clear();
            while ((line = sr.ReadLine()) != null)
            {
                listBox1.Items.Add(line); // добавляем текст из файла в ЛистБокс 1
            }
            sr.Close(); // закрываем файл

        }

        private void button5_Click(object sender, EventArgs e) // метод (событие), позволяющий показать лог товаров при нажатии на кнопку 5
        {
            if (File.Exists("LogStore.txt") == false)
            {
                StreamWriter sw = new StreamWriter("LogStore.txt", true);
                sw.Close();
            }
            StreamReader sr = new StreamReader("LogStore.txt"); // открываем файл LogUsers.txt
            string line;
            listBox1.Items.Clear();
            while ((line = sr.ReadLine()) != null) 
            {
                listBox1.Items.Add(line); // добавляем текст из файла в ЛистБокс 1
            }
            sr.Close(); // закрываем файл
        }

        private void button6_Click(object sender, EventArgs e) // метод (событие), позволяющий найти товар в таблице DataGridView 1 при нажатии на кнопку 6
        {
            int findrow = 0; // объявление переменной findrow типа int с присвоение значение равного 0
            try
            {
                for (int col = 0; col < dataGridView1.Columns.Count; col++) // цикл, осуществляющий поиск значения из таблицы по коду товара введенного в текстбокс 1
                {
                    for (int row = findrow; row < dataGridView1.Rows.Count; row++)
                    {
                        if (dataGridView1[col, row].Value != null)
                        {
                            MessageBox.Show("Товар не найден");
                            return;
                        }
                        if (dataGridView1[col, row].Value.ToString() == textBox1.Text)
                        {
                            dataGridView1.CurrentCell = dataGridView1[col, row];
                            findrow = dataGridView1.CurrentRow.Index + 1;
                            return;
                        }
                    } 
                }
            }
            catch
            {
                // в случае возникновения ошибки из-за введения кода в неправильном формате откроется окно с сообщением об ошибке
                MessageBox.Show("Введите код товара в правильном формате");
            }
        }
    }
}
