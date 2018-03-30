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

        // - Array of STR_Entity, exposes STR_Entity[index]
        private STR_Entities.EntityCollection moecEntities;

        public STR_GraphicsEngine () : this (0, 0) { }

        public STR_GraphicsEngine(int iWindowWidth, int iWindowHeight)
        {
            //moWindow = new STR_Window ( iWindowWidth , iWindowHeight );
        }

        public override bool Init ( )
        {
            moecEntities = new STR_Entities.EntityCollection ( );
            moecEntities.Add ( new STR_Entities.TestEntity ( ) );

            return ( moecEntities.Size > 0 ) ? true : false;
        }

        public override void Run ( )
        {
            while(this.IsRunning)
            {
                moecEntities.Update ( );
                moecEntities.Draw ( );
            }
        }
    }
}
