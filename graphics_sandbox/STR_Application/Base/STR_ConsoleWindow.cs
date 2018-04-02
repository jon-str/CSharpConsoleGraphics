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
    public class STR_ConsoleWindow : STR_Window
    {
        public STR_ConsoleWindow ( STR_ConsoleSupport.NATIVE_CONSOLE_CONFIG nccConfig ) : base ( nccConfig.Title , nccConfig.WidthPx , nccConfig.HeightPx ) => mogGraphics = nccConfig.GraphicsContext;
    }
}
