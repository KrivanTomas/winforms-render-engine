using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformRender
{
    static class Program
    {
        /// <summary>
        /// windforms-reder-engine
        /// made by @cyanroke
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DebugWindow());
            Application.Run(new FastBitmapTest());
        }
    }
}
