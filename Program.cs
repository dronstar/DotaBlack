//Class Program
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace black_jack
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_BJ());
        }
    }
}
