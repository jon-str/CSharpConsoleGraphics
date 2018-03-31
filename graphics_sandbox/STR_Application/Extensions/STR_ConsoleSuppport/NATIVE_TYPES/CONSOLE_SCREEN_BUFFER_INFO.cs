using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace STR_GraphicsLib.STR_Application.STR_ConsoleSuppport
{
    public static partial class STR_ConsoleSupport
    {
        public static partial class NATIVE_TYPES
        {
            [StructLayout ( LayoutKind.Sequential )]
            public struct CONSOLE_SCREEN_BUFFER_INFO
            {
                public COORD dwSize;
                public COORD dwCursorPosition;
                public short wAttributes;
                public SMALL_RECT srWindow;
                public COORD dwMaximumWindowSize;
            }
        }
    }
}