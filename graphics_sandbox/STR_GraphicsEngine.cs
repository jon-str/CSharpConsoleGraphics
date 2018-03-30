using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_sandbox
{
    public class STR_GraphicsEngine : Engine
    {
        // - WILL ACTUALLY IMPLEMENT
        //private STR_Window mowWindow;

        public STR_GraphicsEngine () : this (0, 0) { }

        public STR_GraphicsEngine(int iWindowWidth, int iWindowHeight)
        {
            //moWindow = new STR_Window ( iWindowWidth , iWindowHeight );
        }

        public override bool Init ( )
        {
            this.Entities = new STR_Entities.EntityCollection ( );
            this.Entities.Add ("en_TEST_ENTITY",  new STR_Entities.TestEntity ( ) );

            return ( this.Entities.Size > 0 ) ? true : false;
        }

        public override void Run ( )
        {
            while(this.IsRunning)
            {
                this.Entities.Update ( );
                this.Entities.Draw ( );
            }
        }
    }
}
