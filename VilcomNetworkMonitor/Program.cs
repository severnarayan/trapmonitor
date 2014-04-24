using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VilcomNetworkMonitor
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Form6 p = new Form6();
            Random rnd = new Random();
            int timex = rnd.Next(1,5);

            DateTime end = DateTime.Now + TimeSpan.FromSeconds(4 + timex);
            p.Show();
            while (end > DateTime.Now)
            {
                Application.DoEvents();
            }
            p.Close();
            p.Dispose();     
             


            Application.Run(new Form1());
        }
    }
}
