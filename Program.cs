using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UserInput
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
            Application.Run(new User_LoginUp());


            //AdminSetUp()
            //AdminForm()
            //Admin_LogInUp()
            //User_LoginUp()
            //UserSetUp()
            //Dashboard_Admin()
            //FoodPackages()
         

            /*    Application.Run(new AdminForm());*/
        }
    }
}
