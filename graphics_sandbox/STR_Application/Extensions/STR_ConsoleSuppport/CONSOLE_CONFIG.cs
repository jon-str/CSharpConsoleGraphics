using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

using STR_GraphicsLib.STR_Engine;

namespace STR_GraphicsLib.STR_Application.STR_ConsoleSuppport
{
    public static partial class STR_ConsoleSupport
    {
        public static class CONSOLE_CONFIG
        {
            private static bool                             mbIsInitialized = false;

            public static readonly System.Drawing.Graphics  mogGraphics;
            public static readonly BufferedGraphics         mobgBufferedGraphics;

            public static readonly STR_GraphicsEngine       mogeGraphicsEngine;

            public static readonly Process                  mopProcess;



            static CONSOLE_CONFIG()
            {
                if(mbIsInitialized)
                {
                    return;
                }

                STR_ConsoleSupport.CONSOLE_CONFIG.mopProcess = Process.GetCurrentProcess ( );

                STR_ConsoleSupport.CONSOLE_CONFIG.mogGraphics = Graphics.FromHdc ( STR_ConsoleSupport.NATIVE_METHODS.GetDC ( STR_ConsoleSupport.CONSOLE_CONFIG.mopProcess.MainWindowHandle ) );

                Console.CursorVisible = false;

                BufferedGraphicsContext obgcContext = BufferedGraphicsManager.Current;
                obgcContext.MaximumBuffer = new Size ( Console.WindowWidth , Console.WindowHeight );

                mbIsInitialized = true;
            }

            public static void Initialize ( )
            {

            }

            public static System.Drawing.Graphics Graphics { get => mogGraphics;  }

            public static bool IsInitialized
            {
                get => mbIsInitialized;
                set => mbIsInitialized = value;
            }
        }
    }
}
