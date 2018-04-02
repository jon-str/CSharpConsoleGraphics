using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STR_Games.TetrisTest
{
    public class STR_PixelBuffer_DWORDS : STR_PixelBuffer_GEN<int>
    {
        public STR_PixelBuffer_DWORDS ( int iWidthPx , int iHeightPx ) : base ( iWidthPx , iHeightPx, 16 ) {; }

        //public override int ConvertToNumberValue ( int gen_Color )
        //{
            
        //}
    }
}
