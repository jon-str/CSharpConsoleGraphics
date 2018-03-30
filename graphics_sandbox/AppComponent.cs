using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_sandbox
{
    public static class AppComponent
    {
        private static STR_GraphicsEngine mstrgeEngine;
        public static STR_GraphicsEngine GraphicsEngine { get => mstrgeEngine; }

        static AppComponent ( ) => mstrgeEngine = new STR_GraphicsEngine ( );
    }
}
