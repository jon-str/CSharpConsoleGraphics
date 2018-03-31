using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

using STR_GraphicsLib.STR_Engine;
using STR_GraphicsLib.STR_ApplicationSupport;

namespace STR_GraphicsLib.STR_ApplicationSupport.STR_ConsoleSuppport
{
    public static partial class STR_ConsoleSupport
    {
        public class NATIVE_CONSOLE_CONFIG : STR_ConsoleEngineConfig
        {
            private int miLastWindowWidthColumns = 0;
            private int miLastWindowHeightRows = 0;

            private static BufferedGraphicsContext mobgcContext = null;

            private static NATIVE_CONSOLE_CONFIG mnccCurrentConfig = null;
            private static NATIVE_CONSOLE_CONFIG mnccLastConfig = null;
            private static NATIVE_CONSOLE_CONFIG mnccEmptyConfig = null;

            public NATIVE_CONSOLE_CONFIG ( string sWindowTitle , int iWindowWidthPx , int iWindowHeightPx) : this(sWindowTitle, iWindowWidthPx, iWindowHeightPx, true) {; }

            public NATIVE_CONSOLE_CONFIG ( string sWindowTitle , int iWindowWidthPx , int iWindowHeightPx , bool blApplyOnDemand ) : base(sWindowTitle, iWindowWidthPx, iWindowHeightPx )
            {
                if ( mnccEmptyConfig == null )
                {
                    mnccEmptyConfig = new NATIVE_CONSOLE_CONFIG ( );
                }
                msWindowTitle = sWindowTitle;

                miWindowWidthPx = iWindowWidthPx;
                miWindowHeightPx = iWindowHeightPx;

                if ( mopProcess == null )
                {
                    mopProcess = Process.GetCurrentProcess ( );
                }
                if ( mogGraphics == null )
                {
                    mogGraphics = Graphics.FromHdc ( STR_ConsoleSupport.NATIVE_METHODS.GetDC ( mopProcess.MainWindowHandle ) );
                }
                Console.CursorVisible = false;

                if ( mobgcContext == null )
                {
                    mobgcContext = BufferedGraphicsManager.Current;
                }

                this.WindowWidthColumns = Convert.ToInt32 ( ( float ) Math.Floor ( ( decimal ) ( Console.LargestWindowWidth * ( iWindowWidthPx / 1920f ) ) ) );
                this.WindowHeightRows = Convert.ToInt32 ( ( float ) Math.Floor ( ( decimal ) ( Console.LargestWindowHeight * ( iWindowHeightPx / 1080f ) ) ) );

                if ( blApplyOnDemand )
                {
                    if ( mnccCurrentConfig != null )
                    {
                        miLastWindowWidthColumns = mnccCurrentConfig.WindowWidthColumns;
                        miLastWindowHeightRows = mnccCurrentConfig.WindowHeightRows;
                        mnccLastConfig = mnccCurrentConfig;
                    }
                    this.Apply ( );
                }
                else
                {
                    mnccCurrentConfig = null;
                }
            }

            private NATIVE_CONSOLE_CONFIG ( ) : base ( string.Empty , 0 , 0 )
            {
                mopProcess = null;
                mogGraphics = null;

                mobgcContext = null;

                this.WindowWidthColumns = 0;
                this.WindowHeightRows = 0;

                mbHasBeenApplied = false;
            }

            public override STR_ApplicationConfig Apply ()
            {
                if ( this.mbHasBeenApplied )
                {
                    return ( STR_ConsoleSupport.NATIVE_CONSOLE_CONFIG ) this;
                }

                return ( STR_ConsoleSupport.NATIVE_CONSOLE_CONFIG ) Apply ( this );
            }

            public override STR_ApplicationConfig Apply ( STR_ApplicationConfig nccConfig )
            {
                if ( miWindowWidthPx <= 0 || miWindowHeightPx <= 0 )
                {
                    return mnccEmptyConfig;
                }

                miLastWindowWidthColumns = Console.WindowWidth;
                miLastWindowHeightRows = Console.WindowHeight;

                int iNewWindowWidthColumn = Convert.ToInt32 ( ( float ) Math.Floor ( ( decimal ) ( Console.LargestWindowWidth * ( miWindowWidthPx / 1920f ) ) ) );
                int iNewWindowHeightRows = Convert.ToInt32 ( ( ( float ) Math.Floor ( ( decimal ) ( Console.LargestWindowHeight * ( miWindowHeightPx / 1080f ) ) ) ) );// ) > Console.LargestWindowHeight ? Console.LargestWindowHeight : ( Console.LargestWindowHeight * ( iWindowHeightPx / 1080 ) );
                { }
                Console.WindowWidth = iNewWindowWidthColumn > Console.LargestWindowWidth ? Console.LargestWindowWidth : iNewWindowWidthColumn;
                Console.WindowHeight = iNewWindowHeightRows > Console.LargestWindowHeight ? Console.LargestWindowHeight : iNewWindowHeightRows;

                Debug.WriteLine ( string.Format ( "CW: {0}, PX: {1}, RATIO: {2} | CH: {3}, PX: {4}, RATIO: {5}" , Console.WindowWidth , miWindowWidthPx , miWindowWidthPx / Console.WindowWidth , Console.WindowHeight , miWindowHeightPx , miWindowHeightPx / Console.WindowHeight ) );

                mbHasBeenApplied = true;

                mnccCurrentConfig = (STR_ConsoleSupport.NATIVE_CONSOLE_CONFIG) nccConfig;

                return mnccCurrentConfig;
            }

            public static NATIVE_CONSOLE_CONFIG EmptyConfig { get => ( mnccEmptyConfig == null ) ? new NATIVE_CONSOLE_CONFIG ( ) : mnccEmptyConfig; }
            public static NATIVE_CONSOLE_CONFIG CurrentConfig
            {
                get => mnccCurrentConfig;
                set => mnccCurrentConfig = value;
            }

            public int LastWidthColumns { get => miLastWindowWidthColumns; }
            public int LastHeightRows { get => miLastWindowHeightRows; }

        }
    }
}
