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
        public static class NATIVE_TYPES
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct CHAR_INFO
            {
                [MarshalAs ( UnmanagedType.ByValArray , SizeConst = 2 )]
                public byte [ ] charData;
                public short attributes;
            }

            [StructLayout ( LayoutKind.Sequential )]
            public struct COORD
            {
                public short X;
                public short Y;
            }

            [StructLayout ( LayoutKind.Sequential )]
            public struct SMALL_RECT
            {
                public short Left;
                public short Top;
                public short Right;
                public short Bottom;
            }

            [StructLayout(LayoutKind.Sequential)]
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
