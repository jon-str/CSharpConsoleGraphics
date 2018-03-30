using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_sandbox
{
    public static partial class STR_Entities
    {
        public abstract class STR_DrawableEntity : STR_Entities.STR_BaseEntity
        {
            public STR_DrawableEntity ( ) : base ( true , true ) { ; }
        }
    }
}
