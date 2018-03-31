using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using STR_GraphicsLib.STR_Engine;
using STR_GraphicsLib.STR_ApplicationSupport.STR_ConsoleSuppport;

namespace STR_GraphicsLib.STR_ApplicationSupport
{
    public enum STR_ConfigMode
    {
        APP = 0
        ,ENGINE = 1
    }

    public enum STR_ConfigStatus
    {
        CONSOLE = 0
        ,DEFAULT = 1
    }

    public static class STR_ConfigManager
    {
        public static STR_ApplicationConfig NewConfig(string sWindowTitle, int iWindowWidth, int iWindowHeight, STR_ConfigMode estrscMode, STR_ConfigStatus estrcsStatus)
        {
            switch(estrscMode)
            {
                case STR_ConfigMode.APP:
                    goto default;

                case STR_ConfigMode.ENGINE:
                    return ( STR_ConsoleSupport.NATIVE_CONSOLE_CONFIG ) new STR_ConsoleSupport.NATIVE_CONSOLE_CONFIG ( sWindowTitle , iWindowWidth , iWindowHeight );

                default:
                    return null;
            }
        }

        public static STR_ApplicationConfig BuildFromConfigPackage ( STR_ConfigPackage strcpConfigPackage, STR_ConfigMode estrscMode , STR_ConfigStatus estrcsStatus )
        {
            return NewConfig ( strcpConfigPackage.WindowTitle, strcpConfigPackage.WindowWidthPx, strcpConfigPackage.WindowHeightPx , estrscMode , estrcsStatus );
        }
    }
}
