using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_sandbox
{
    public static partial class STR_Entities
    {
        public class TestEntity : STR_Entities.STR_DrawableEntity
        {
            public TestEntity ( ) : base ( ) {; }

            public override void Draw ( )
            {
                this.GraphicsEngine.Graphics.FillRectangle ( Brushes.Blue , 10 , 10 , 310 , 180 );
            }

            public override void Update ( )
            {
                return;
            }
        }
    }
}
