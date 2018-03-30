using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace graphics_sandbox
{
    public static partial class STR_GraphicsLib
    {
        public static class GraphicsConfig
        {
            private static bool                             mbIsInitialized = false;

            public static readonly System.Drawing.Graphics  mogGraphics;
            public static readonly BufferedGraphics         mobgBufferedGraphics;

            public static readonly STR_GraphicsEngine       mogeGraphicsEngine;

            public static readonly Process                  mopProcess;

            internal static class NativeMethods
            {
                [DllImport ( "user32.dll" , CharSet = CharSet.Auto )]
                public static extern IntPtr GetDC ( IntPtr hWnd );
            }

            static GraphicsConfig()
            {
                if(mbIsInitialized)
                {
                    return;
                }

                STR_GraphicsLib.GraphicsConfig.mopProcess = Process.GetCurrentProcess ( );

                STR_GraphicsLib.GraphicsConfig.mogGraphics = Graphics.FromHdc ( NativeMethods.GetDC ( STR_GraphicsLib.GraphicsConfig.mopProcess.MainWindowHandle ) );

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
