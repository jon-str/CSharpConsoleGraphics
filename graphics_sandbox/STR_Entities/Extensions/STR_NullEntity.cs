using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_sandbox
{
    public static partial class STR_Entities
    {
        public abstract class STR_NullEntity : STR_Entities.STR_BaseEntity
        {
            public STR_NullEntity ( ) : base ( ) {; }

            public override void Draw ( ) => throw new NotImplementedException ( );
            public override void Update ( ) => throw new NotImplementedException ( );
        }
    }
}
