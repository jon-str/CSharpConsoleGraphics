using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STR_Games.TetrisTest
{
    class STR_PixelBuffer_WORDS : STR_PixelBuffer_GEN<short>
    {
        public STR_PixelBuffer_WORDS ( int iWidthPx , int iHeightPx ) : base ( iWidthPx , iHeightPx ) {; }
    }
}
