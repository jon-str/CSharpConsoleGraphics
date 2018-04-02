using STR_Games.TetrisTest;
using STR_GraphicsLib.STR_Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STR_GraphicsLib.STR_EntityComponents
{
    public static partial class STR_EntitySupport
    {
        public abstract class STR_DrawableEntity : STR_EntitySupport.STR_BaseEntity
        {
            protected STR_Bitmap<byte> mstrbmCanvas;

            protected const int mciPixelBufferStride = 4;

            protected int miPixelBufferSize;

            protected int miDelta;

            protected Bitmap mbmBitmap;
            protected Rectangle mrScreenRect;

            protected Random mRandom;

            public STR_DrawableEntity ( ) : base ( true , true )
            {
                miPixelBufferSize = this.GraphicsEngine.Window.WidthPx * this.GraphicsEngine.Window.HeightPx * mciPixelBufferStride;

                mstrbmCanvas = new STR_Bitmap<byte> ( this.GraphicsEngine , miPixelBufferSize );
                mbmBitmap = new Bitmap ( mstrbmCanvas.WidthPx , mstrbmCanvas.HeightPx );
                mrScreenRect = new Rectangle ( 0 , 0 , mbmBitmap.Width , mbmBitmap.Height );

                miDelta = 10;
                mRandom = new Random ( );
            }

            public override void Update ( )
            {
                miDelta = ( miDelta >= 0x100 ) ? 0x00 : miDelta + 1;
            }

            public STR_Bitmap<byte> Canvas { get => mstrbmCanvas; }
            public Bitmap Map { get => mbmBitmap; }
        }
    }
}
