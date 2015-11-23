using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheseusCompiled;

namespace TheseusFormed
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
            /*FrmMap theForm = new FrmMap();
            FileHandler filer = new FileHandler();
            filer.Init();
            filer.SetMap(0, "Map 2.");
            theForm.Init(0, "Map 2.");*/
            Application.Run(new FrmContainer());
        }
    }
}
