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
    class Program
    {
        internal static class NativeMethods
        {
            [DllImport ( "kernel32.dll" )]
            internal static extern IntPtr GetConsoleWindow ( );

            [DllImport ( "user32.dll" , CharSet = CharSet.Auto )]
            public static extern IntPtr GetDC ( IntPtr hWnd );
        }

        static System.Drawing.Graphics graphics;
        static BufferedGraphics bufferedGraphics;

        static void Main ( )
        {
            Console.CursorVisible = false;
            Process process = Process.GetCurrentProcess ( );
            Program.graphics = Graphics.FromHdc ( NativeMethods.GetDC ( process.MainWindowHandle ) );
            BufferedGraphicsContext context = BufferedGraphicsManager.Current;
            context.MaximumBuffer = new Size ( Console.WindowWidth , Console.WindowHeight );
            Program.bufferedGraphics = context.Allocate ( Program.graphics , new Rectangle ( 0 , 0 , 320 , 200 ) );
            while ( true )
            {
                graphics.FillRectangle ( Brushes.Blue , 0 - 10 , 0 - 10 , 20 , 20 );
            }
        }

        //private void Start()
        //{
        //    IntPtr ipHandle = NativeMethods.GetConsoleWindow ( );

        //}
}
}
