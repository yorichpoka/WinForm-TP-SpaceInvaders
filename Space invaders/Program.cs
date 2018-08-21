using Space_invaders.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_invaders
{
    static class Program
    {
        // -- Formulaire principale -- //
        public static IpConfigForm formMain;
        // -- Formulaire serveur -- //
        public static AppForm formServer;
        // -- Formulaire client -- //
        public static AppForm formClient;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // -- Instance du formulaire principale -- //
            formMain = new IpConfigForm();

            // -- Reset des variables serveur et client -- //
            formClient = null;
            formServer = null;

            Application.Run(formMain);
        }
    }
}
