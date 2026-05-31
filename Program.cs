using EverpineHotelManagement.Data;
using EverpineHotelManagement.Forms;
using System;
using System.Windows.Forms;

namespace EverpineHotelManagement
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            DatabaseInitializer.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
