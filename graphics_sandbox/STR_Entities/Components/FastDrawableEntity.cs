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
        public class FastDrawableEntity : STR_EntitySupport.STR_DrawableEntity
        {
            private byte [ ] byarrPixelBuffer;

            private const int mciWidth = 480;
            private const int mciHeight = 480;

            private const int mciPixelBufferSize = mciWidth * mciHeight * mciBufferByteStride;

            private Random rnd;

            public FastDrawableEntity ( ) : base ( mciWidth , mciHeight, mciBufferByteStride )
            {
                byarrPixelBuffer = Enumerable.Repeat<byte> ( (byte) 0x00, mciPixelBufferSize ).ToArray();
                miDelta = 10;
                rnd = new Random ( );

                mbmBitmap = new Bitmap ( mciWidth , mciHeight );
                mrScreenRect = new Rectangle ( 0 , 0 , mbmBitmap.Width , mbmBitmap.Height );
            }

            public FastDrawableEntity ( int iWidthPx , int iHeightPx ) : base ( iWidthPx , iHeightPx )
            {
            }

            public override void Draw ( )
            {
                BitmapData bmdRawData = mbmBitmap.LockBits ( mrScreenRect , ImageLockMode.ReadWrite , PixelFormat.Format32bppArgb );
                IntPtr iPtr = bmdRawData.Scan0;

                int iBytes = Math.Abs ( bmdRawData.Stride ) * bmdRawData.Height;
                int iTest = byarrPixelBuffer.Length;
                { };

                Marshal.Copy(iPtr, byarrPixelBuffer, 0, byarrPixelBuffer.Length);

                for ( int y = 0 ; y < mciHeight ; y++ )
                {
                    for ( int x = 0 ; x < mciWidth ; x++ )
                    {
                        int iPixelIndex = ( y * mciWidth + x ) * 4;

                        byte byR = ( byte ) ( ( ( x + miDelta ) % 0x100 ) ^ ( ( y + miDelta ) % 0x100 ) );
                        byte byG = ( byte ) ( ( ( 2 * x + miDelta ) % 0x100 ) ^ ( ( 2 * y + miDelta ) % 0x100 ) );
                        byte byB = ( byte ) ( ( ( 50 + ( rnd.Next ( ) * 100 ) ) ) % 0x100 );

                        byB = ( byte ) ( ( byB + miDelta ) % 0x100 );

                        byarrPixelBuffer [ iPixelIndex ] = byR;
                        byarrPixelBuffer [ iPixelIndex + 1] = byG;
                        byarrPixelBuffer [ iPixelIndex + 2] = byB;
                        byarrPixelBuffer [ iPixelIndex + 3] = 0xFF;
                    }
                }

                Marshal.Copy ( byarrPixelBuffer , 0 , iPtr, byarrPixelBuffer.Length );

                mbmBitmap.UnlockBits ( bmdRawData );

                this.GraphicsEngine.Window.GraphicsContext.DrawImage ( mbmBitmap , 0 , 0 , mciWidth , mciHeight );
            }

            public override void Update ( ) => miDelta = ( miDelta >= 0x100 ) ? 0 : miDelta + 1;
        }
    }
}
