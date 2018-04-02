using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using STR_GraphicsLib;
using STR_GraphicsLib.STR_Engine;

namespace STR_Games.TetrisTest
{
    public class STR_Bitmap<T> where T : IConvertible
    {
        protected int miWidthPx;
        protected int miHeightPx;

        protected int miTotalPixels;

        protected int miPixelBufferStride;

        protected STR_PixelBuffer_GEN<T> m_strpb_gen_PixelBuffer;

        public STR_Bitmap ( int iWidthPx , int iHeightPx )
        {
            miWidthPx = iWidthPx;
            miHeightPx = iHeightPx;

            miTotalPixels = miWidthPx * miHeightPx;

            m_strpb_gen_PixelBuffer = new STR_PixelBuffer_GEN<T> ( iWidthPx , iHeightPx );

        }

        public STR_Bitmap ( STR_Engine streEngine , int iBufferSize )
        {
            miWidthPx = streEngine.Window.WidthPx;
            miHeightPx = streEngine.Window.HeightPx;

            //if ( iBufferSize != ( miWidthPx * miHeightPx ) ) 
            //{
            //    throw new Exception ( "TODO:MESSAGE" );
            //}

            miTotalPixels = iBufferSize;

            m_strpb_gen_PixelBuffer = new STR_PixelBuffer_GEN<T> ( iBufferSize );

        }

        public STR_Bitmap ( STR_Bitmap<T> strbmBitmap )
        {
            miWidthPx = strbmBitmap.miWidthPx;
            miHeightPx = strbmBitmap.miHeightPx;

            miTotalPixels = strbmBitmap.miWidthPx * strbmBitmap.miHeightPx;
            //miTotalPixels = strbmBitmap.TotalPixels; 

            if ( miTotalPixels != strbmBitmap.miTotalPixels )
            {
                throw new Exception ( "ERR" ); //TODO: write this message
            }

            m_strpb_gen_PixelBuffer = strbmBitmap.BufferObject;
        }

        public STR_Bitmap<T> Copy ( STR_Bitmap<T> strbmSourceBitmap ) => new STR_Bitmap<T> ( strbmSourceBitmap );

        public STR_Bitmap<T> Scale ( int iScaleFactor )
        {
            STR_Bitmap<T> strbmResult = new STR_Bitmap<T> ( miWidthPx * iScaleFactor , miHeightPx * iScaleFactor );

            for ( int y = 0 ; y < miHeightPx ; y++ )
            {
                for ( int x = 0 ; x < miWidthPx ; x++ )
                {
                    T gen_Color = GetPixelAtCoord ( x , y );
                    DrawScaledPixel ( strbmResult , iScaleFactor , x , y , gen_Color );
                }
            }

            return strbmResult;
        }

        public void ScaleBlock ( STR_Bitmap<T> strbmBitmap , int iScaleFactor , int iX , int iY , T gen_Color )
        {
            for ( int y = 0 ; y < iScaleFactor ; y++ )
            {
                for ( int x = 0 ; x < iScaleFactor ; x++ )
                {
                    strbmBitmap.SetPixelAtCoord ( x + iX , y + iY , gen_Color );
                }
            }
        }

        public void ScaleBlock ( int iScaleFactor , int iX , int iY , T gen_Color ) => ScaleBlock ( this , iScaleFactor , iX , iY , gen_Color );

        public STR_Bitmap<T> CopyScaled ( int iScaleFactor )
        {
            STR_Bitmap<T> strbmResult = new STR_Bitmap<T> ( miWidthPx * iScaleFactor , miHeightPx * iScaleFactor );

            for ( int y = 0 ; y < iScaleFactor ; y++ )
            {
                for ( int x = 0 ; x < iScaleFactor ; x++ )
                {
                    T gen_Color = this.GetPixelAtCoord ( x , y );

                    DrawScaledPixel ( strbmResult , iScaleFactor , x , y , gen_Color );
                }
            }

            return strbmResult;
        }

        private void DrawScaledPixel ( STR_Bitmap<T> strbmBitmap , int iScaleFactor , int iX , int iY , T gen_Color )
        {
            for ( int y = 0 ; y < iScaleFactor ; y++ )
            {
                for ( int x = 0 ; x < iScaleFactor ; x++ )
                {
                    strbmBitmap.SetPixelAtCoord ( x + iX , y + iY , gen_Color );
                }
            }
        }

        public void Blit ( STR_Bitmap<T> strbmBitmap , int iXOffset , int iYOffset )
        {
            for ( int y = 0 ; y < strbmBitmap.miHeightPx ; y++ )
            {
                int iYPixelCoord = y + iYOffset;
                if ( iYPixelCoord < 0 || iYPixelCoord > miHeightPx )
                {
                    continue;
                }

                for ( int x = 0 ; x < strbmBitmap.miWidthPx ; x++ )
                {
                    int iXPixelCoord = x + iXOffset;
                    if ( iXPixelCoord < 0 || iXPixelCoord > miWidthPx )
                    {
                        continue;
                    }
                    T gen_SourceColor = strbmBitmap.GetPixelAtCoord ( x , y );

                    this.SetPixelAtCoord ( x , y , gen_SourceColor );
                }
            }
        }

        public void DrawScaled ( STR_Bitmap<T> strbmBitmap , int iScaleFactor , int iXOffset , int iYOffset , int iXo , int iYo , int iW , int iH , T gen_Color )
        {
            for ( int y = 0 ; y < strbmBitmap.miHeightPx * iScaleFactor ; y++ )
            {
                int iYPixelCoord = y + iYOffset;
                if ( iYPixelCoord < 0 || iYPixelCoord > miHeightPx )
                {
                    continue;
                }

                for ( int x = 0 ; x < strbmBitmap.miWidthPx * iScaleFactor ; x++ )
                {
                    int iXPixelCoord = x + iXOffset;
                    if ( iXPixelCoord < 0 || iXPixelCoord > miWidthPx )
                    {
                        continue;
                    }
                    T gen_SourceColor = strbmBitmap.GetPixelAtCoord ( x / iScaleFactor + iXo , y / iScaleFactor * iYo );

                    int iColor = ( STR_Utilities.GenericCast<T , int>.Do ( gen_SourceColor ) ) * ( STR_Utilities.GenericCast<T , int>.Do ( gen_Color ) );

                    this.SetPixelAtCoord ( x , y , STR_Utilities.GenericCast<int , T>.Do ( iColor ) );
                }
            }
        }

        public void Draw ( STR_Bitmap<T> strbmBitmap , int iXOffset , int iYOffset , int iXo , int iYo , int iW , int iH , T gen_Color )
        {
            for ( int y = 0 ; y < strbmBitmap.miHeightPx ; y++ )
            {
                int iYPixelCoord = y + iYOffset;
                if ( iYPixelCoord < 0 || iYPixelCoord > miHeightPx )
                {
                    continue;
                }

                for ( int x = 0 ; x < strbmBitmap.miWidthPx ; x++ )
                {
                    int iXPixelCoord = x + iXOffset;
                    if ( iXPixelCoord < 0 || iXPixelCoord > miWidthPx )
                    {
                        continue;
                    }
                    T gen_SourceColor = strbmBitmap.GetPixelAtCoord ( x , y );

                    int iColor = ( STR_Utilities.GenericCast<T , int>.Do ( gen_SourceColor ) ) * ( STR_Utilities.GenericCast<T , int>.Do ( gen_Color ) );

                    this.SetPixelAtCoord ( x , y , STR_Utilities.GenericCast<int , T>.Do ( iColor ) );
                }
            }
        }

        public T[] BufferArray { get => m_strpb_gen_PixelBuffer.Array; }

        public STR_PixelBuffer_GEN<T> BufferObject { get => m_strpb_gen_PixelBuffer; }

        public T GetPixelAtCoord ( int iX , int iY ) => m_strpb_gen_PixelBuffer [ CoordToPixelBufferIndex ( iX , iY ) ];
        public T SetPixelAtCoord ( int iX , int iY , T gen_Color ) => m_strpb_gen_PixelBuffer [ CoordToPixelBufferIndex ( iX , iY ) ] = gen_Color;

        public int CoordToPixelBufferIndex ( int iX , int iY ) => STR_Utilities.Access1DArrayAs2D ( iX , iY , miWidthPx );

        public int WidthPx { get => miWidthPx; }
        public int HeightPx { get => miHeightPx; }

        public int PixelBufferStride { get => miPixelBufferStride; }

        public int TotalPixels { get => miTotalPixels; }
    }
}

