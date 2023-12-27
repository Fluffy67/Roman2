using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Roman1
{
    public partial class Registration : Form
    {
        private readonly string connString = @"Data Source=Student.db;Version=3;";
        private readonly SQLiteConnection connection;
        public Registration()
        {
            InitializeComponent();
        }

        private void Authorization_Click(object sender, EventArgs e)
        {
            Form fAuthorization = new Authorization();
            fAuthorization.Show();
            fAuthorization.FormClosed += new FormClosedEventHandler(form_FormClosed);
            this.Hide();
        }
        private void form_FormClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            string Login = LoginTextBox.Text.Trim();
            string Parol = PassTextBox.Text.Trim();

            // Проверяем, что поля логина и пароля не пустые
            if (Login == "" || Parol == "")
            {
                _ = MessageBox.Show("Заполните все поля");
                return;
            }

            // Формируем запрос на проверку наличия пользователя с таким же логином в базе данных
            string checkQuery = $"SELECT COUNT(*) FROM Users WHERE login='{Login}'";

            // Создаем новое подключение к базе данных SQLite
            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                // Открываем соединение с базой данных
                conn.Open();

                // Создаем новый объект команды SQL с запросом на проверку наличия пользователя с таким же логином в базе данных
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, conn))
                {
                    // Получаем результат выполнения запроса на проверку наличия пользователя с таким же логином в базе данных
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    // Проверяем, что пользователь с таким логином уже не зарегистрирован в базе данных
                    if (count > 0)
                    {
                        _ = MessageBox.Show("Пользователь с таким логином уже зарегистрирован");
                        return;
                    }
                }

                // Формируем запрос на добавление нового пользователя в базу данных
                string insertQuery = $"INSERT INTO Users (Login, Parol) VALUES ('{Login}', '{Parol}');";

                // Создаем новый объект команды SQL с запросом на добавление нового пользователя в базу данных
                using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conn))
                {
                    // Выполняем запрос на добавление нового пользователя в базу данных
                    _ = insertCmd.ExecuteNonQuery();
                }
            }
            Form fAuthorization = new Authorization();
            fAuthorization.Show();
            fAuthorization.FormClosed += new FormClosedEventHandler(form_FormClosed);
            this.Hide();
            // Выводим сообщение об успешной регистрации пользователя
            _ = MessageBox.Show("Вы успешно зарегистрировались");
        }
    }
   
}

