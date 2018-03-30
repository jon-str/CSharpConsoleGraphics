using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_sandbox
{
    public static partial class STR_Entities
    {
        public abstract class STR_BaseEntity
        {
            protected static STR_GraphicsEngine mostrgeEngine;

            protected bool mbIsDrawable;
            protected bool mbIsUpdateable;

            public STR_BaseEntity ( bool blIsDrawable , bool blIsUpdateable )
            {
                mbIsDrawable = blIsDrawable;
                mbIsUpdateable = blIsUpdateable;

                //all drawables are updateable

                mostrgeEngine = AppComponent.GraphicsEngine;
            }

            public STR_BaseEntity ( bool blIsDrawable ) : this ( blIsDrawable , ( blIsDrawable == true ) ? true : false ) {; }

            public STR_BaseEntity ( ) : this ( false , false ) {; }

            public abstract void Draw ( );
            public abstract void Update ( );

            public bool IsDrawable { get => mbIsDrawable; }
            public bool IsUpdateable { get => mbIsUpdateable; }

            protected STR_GraphicsEngine GraphicsEngine { get => ( mostrgeEngine == null ) ? throw new NullReferenceException ( "AppComponent.GraphicsEngine == null ... [oops!!!]" ) : mostrgeEngine; }
        }
    }
}
