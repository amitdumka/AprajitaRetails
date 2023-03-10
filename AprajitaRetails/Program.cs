using System;
using System.Windows.Forms;

namespace AprajitaRetails
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main( )
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Logs.LogMe("Application Started");
            DataBase.DataBaseName = "aprajitaRetails";
            DBHelper.SetDataBaseName(DataBase.DataBaseName);
            Logs.LogMe("Database Name is Set:" + DBHelper.SqlDBName);
            Application.Run(new LoginForm());
            Logs.LogMe("Loading login Form");
        }
    }
}