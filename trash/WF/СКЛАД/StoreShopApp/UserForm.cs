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

namespace StoreShopApp
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent(); // инициализируем форму
            MySqlConnection connection = new MySqlConnection(AuthorizationForm.connStr);
            connection.Open(); // открываем коннект 
            try
            {
                // серия запрососв на получение значений переменных Юзера из БД
                MySqlCommand n = new MySqlCommand("SELECT name FROM autho WHERE login = '" + AuthorizationForm.login + "';", connection);
                MySqlCommand s = new MySqlCommand("SELECT surname FROM autho WHERE login = '" + AuthorizationForm.login + "';", connection);
                MySqlCommand p = new MySqlCommand("SELECT patronymic FROM autho WHERE login = '" + AuthorizationForm.login + "';", connection);
                MySqlCommand ph = new MySqlCommand("SELECT phonenumber FROM autho WHERE login = '" + AuthorizationForm.login + "';", connection);
                MySqlCommand e = new MySqlCommand("SELECT email FROM autho WHERE login = '" + AuthorizationForm.login + "';", connection);
                string name, surname, patronymic;
                name = n.ExecuteScalar().ToString();
                surname = s.ExecuteScalar().ToString();
                patronymic = p.ExecuteScalar().ToString();
                label5.Text = AuthorizationForm.login;
                label6.Text = surname + " " + name + " " + patronymic;
                label7.Text = ph.ExecuteScalar().ToString();
                label8.Text = e.ExecuteScalar().ToString();
            }
            catch
            {
                // окно с выводом ошибки
                MessageBox.Show("Товара с таким кодом не существует");
            }
            finally
            {
                // закрываем коннект
                connection.Close();
            }
        }
    }
}
