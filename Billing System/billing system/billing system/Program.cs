using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace billing_system
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new Login());
=======
            Application.Run(new Billingform("Walas Mama"));
>>>>>>> 1456a891b83874f8bda56f9d6eba023e3b416dbd

        }
    }
}
