using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using STR_GraphicsLib;

namespace STR_Games.TetrisTest
{
    public class STR_PixelBuffer_BYTES : STR_PixelBuffer_GEN<byte>
    {
        public STR_PixelBuffer_BYTES ( int iWidthPx , int iHeightPx ) : base ( iWidthPx , iHeightPx, STR_Buffer.STRIDE.BYTE ) {; }
        public STR_PixelBuffer_BYTES ( int iBufferSize ) : base ( iBufferSize ) {; }
    }
}
