using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roman1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Authorization());
        }
    }
    static class database
    {
        public static string connectionString = @"Data Source=Student.db;Integrated Security=False; MultipleActiveResultSets=True";

    }


    static class table_students
    {
        public static string main = "Students";
        public static string idStudents = "idStudents";
        public static string FullName = "FullName";
        public static string Adress = "Adress";
        public static string NumberPhone = "NumberPhone";
        public static string SubjectName = "SubjectName";
        public static string PassMark = "PassMark";

    }

    static class table_dekanat
    {
        public static string main = "Deaneries";
        public static string idDeanery = "idDeanery";
        public static string DeaneryName = "DeaneryName";
        public static string DeaneryAddress = "DeaneryAddress";

    }
}
