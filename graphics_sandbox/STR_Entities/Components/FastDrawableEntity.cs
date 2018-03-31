using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;


namespace STR_GraphicsLib.STR_EntityComponents
{
    public static partial class STR_EntitySupport
    {
        public class FastDrawableEntity : STR_EntitySupport.STR_DrawableEntity
        {
            private static WriteableBitmap mwbWriteableBitmap;
            private static System.Drawing.Image miImage;

            public FastDrawableEntity ( )
            {
                //miImage = new System.Windows.Controls.Image ( );
                //RenderOptions.SetBitmapScalingMode ( miImage , BitmapScalingMode.NearestNeighbor );
                //RenderOptions.SetEdgeMode ( miImage , EdgeMode.Aliased );

                mwbWriteableBitmap = new WriteableBitmap ( 480 , 480 , 96 , 96 , PixelFormats.Bgr32 , null );

                //miImage = new System.Drawing.Image 
            }

            public override void Draw ( )
            {

            }

            public override void Update ( )
            {
                throw new NotImplementedException ( );
            }
        }

        public static class STR_WriteableBitmapyExtensions
        {

        }
    }
}
