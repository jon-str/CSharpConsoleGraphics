﻿using STR_Games.TetrisTest;
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

            //BYTE STRIDE, 4 BYTES PER DWORD
            protected const int mciBufferByteStride = 4;

            protected int miPixelBufferSize;

            protected int miDelta;

            protected Bitmap mbmBitmap;
            protected Rectangle mrScreenRect;

            protected Random mRandom;

            public STR_DrawableEntity ( int iWidthPx , int iHeightPx) : this(iWidthPx, iHeightPx, mciBufferByteStride) {; }

            public STR_DrawableEntity ( int iWidthPx , int iHeightPx, int iStride ) : base ( true , true )
            {
                miPixelBufferSize = iWidthPx * iHeightPx * iStride;

                mstrbmCanvas = new STR_Bitmap<byte> ( iWidthPx , iHeightPx , mciBufferByteStride );
                mbmBitmap = new Bitmap ( mstrbmCanvas.WidthPx , mstrbmCanvas.HeightPx );
                mrScreenRect = new Rectangle ( 0 , 0 , mbmBitmap.Width , mbmBitmap.Height );

                miDelta = 10;
                mRandom = new Random ( );
            }
            //public STR_Bitmap<byte> Canvas { get => mstrbmCanvas; }
            //public Bitmap Map { get => mbmBitmap; }
        }
    }
}
