using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using STR_GraphicsLib.STR_Engine;

namespace STR_GraphicsLib.STR_ApplicationSupport
{
    public class STR_ConsoleConfigPackage : STR_ApplicationConfig
    {
        protected int miWindowWidthColumns = 0;
        protected int miWindowHeightRows = 0;

        public STR_ConsoleConfigPackage ( string sWindowTitle , int iWindowWidthPx , int iWindowHeightPx, int iWindowWidthColumns, int iWindowHeightRows ) : base ( sWindowTitle , iWindowWidthPx , iWindowHeightPx )
        {
            miWindowWidthColumns = iWindowWidthColumns;
            miWindowHeightRows = iWindowHeightRows;
        }

        public int WindowWidthColumns
        {
            get => miWindowWidthColumns;
            set => miWindowWidthColumns = value;
        }

        public int WindowHeightRows
        {
            get => miWindowHeightRows;
            set => miWindowHeightRows = value;
        }

        public override STR_ApplicationConfig Apply ( )
        {
            throw new NotImplementedException ( );
        }

        public override STR_ApplicationConfig Apply ( STR_ApplicationConfig stragConfig )
        {
            throw new NotImplementedException ( );
        }
    }
}
