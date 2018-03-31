using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STR_GraphicsLib.STR_EntityComponents
{
    public static partial class STR_EntitySupport
    {
        public abstract class STR_UpdateableEntity : STR_EntitySupport.STR_BaseEntity
        {
            public STR_UpdateableEntity ( ) : base ( false , true ) {; }

            public override void Draw ( ) => throw new NotImplementedException ( );
        }
    }
}
