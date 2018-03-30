using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_sandbox
{
    public static partial class STR_Entities
    {
        public class EmptyEntity : STR_Entities.STR_NullEntity
        {
            public EmptyEntity() : base() {; }
        }
    }
}
