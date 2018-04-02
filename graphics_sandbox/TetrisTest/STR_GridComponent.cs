using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using STR_GraphicsLib;
using STR_GraphicsLib.STR_Engine;

namespace STR_Games.TetrisTest
{
    //    public abstract class STR_GridComponent : STR_Bitmap<byte>
    //    {
    //        protected readonly int blockSize;
    //        protected readonly int blockSizeSquared;

    //        protected readonly int gridWidth; //8
    //        protected readonly int gridHeight; //16
    //        protected readonly int gridSize; //gridWidth * gridHeight;
    //        protected readonly int gridLineColor; //0xFF0080FF;

    //        protected readonly int xAbsolute;
    //        protected readonly int yAbsolute;

    //        protected int blockDefaultColor;

    //        public GridComponent ( int blockSize , int gridWidth , int gridHeight , int gridLineColor , int xAbs , int yAbs ) : base ( ( ( blockSize * blockSize ) * gridWidth ) + 1 , ( ( blockSize * blockSize ) * gridHeight ) + 1 )
    //        {

    //            this.blockSize = blockSize;
    //            this.blockSizeSquared = ( blockSize * blockSize );

    //            this.gridWidth = gridWidth;
    //            this.gridHeight = gridHeight;
    //            this.gridSize = gridWidth * gridHeight;
    //            this.gridLineColor = gridLineColor;

    //            this.xAbsolute = xAbs;
    //            this.yAbsolute = yAbs;

    //            //not arg
    //            blockDefaultColor = 0xFF00FFFF;
    //        }

    //        protected void prepare ( )
    //        {
    //            this.Fill ( 0xFF000000 );
    //            this.drawGridLines ( );
    //        }

    //        private bool isGridLine ( int x , int y )
    //        {
    //            if ( x % ( blockSize * blockSize ) == 0 || y % ( blockSize * blockSize ) == 0 ) return true;

    //            return false;
    //        }

    //        public void drawGridLines ( )
    //        {
    //            for ( int y = 0 ; y < miHeightPx; y++ )
    //            {
    //                for ( int x = 0 ; x < miWidthPx ; x++ )
    //                {
    //                    if ( isGridLine ( x , y ) )
    //                    {
    //                        SetPixelAtCoord ( x , y , gridLineColor );
    //                    }
    //                }
    //            }
    //        }

    //        public void drawBlock ( int col , int row , int blockColor )
    //        {
    //            int xPix = ( ( col * blockSizeSquared ) );
    //            int yPix = ( ( row * blockSizeSquared ) + 1 );

    //            for ( int y = yPix ; y < yPix + blockSizeSquared - 1 ; ++y )
    //            {
    //                for ( int x = xPix ; x < xPix + blockSizeSquared ; ++x )
    //                {
    //                    if ( !isGridLine ( x , y ) )
    //                    {
    //                        SetPixelAtCoord ( x , y , blockColor );
    //                    }
    //                }
    //            }
    //        }

    //        public abstract void render ( );

    //        public int getBlockSize ( ) { return blockSize; }
    //        public int getBlockSizeSquared ( ) { return blockSizeSquared; }

    //        public int getGridWidth ( ) { return gridWidth; }
    //        public int getGridHeight ( ) { return gridHeight; }
    //        public int getGridSize ( ) { return gridSize; }
    //        public int getGridLineColor ( ) { return gridLineColor; }

    //        public int getXAbsolute ( ) { return xAbsolute; }
    //        public int getYAbsolute ( ) { return yAbsolute; }

    //    }
    //}
    //}
}
