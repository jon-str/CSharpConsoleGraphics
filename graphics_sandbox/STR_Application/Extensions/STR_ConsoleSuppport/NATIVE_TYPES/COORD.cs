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
        public static partial class NATIVE_TYPES
        {
            [StructLayout ( LayoutKind.Sequential )]
            public struct COORD
            {
                public short X;
                public short Y;
            }
        }
    }
}