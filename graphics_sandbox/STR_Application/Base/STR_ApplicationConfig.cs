using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using STR_GraphicsLib.STR_Engine;

namespace STR_GraphicsLib.STR_ApplicationSupport
{
    public abstract class STR_ApplicationConfig : STR_ConfigPackage
    {
        protected bool mbHasBeenApplied = false;

        protected STR_ApplicationConfig ( string sWindowTitle , int iWidth , int iHeight ) : base ( sWindowTitle, iWidth, iHeight)
        {
            mbHasBeenApplied = false;
        }

        public STR_ApplicationConfig(STR_ConfigPackage strcpConfigPackage) : this (strcpConfigPackage.WindowTitle, strcpConfigPackage.WindowWidthPx , strcpConfigPackage.WindowHeightPx) {; }

        public abstract STR_ApplicationConfig Apply ( );
        public abstract STR_ApplicationConfig Apply ( STR_ApplicationConfig stragConfig );

        public bool HasBeenApplied
        {
            get => mbHasBeenApplied;
            set => mbHasBeenApplied = value;
        }
    }
}
