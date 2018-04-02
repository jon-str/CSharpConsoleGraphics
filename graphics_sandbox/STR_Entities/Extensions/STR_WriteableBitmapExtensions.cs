using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Drawing;
using System.IO;

namespace STR_GraphicsLib.STR_Entities.Extensions
{
    public static class STR_WriteableBitmapExtensions
    {
        public static byte [ ] ToByteArray ( this WriteableBitmap wbBitmap, int iWidth, int iHeight )
        {
            int iStride = wbBitmap.PixelWidth * ( wbBitmap.Format.BitsPerPixel / 8 );
            byte [ ] byarrRawData = new byte [ iStride * wbBitmap.PixelHeight ]; // ARGB
            wbBitmap.CopyPixels ( new Int32Rect ( 0 , 0 , iWidth , iHeight ), byarrRawData , iStride , 0 );
            return byarrRawData;
        }

        public static void FromByteArray ( this WriteableBitmap wbBitmap , byte [ ] byarrRawData, int iWidth , int iHeight )
        {
            wbBitmap.WritePixels ( new Int32Rect ( 0 , 0 , iWidth , iHeight ) , byarrRawData , STR_Buffer.STRIDE.BYTE , 0 );
            //Buffer.BlockCopy ( buffer , 0 , bmp.Pixels , 0 , buffer.Length );
        }
    }

    public static class STR_SystemDrawingImageExtensions
    {
        public static Image FromByteArray(byte[] byarrSource)
        {
            using ( MemoryStream oMemStream = new MemoryStream ( byarrSource ) )
            {
                return Image.FromStream ( oMemStream );
            }
            
        }
    }
}
