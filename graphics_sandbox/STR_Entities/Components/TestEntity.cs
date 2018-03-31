using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STR_GraphicsLib.STR_EntityComponents
{
    public static partial class STR_EntitySupport
    {
        public class TestEntity : STR_EntitySupport.STR_DrawableEntity
        {
            private Bitmap mbmPixelMap1;

            private Bitmap mbmPixelMap2;

            private static Bitmap mbmBlackPixelMap;

            int delta = 10;

            private Random rnd;

            private enum BufferIndex
            {
                MAP_1 = 0
                , MAP_2 = 1
            }

            private BufferIndex mebiCurrentIndex;

            public TestEntity ( ) : base ( )
            {
                mbmBlackPixelMap = new Bitmap ( 640 , 480 , PixelFormat.Format24bppRgb );
                Clear ( ref mbmBlackPixelMap );

                mbmPixelMap1 = new Bitmap ( 640 , 480 , PixelFormat.Format24bppRgb );
                mbmPixelMap2 = new Bitmap ( 640 , 480 , PixelFormat.Format24bppRgb );

                ClearPixelMaps ( );

                mebiCurrentIndex = BufferIndex.MAP_1;

                rnd = new Random ( );
            }

            private Bitmap GetBufferToDraw ( )
            {
                switch ( mebiCurrentIndex )
                {
                    case BufferIndex.MAP_1:
                        mbmPixelMap1 = mbmBlackPixelMap;

                        mebiCurrentIndex = BufferIndex.MAP_2;
                        return mbmPixelMap2;

                    case BufferIndex.MAP_2:
                        mbmPixelMap2 = mbmBlackPixelMap;

                        mebiCurrentIndex = BufferIndex.MAP_1;
                        return mbmPixelMap1;

                    default:
                        throw new IndexOutOfRangeException ( "Tried to access unavailable buffer" );
                }
            }

            private void Fill ( int iColorHexValue , ref Bitmap rbmBitmapToFill )
            {
                for ( int y = 0 ; y < rbmBitmapToFill.Height ; y++ )
                {
                    for ( int x = 0 ; x < rbmBitmapToFill.Width ; x++ )
                    {
                        Color cColor = Color.FromArgb ( iColorHexValue );

                        rbmBitmapToFill.SetPixel ( x , y , cColor );
                    }
                }
            }

            private void Fill ( Color cColor , ref Bitmap rbmBitmapToFill )
            {
                for ( int y = 0 ; y < rbmBitmapToFill.Height ; y++ )
                {
                    for ( int x = 0 ; x < rbmBitmapToFill.Width ; x++ )
                    {
                        rbmBitmapToFill.SetPixel ( x , y , cColor );
                    }
                }
            }

            private void Clear ( ref Bitmap rbmBitmapToClear )
            {
                this.Fill ( Color.Black , ref rbmBitmapToClear );
            }

            private void ClearPixelMaps ( )
            {
                this.Fill ( Color.Black , ref mbmPixelMap1 );
                this.Fill ( Color.Black , ref mbmPixelMap2 );
            }

            public override void Draw ( )
            {
                //this.GraphicsEngine.Graphics.FillRectangle ( Brushes.Blue , 10 , 10 , 310 , 180 );



                Bitmap bmPixelBuffer = GetBufferToDraw ( );
                for ( int y = 0 ; y < bmPixelBuffer.Height ; y++ )
                {
                    for ( int x = 0 ; x < bmPixelBuffer.Width ; x++ )
                    {
                        //int iPixelIndex = ( y * bmPixelBuffer.Width + x );

                        byte bR = ( byte ) ( ( ( x + delta ) % 0x100 ) ^ ( ( y + delta ) % 0x100 ) );
                        byte bG = ( byte ) ( ( ( 2 * x + delta ) % 0x100 ) ^ ( ( 2 * y + delta ) % 0x100 ) );
                        byte bB = ( byte ) ( ( ( 50 + ( rnd.Next ( ) * 100 ) ) ) % 100 );

                        bB = ( byte ) ( ( bB + delta ) % 0x100 );

                        bmPixelBuffer.SetPixel ( x , y , ColorFromPackage ( bR , bG , bB ) );
                    }
                }

                Image oiImage = bmPixelBuffer;

                this.GraphicsEngine.Graphics.DrawImage ( oiImage , 0 , 0 , 640 , 480 );
            }

            private Color ColorFromPackage(byte bR, byte bG, byte bB)
            {
                return Color.FromArgb ( PackColor ( bR , bG , bB ));
            }

            private int PackColor ( byte bR , byte bG , byte bB )
            {
                int iTest = ( ( 0xFF << 24 ) | ( bR << 16 ) | ( bG << 8 ) | bB );
                { };

                return ( ( 0xFF << 24 ) | ( bR << 16 ) | ( bG << 8 ) | bB );
            }

            public override void Update ( )
            {
                return;
            }
        }
    }
}
