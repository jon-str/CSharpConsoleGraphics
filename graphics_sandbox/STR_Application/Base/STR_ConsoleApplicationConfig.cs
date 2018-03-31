using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using STR_GraphicsLib.STR_Engine;

namespace STR_GraphicsLib.STR_ApplicationSupport
{
    public abstract class STR_ConsoleApplicationConfig : STR_ApplicationConfig
    {
        private STR_ConsoleConfigPackage mstrcpConsoleConfigPackage = null;

        protected STR_ConsoleApplicationConfig ( string sWindowTitle , int iWindowWidthPx , int iWindowHeightPx ) : base ( sWindowTitle , iWindowWidthPx , iWindowHeightPx )
        {
            mstrcpConsoleConfigPackage = new STR_ConsoleConfigPackage ( sWindowTitle , iWindowWidthPx , iWindowHeightPx , 0 , 0 );
        }

        public int WindowWidthColumns
        {
            get => mstrcpConsoleConfigPackage.WindowWidthColumns;
            set => mstrcpConsoleConfigPackage.WindowWidthColumns = value;
        }
        public int WindowHeightRows
        {
            get => mstrcpConsoleConfigPackage.WindowHeightRows;
            set => mstrcpConsoleConfigPackage.WindowHeightRows = value;
        }
    }
}
