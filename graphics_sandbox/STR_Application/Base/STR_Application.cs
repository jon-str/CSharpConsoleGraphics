using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using STR_GraphicsLib.STR_Engine;

namespace STR_GraphicsLib.STR_Application
{
    public static class STR_Application
    {
        private static STR_GraphicsEngine mstrgeEngine;
        public static STR_GraphicsEngine GraphicsEngine { get => mstrgeEngine; }

        static STR_Application ( ) => mstrgeEngine = new STR_GraphicsEngine ( );
    }
}
