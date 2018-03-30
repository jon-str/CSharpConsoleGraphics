using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_sandbox
{
    public static partial class STR_Entities
    {
        public class EntityCollection : STR_Entities.STR_BaseEntity
        {
            private List<STR_BaseEntity> moarrstreEntites;

            public EntityCollection ( ) : base ( true , true )
            {
                moarrstreEntites = new List<STR_BaseEntity> ( );

                this.Add ( new STR_Entities.EmptyEntity ( ) );
            }

            public override void Draw ( )
            {
                foreach ( STR_BaseEntity strE in moarrstreEntites )
                {
                    if ( !( strE.IsDrawable ) )
                    {
                        continue;
                    }

                    strE.Draw ( );
                }
            }
            public override void Update ( )
            {
                foreach ( STR_BaseEntity strE in moarrstreEntites )
                {
                    if ( !( strE.IsUpdateable ) )
                    {
                        continue;
                    }

                    strE.Update ( );
                }
            }

            public void Add ( STR_Entities.STR_BaseEntity streEntity ) => moarrstreEntites.Add ( streEntity );

            public int Size { get => moarrstreEntites.Count; }

        }
    }
}
