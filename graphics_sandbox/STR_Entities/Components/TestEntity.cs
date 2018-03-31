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
        public class TestEntity : STR_EntitySupport.STR_DrawableEntity
        {
            private byte [ ] byarrPixelBuffer;

            private const int mciPixelBufferStride = 4;

            private const int mciWidth = 480;
            private const int mciHeight = 480;

            private const int mciPixelBufferSize = mciWidth * mciHeight * mciPixelBufferStride;

            private int miDelta;

            private Bitmap mbmBitmap;
            private Rectangle mrScreenRect;

            private Random rnd;

            public TestEntity ( ) : base ( )
            {
                byarrPixelBuffer = Enumerable.Repeat<byte> ( (byte) 0x00, mciPixelBufferSize ).ToArray();
                miDelta = 10;
                rnd = new Random ( );

                mbmBitmap = new Bitmap ( mciWidth , mciHeight );
                mrScreenRect = new Rectangle ( 0 , 0 , mbmBitmap.Width , mbmBitmap.Height );
            }

            public override void Draw ( )
            {
                //this.GraphicsEngine.Graphics.FillRectangle ( Brushes.Blue , 10 , 10 , 310 , 180 );

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


                this.GraphicsEngine.AttachedWindow.GraphicsContext.DrawImage ( mbmBitmap , 0 , 0 , mciWidth , mciHeight );
            }

            public override void Update ( )
            {
                miDelta = (miDelta >= 0x100) ? 0 : miDelta + 1;
                
            }

            public static Image ImageFromByteArray ( byte [ ] byarrSource )
            {
                using ( MemoryStream oMemStream = new MemoryStream ( byarrSource ) )
                {
                    return new Bitmap(oMemStream);
                }

            }
        }
    }
}
