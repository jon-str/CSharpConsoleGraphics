using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STR_GraphicsLib.STR_EntityComponents
{
    public static partial class STR_EntitySupport
    {
        public class EntityCollection : STR_EntitySupport.STR_BaseEntity
        {
            private Dictionary<string , STR_BaseEntity> modstrEntities;

            public EntityCollection ( ) : base ( true , true )
            {
                modstrEntities = new Dictionary<string , STR_BaseEntity> ( );

                this.Add ( "ent_EMPTY", new STR_EntitySupport.EmptyEntity ( ) );
            }

            public override void Draw ( )
            {
                foreach(KeyValuePair<string, STR_BaseEntity> kvp in modstrEntities)
                {
                    if(!(kvp.Value.IsDrawable))
                    {
                        continue;
                    }
                    kvp.Value.Draw ( );
                }
            }
            public override void Update ( )
            {
                foreach ( KeyValuePair<string , STR_BaseEntity> kvp in modstrEntities )
                {
                    if ( !( kvp.Value.IsUpdateable ) )
                    {
                        continue;
                    }
                    kvp.Value.Update ( );
                }

            }

            public void Add ( string sKey, STR_EntitySupport.STR_BaseEntity streEntity ) => modstrEntities.Add ( sKey, streEntity );
            public int Size { get => modstrEntities.Count; }

        }
    }
}
