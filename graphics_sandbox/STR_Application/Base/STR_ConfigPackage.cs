using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using STR_GraphicsLib.STR_Engine;

namespace STR_GraphicsLib.STR_ApplicationSupport
{
    public class STR_ConfigPackage
    {
        protected string msWindowTitle = string.Empty;

        protected int miWindowWidthPx = 0;
        protected int miWindowHeightPx = 0;

        public STR_ConfigPackage ( string sWindowTitle , int iWindowWidthPx , int iWindowHeightPx )
        {
            msWindowTitle = sWindowTitle;

            miWindowWidthPx = iWindowWidthPx;
            miWindowHeightPx = iWindowHeightPx;
        }

        public string WindowTitle { get => msWindowTitle; }
        public int WindowWidthPx { get => miWindowWidthPx; }
        public int WindowHeightPx { get => miWindowHeightPx; }
    }
}
