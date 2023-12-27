using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roman1
{
    public partial class Students : Form
    {
        private SQLiteConnection Student;
        public Students()
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

        private async void Students_Load(object sender, EventArgs e)
        {
            Student = new SQLiteConnection(database.connectionString);
            await Student.OpenAsync();
            LoadingTable();
        }
        private async void LoadingTable()
        {
            {
                dataGridView1.Rows.Clear();
                SQLiteDataReader sqlReader = null;
                SQLiteCommand command = new SQLiteCommand($"SELECT * FROM [{table_students.main}]", Student);
                List<string[]> data = new List<string[]>();
                try
                {
                    sqlReader = (SQLiteDataReader)await command.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        data.Add(new string[6]);
                        //Указываем столбцы
                        data[data.Count - 1][0] = Convert.ToString($"{sqlReader[$"{table_students.idStudents}"]}");
                        data[data.Count - 1][1] = Convert.ToString($"{sqlReader[$"{table_students.FullName}"]}");
                        data[data.Count - 1][2] = Convert.ToString($"{sqlReader[$"{table_students.Adress}"]}");
                        data[data.Count - 1][3] = Convert.ToString($"{sqlReader[$"{table_students.NumberPhone}"]}");
                        data[data.Count - 1][4] = Convert.ToString($"{sqlReader[$"{table_students.SubjectName}"]}");
                        data[data.Count - 1][5] = Convert.ToString($"{sqlReader[$"{table_students.PassMark}"]}");

                    }

                    foreach (string[] s in data)
                    {
                        dataGridView1.Rows.Add(s);
                    }
                    dataGridView1.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", $"{ex.Source}");
                }
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();
                }
            }

        }
    }
}
