using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace STR_GraphicsLib.STR_ApplicationSupport.STR_ConsoleSuppport
{
    public static partial class STR_ConsoleSupport
    {
        public static class NATIVE_METHODS
        {
            [DllImport ( "kernel32.dll" , SetLastError = true )]
            public static extern int SetConsoleWindowInfo ( STR_ConsoleSupport.NATIVE_TYPES.HANDLE hConsoleOutput , int bAbsolute , ref STR_ConsoleSupport.NATIVE_TYPES.SMALL_RECT lpConsoleWindow );

            [DllImport ( "kernel32.dll" , SetLastError = true )]
            private static extern bool ReadConsoleOutput ( IntPtr hConsoleOutput , IntPtr lpBuffer , STR_ConsoleSupport.NATIVE_TYPES.COORD dwBufferSize , STR_ConsoleSupport.NATIVE_TYPES.COORD dwBufferCoord , ref STR_ConsoleSupport.NATIVE_TYPES.SMALL_RECT lpReadRegion );

            [DllImport ( "kernel32.dll" ,
                EntryPoint = "GetStdHandle" ,
                SetLastError = true ,
                CharSet = CharSet.Auto ,
                CallingConvention = CallingConvention.StdCall )]
            public static extern IntPtr GetStdHandle ( int nStdHandle );

            [DllImport ( "user32.dll" , CharSet = CharSet.Auto )]
            public static extern IntPtr GetDC ( IntPtr hWnd );
        }
    }
}
