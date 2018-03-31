using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STR_GraphicsLib.STR_EntityComponents
{
    public static partial class STR_EntitySupport
    {
        public class EmptyEntity : STR_EntitySupport.STR_NullEntity
        {
            public EmptyEntity() : base() {; }
        }
    }
}
