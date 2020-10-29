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
    public partial class AuthorizationForm : Form
    {
        internal static string login; // объявляем поле login - переменная, которая отслеживает под каким логином в систему зашел Юзер
        internal static bool ch; // объявляем поле ch - переменная, определяющая права Юзера (0 - "Пользователь", 1 - "Администратор")
        internal static string connStr = "server=localhost; user=root; database=InStore; port=3306;password=root"; // объявляем поле connStr - переменная, хранящая значение запроса для подключения к БД
        readonly MySqlConnection connection = new MySqlConnection(connStr); // создаем подключение (коннект)
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open(); // отрываем коннект
            MySqlCommand data = new MySqlCommand("SELECT login, password FROM autho WHERE login = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'", connection); //запрос на получение связки логин-пароль из БД
            MySqlCommand c = new MySqlCommand("SELECT ch FROM autho WHERE login = '" + textBox1.Text + "';", connection); //запрос на получение значения уровня доступа (0 - "Пользователь", 1 - "Администратор")
            ch = Convert.ToBoolean(c.ExecuteScalar()); // присваиваем ch значение уровня доступа, конвертированное в логическое значение
            MySqlDataReader reader = data.ExecuteReader(); // извлекаем из data значения в переменную reader
            login = textBox1.Text; // присваиваем login значение логина, авторизующегося Юзера
            if (reader.Read()) // проверка на существование связки логин-пароль
            {
                Hide(); // скрываем форму AuthorizationForm
                MainForm mainForm = new MainForm();
                mainForm.Show(); // открываем MainForm

                // создаем запись в текстовый файл LogUsers.txt
                StreamWriter sw = new StreamWriter("LogUsers.txt", true); 
                sw.WriteLine(DateTime.Now + " - авторизован пользователь " + textBox1.Text);
                sw.WriteLine();
                sw.Close(); // закрываем текстовый файл

            }
            else
            {
                MessageBox.Show("Пользователя с таким паролем не существует"); // сообщение об ошибке
            }
            connection.Close(); // закрываем коннект
        }

     

        private void label5_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration(); 
            reg.ShowDialog(); // открываем форму Registration
        }

        // далее 4 метода (события) определяют состояния лейблов 3 и 4 и текстбоксов 1 и 2 при различных взаимодействиях с ними
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Логин";
            }
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Логин")
            {
                textBox1.Text = "";
            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Пароль";
            }
        }
        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Пароль")
            {
                textBox2.Text = "";
            }
        }
        

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            AboutApp f = new AboutApp(); 
            f.Show(); // открываем форму AboutApp
        }

        private void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // свойство, при закрытии данной формы приложение закрывается
        }
    }
}
