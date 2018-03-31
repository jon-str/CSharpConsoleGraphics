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
    public class STR_Window
    {
        protected Graphics mogGraphics;

        private string msWindowTitle;

        private int miWindowWidth;
        private int miWindowHeight;

        private int miLastWindowWidth;
        private int miLastWindowHeight;

        public STR_Window(string sWindowTitle, int iWdith, int iHeight)
        {
            msWindowTitle = sWindowTitle;

            miWindowWidth = iWdith;
            miWindowHeight = iHeight;

            miLastWindowWidth = miWindowWidth;
            miLastWindowHeight = miWindowHeight;
        }

        public Graphics GraphicsContext { get => mogGraphics; }

        public string Title { get => msWindowTitle; }

        public int Width { get => miWindowWidth; }
        public int Height { get => miWindowHeight; }

        public int LastWidth { get => miLastWindowWidth; }
        public int LastHeight { get => miLastWindowHeight; }
    }

    public class STR_ConsoleWindow : STR_Window
    {

        public STR_ConsoleWindow ( STR_ConsoleSupport.NATIVE_CONSOLE_CONFIG nccConfig ) : base ( nccConfig.WindowTitle , nccConfig.WindowWidthPx , nccConfig.WindowHeightPx )
        {
            STR_ConsoleSupport.NATIVE_CONSOLE_CONFIG nccConsoleConfig; //= //new STR_ConsoleSupport.NATIVE_CONSOLE_CONFIG ( "TEST" , 640 , 640 );

            mogGraphics = nccConfig.GraphicsContext;
        }
    }
}
