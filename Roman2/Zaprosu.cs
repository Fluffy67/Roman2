using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roman1
{
    public partial class Zaprosu : Form
    {
        private const string connectionString = "Data Source=Student.db;Version=3;";

        public Zaprosu()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            Form fAuthorization = new Home();
            fAuthorization.Show();
            fAuthorization.FormClosed += new FormClosedEventHandler(form_FormClosed);
            this.Hide();
        }

        private void form_FormClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT FullName FROM Students WHERE SubjectName = 'Алгоритмы и структуры данных' AND PassMark = 'Сдано';";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    SQLiteDataReader reader = command.ExecuteReader();

                    StringBuilder results = new StringBuilder();
                    while (reader.Read())
                    {
                        string fullName = reader.GetString(0);
                        results.AppendLine(fullName);
                    }

                    label1.Text = results.ToString();
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT \"SubjectName\", (\"LectureHours\" + \"SeminarHour\" + \"LabHours\") AS \"TotalHours\" " +
                    "FROM \"Students\" " +
                    "WHERE \"FullName\" = 'Екатерина Сергеевна Петрова';";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    SQLiteDataReader reader = command.ExecuteReader();

                    StringBuilder results = new StringBuilder();
                    while (reader.Read())
                    {
                        string subjectName = reader.GetString(0);
                        int totalHours = reader.GetInt32(1);
                        string result = $"{subjectName}: {totalHours} hours";
                        results.AppendLine(result);
                    }

                    label1.Text = results.ToString();
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "SELECT DeaneryAddress FROM Deaneries;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    SQLiteDataReader reader = command.ExecuteReader();

                    StringBuilder results = new StringBuilder();
                    while (reader.Read())
                    {
                        string deaneryAddress = reader.GetString(0);
                        results.AppendLine(deaneryAddress);
                    }

                    label1.Text = results.ToString();
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine(ex.Message);
            }
        }
    }
}