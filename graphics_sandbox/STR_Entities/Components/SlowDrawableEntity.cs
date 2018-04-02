using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace STR_GraphicsLib.STR_EntityComponents
{
    public static partial class STR_EntitySupport
    {
        public class SlowDrawableEntity : STR_EntitySupport.STR_DrawableEntity
        {
            private const int mciWidthPx = 480;
            private const int mciHeightPx = mciWidthPx;

            public SlowDrawableEntity() : base( mciWidthPx , mciWidthPx) {; }

            public override void Draw ( )
            {
                BitmapData bmdRawData = mbmBitmap.LockBits ( mrScreenRect , ImageLockMode.ReadWrite , PixelFormat.Format32bppArgb );
                IntPtr iPtr = bmdRawData.Scan0;

                int iBytes = Math.Abs ( bmdRawData.Stride ) * bmdRawData.Height;
                int iTest = mstrbmCanvas.TotalPixels;
                { };

                Marshal.Copy ( iPtr , mstrbmCanvas.BufferArray , 0 , mstrbmCanvas.TotalPixels );

                for ( int y = 0 ; y < mstrbmCanvas.HeightPx ; y++ )
                {
                    for ( int x = 0 ; x < mstrbmCanvas.WidthPx ; x++ )
                    {
                        int iPixelIndex = ( y * mstrbmCanvas.WidthPx + x ) * 4;

                        byte byR = ( byte ) ( ( ( x + miDelta ) % 0x100 ) ^ ( ( y + miDelta ) % 0x100 ) );
                        byte byG = ( byte ) ( ( ( 2 * x + miDelta ) % 0x100 ) ^ ( ( 2 * y + miDelta ) % 0x100 ) );
                        byte byB = ( byte ) ( ( ( 50 + ( mRandom.Next ( ) * 100 ) ) ) % 0x100 );

                        byB = ( byte ) ( ( byB + miDelta ) % 0x100 );

                        mstrbmCanvas.BufferArray [ iPixelIndex ] = byR;
                        mstrbmCanvas.BufferArray [ iPixelIndex + 1 ] = byG;
                        mstrbmCanvas.BufferArray [ iPixelIndex + 2 ] = byB;
                        mstrbmCanvas.BufferArray [ iPixelIndex + 3 ] = 0xFF;
                    }
                }

                Marshal.Copy ( mstrbmCanvas.BufferArray , 0 , iPtr , mstrbmCanvas.TotalPixels );

                mbmBitmap.UnlockBits ( bmdRawData );

                this.GraphicsEngine.Window.GraphicsContext.DrawImage ( mbmBitmap , 0 , 0 , mstrbmCanvas.WidthPx , mstrbmCanvas.HeightPx );
            }

            public override void Update ( ) => miDelta = ( miDelta >= 0x100 ) ? 0x00 : miDelta + 1;
        }

    }
}
