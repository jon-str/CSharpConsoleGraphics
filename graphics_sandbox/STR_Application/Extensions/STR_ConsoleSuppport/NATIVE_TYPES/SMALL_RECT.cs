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
            public struct SMALL_RECT
            {
                public short Left;
                public short Top;
                public short Right;
                public short Bottom;

                public SMALL_RECT ( short sLeft , short sTop , short sRight , short sBottom )
                {
                    this.Left = sLeft;
                    this.Top = sTop;
                    this.Right = sRight;
                    this.Bottom = sBottom;
                }

                public short this [ int iIndex ]
                {
                    get
                    {
                        switch ( iIndex )
                        {
                            case 0:
                                return this.Left;

                            case 1:
                                return this.Top;

                            case 2:
                                return this.Right;

                            case 3:
                                return this.Bottom;

                            default:
                                throw new IndexOutOfRangeException ( string.Format ( "[ADDR] Index of small rect must be less than 4, [iIndex = {0}]" , iIndex ) );

                        }
                    }

                    set
                    {
                        switch ( iIndex )
                        {
                            case 0:
                                this.Left = value;
                                break;

                            case 1:
                                this.Top = value;
                                break;
                            case 2:
                                this.Right = value;
                                break;

                            case 3:
                                this.Bottom = value;
                                break;

                            default:
                                throw new IndexOutOfRangeException ( string.Format ( "[ASGN] Index of small rect must be less than 4, [iIndex = {0}]" , iIndex ) );

                        }
                    }
                }
            }
        }
    }
}
