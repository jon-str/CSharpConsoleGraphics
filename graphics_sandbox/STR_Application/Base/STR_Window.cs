using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using STR_GraphicsLib.STR_Engine;
using STR_GraphicsLib.STR_ApplicationSupport.STR_ConsoleSuppport;
using System.Drawing;

namespace STR_GraphicsLib.STR_ApplicationSupport
{
    public class STR_Window : STR_ConfigPackage
    {
        protected Graphics mogGraphics;

        //private string msWindowTitle;

        //private int miWindowWidth;
        //private int miWindowHeight;

        private int miLastWindowWidth;
        private int miLastWindowHeight;

        public STR_Window(string sWindowTitle, int iWindowWidthPx , int iHeigiWindowHeightPxht ) : base(sWindowTitle, iWindowWidthPx , iHeigiWindowHeightPxht )
        {
            msWindowTitle = sWindowTitle;

            miWindowWidthPx = iWindowWidthPx;
            miWindowHeightPx = iHeigiWindowHeightPxht;

            miLastWindowWidth = miWindowWidthPx;
            miLastWindowHeight = miWindowHeightPx;
        }

        public Graphics GraphicsContext { get => mogGraphics; }

        public int LastWidth { get => miLastWindowWidth; }
        public int LastHeight { get => miLastWindowHeight; }
    }

}
