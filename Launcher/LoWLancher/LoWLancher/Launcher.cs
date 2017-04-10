using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LoWLancher
{
    class Launcher
    {
        public static void PlayGame()
        {
            try
            {
                Process.Start("game.exe");
                Environment.Exit(0);

            }
            catch { }

        }

    }
}
