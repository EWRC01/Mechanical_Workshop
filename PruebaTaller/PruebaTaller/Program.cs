using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaTaller
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 main = new Form1();
            main.FormClosed += Form1_Closed;
            main.Show();
            Application.Run();
        }
        private static void Form1_Closed(object sender, FormClosedEventArgs e)
        {
            ((Form)sender).FormClosed -= Form1_Closed;
            if (Application.OpenForms.Count==0)
            {
                Application.ExitThread();
            }
            else
            {
                Application.OpenForms[0].FormClosed += Form1_Closed;
            }
        }
    }
}
