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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent(); // инициализация формы

        }

        private void TextBoxes_TextChanged(object sender, EventArgs e) // метод (событие), контролирующее активность/неактивность кнопки 1. 
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox9.Text != "" && textBox10.Text != "")
            {
                button1.Enabled = true; // если все текстбоксы заполнены, то кнопка 1 активна
            }
            else
            {
                button1.Enabled = false; // в противном случае - неактивна
            }
        }
        private void lable10_Click(object sender, EventArgs e) // метод (событие), позволяющий открыть форму, при нажатии на лейбл 10
        {
            Hide(); // сворачивает текущую форму
        }

        private void button1_Click(object sender, EventArgs e) // метод (событие), позволяющий зарегестрировать нового пользователя
        {

            MySqlConnection connection = new MySqlConnection(AuthorizationForm.connStr);
            connection.Open(); // открытие коннекта
            try
            {
                string a = textBox5.Text + "@" + textBox9.Text + "." + textBox10.Text; // объявление переменной а строкового тива, которая содержит в себе значение email, которое пользователь вводит из текстбоксов 5, 9, 10
                if (textBox8.Text == "ADMIN") // проверка на пароль администратора, если Юзер введет пароль, то столбцу ch из таблицы БД присвоится значение 1
                {
                    // запрос на внесение новых строк в таблицу БД 
                    MySqlCommand ins = new MySqlCommand("INSERT INTO autho (login, name, surname, patronymic, email, phonenumber, password, ch) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + a + "','" + long.Parse(textBox6.Text) + "','" + textBox7.Text + "', 1)", connection);
                    ins.ExecuteNonQuery();
                    MessageBox.Show("Вы успешно зарегистрировались (admin) !"); // окно с сообщением об успешной регистрации
                    StreamWriter sw = new StreamWriter("LogUsers.txt", true); 
                    sw.WriteLine(DateTime.Now + " - зарегестрирован пользователь (admin) " + textBox1.Text); // внесение в файл LogUsers.txt данных о регистрации нового пользователя
                    sw.WriteLine();
                    sw.Close();
                }
                else // если юзер не введет пароль администратора, либо введет неверный пароль администратора, то столбцу ch из таблицы БД присвоится значение 0
                {
                    MySqlCommand ins = new MySqlCommand("INSERT INTO autho (login, name, surname, patronymic, email, phonenumber, password, ch) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + a + "','" + long.Parse(textBox6.Text) + "','" + textBox7.Text + "', 0)", connection);
                    ins.ExecuteNonQuery();
                    MessageBox.Show("Вы успешно зарегистрировались (user) !"); // окно с сообщением об успешной регистрации
                    StreamWriter sw = new StreamWriter("LogUsers.txt", true);
                    sw.WriteLine(DateTime.Now + " - зарегестрирован пользователь (user) " + textBox1.Text); // внесение в файл LogUsers.txt данных о регистрации нового пользователя
                    sw.WriteLine();
                    sw.Close();
                }
            }
            catch
            {
                // сообщение об ошибке
                MessageBox.Show("Ошибка регистрации, заполните форму полностью или проверте форматы исходных данных");
            }
            finally
            {
                // закрытие коннекта
                Close();
                connection.Close();
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)  // метод (событие), позволяющий открыть форму, при нажатии на PictureBox 8
        {
            {
                AboutApp f = new AboutApp(); 
                f.Show(); // открытие формы AboutApp
            }
        }

        private void limit_number(object sender, KeyPressEventArgs e) // метод (событие), ограничивающий длину текстбокса 6 в 11 символов. Также он не позволяет вводить никакие символы, кроме цифр
        {
            textBox6.MaxLength = 11;
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == '\b')) 
            {
                return;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void limit_all(object sender, KeyPressEventArgs e) // метод (событие), ограничивающий длины текстбоксов 1, 2, 3, 4, 7, 8 в 20 символов
        {
            textBox1.MaxLength = 20;
            textBox2.MaxLength = 20;
            textBox3.MaxLength = 20;
            textBox4.MaxLength = 20;
            textBox7.MaxLength = 20;
            textBox8.MaxLength = 20;
        }

        private void limit_email(object sender, KeyPressEventArgs e) // метод (событие), ограничивающий ввод в текстбоксы 5, 9 и 10 некоторых символов, а так же устанавливающий максимальную длину строки в 25 10 и 6 символов соответственно
        {
            if ((e.KeyChar == '@') | (e.KeyChar == '=') | (e.KeyChar == '/') | (e.KeyChar == ',') | (e.KeyChar == '<') | (e.KeyChar == '>') | (e.KeyChar == '?') | (e.KeyChar == '(') | (e.KeyChar == ')') | (e.KeyChar == '*') | (e.KeyChar == '&'))
            {
                e.Handled = true;
            }
            textBox5.MaxLength = 25;
            textBox9.MaxLength = 10;
            textBox10.MaxLength = 6;

        }
    }
}
