using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using STR_GraphicsLib;

namespace STR_Games.TetrisTest
{
    public class STR_PixelBuffer_GEN<T> where T : IConvertible
    {
        protected T [ ] m_gen_arr_Pixels;

        protected int miTotalPixels;

        protected int miStride;

        public STR_PixelBuffer_GEN ( int iWidthPx , int iHeightPx )
        {
            miTotalPixels = iWidthPx * iHeightPx;

            new STR_PixelBuffer_GEN<T> ( miTotalPixels );
            //m_gen_arr_Pixels = new T [ miTotalPixels ];

            //m_gen_arr_Pixels = Enumerable.Repeat<T> ( STR_Utilities.GenericTypeConverter<T , uint> ( ( uint ) COLORS.BLACK ) , miTotalPixels ).ToArray<T> ( );

            //miStride = Marshal.SizeOf ( default ( T ) );
        }

        public STR_PixelBuffer_GEN ( int iPixelBufferSize )
        {
            miTotalPixels = iPixelBufferSize;

            m_gen_arr_Pixels = new T [ miTotalPixels ];

            FillBlack ( );

            miStride = Marshal.SizeOf ( default ( T ) );
        }

        public void Fill ( T gen_ColorHexValue )
        {
            int iColor = STR_Utilities.GenericTypeConverter<int , T> ( gen_ColorHexValue );

            m_gen_arr_Pixels = Enumerable.Repeat<T> ( STR_Utilities.GenericTypeConverter<T , int> ( iColor ) , miTotalPixels ).ToArray<T> ( );

            //for ( int i = 0 ; i < miTotalPixels ; i++ )
            //{
            //    m_gen_arr_Pixels [ i ] = gen_ColorHexValue;
            //}
        }

        public void Fill ( int iXMin , int iYMin , int iXMax , int iYMax , T gen_ColorHexValue )
        {
            for ( int y = iYMin ; y < iYMax ; y++ )
            {
                for ( int x = iXMin ; x < iXMax ; x++ )
                {
                    m_gen_arr_Pixels [ STR_Utilities.Access1DArrayAs2D ( x , y , iXMax + iYMax ) ] = gen_ColorHexValue;
                }
            }
        }

        public T ColorFromNumberToGeneric<U> ( U gen_ColorHexValue ) => STR_Utilities.GenericCast<U , T>.Do ( gen_ColorHexValue );

        public void FillBlack ( ) => Fill ( ColorFromNumberToGeneric<uint> ( ( uint ) COLORS.BLACK ) );
        public void FillWhite ( ) => Fill ( ColorFromNumberToGeneric<uint> ( ( uint ) COLORS.WHITE ) );

        private enum COLORS : uint
        {
            BLACK = 0xFF00_0000
            , WHITE = 0xFFFF_FFFF
        }

        public T this [ int iIndex ]
        {
            get => m_gen_arr_Pixels [ iIndex ];
            set => m_gen_arr_Pixels [ iIndex ] = value;
        }

        public T [ ] Array { get => m_gen_arr_Pixels; }

        public int TotalPixels { get => miTotalPixels; }
    }
}
