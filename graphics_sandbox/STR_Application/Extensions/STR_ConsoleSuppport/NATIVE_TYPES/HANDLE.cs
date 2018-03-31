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
            public struct HANDLE
            {
                IntPtr miptrValue;

                public HANDLE ( IntPtr iptrValue )
                {
                    miptrValue = iptrValue;
                }

                public static implicit operator HANDLE ( IntPtr iptrValue )
                {
                    return new HANDLE ( iptrValue );
                }

                public static implicit operator IntPtr ( HANDLE hnd )
                {
                    return hnd.miptrValue;
                }

                public static bool operator == ( HANDLE hnd , int iValue )
                {
                    return ( Marshal.ReadInt32 ( hnd.miptrValue ) == iValue );
                }

                public static bool operator != ( HANDLE hnd , int iValue )
                {
                    return ( Marshal.ReadInt32 ( hnd.miptrValue ) != iValue );
                }

            }
        }
    }
}
