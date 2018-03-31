using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using STR_GraphicsLib.STR_EntityComponents;
using STR_GraphicsLib.STR_ApplicationSupport;
using STR_GraphicsLib.STR_ApplicationSupport.STR_ConsoleSuppport;
using System.Drawing;
using System.Diagnostics;

namespace STR_GraphicsLib.STR_Engine
{
    public abstract class STR_ConsoleEngineConfig : STR_ConsoleApplicationConfig
    {
        protected static Graphics mogGraphics = null;

        protected static Process mopProcess = null;

        public STR_ConsoleEngineConfig ( string sWindowTitle , int iWidth , int iHeight ) : base ( sWindowTitle , iWidth , iHeight ) {; }

        public Graphics GraphicsContext { get => mogGraphics; }
    }
}
