using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics_sandbox
{
    public abstract class Engine
    {
        protected bool mbIsRunning;

        protected System.Drawing.Graphics mogGraphics;

        private STR_Entities.EntityCollection moecEntities;

        public void Start ( )
        {
            if ( mbIsRunning )
            {
                return;
            }

            mogGraphics = STR_GraphicsLib.GraphicsConfig.Graphics;

            mbIsRunning = true;

            if ( !( this.Init ( ) ) )
            {
                throw new Exception ( "Failed to initialize Engine ... " );
            }

            this.Run ( );
        }
        public void Stop ( )
        {
            if ( !( mbIsRunning ) )
            {
                return;
            }

            mbIsRunning = false;
        }

        public abstract void Run ( );
        public abstract bool Init ( );

        protected STR_Entities.EntityCollection Entities
        {
            get => moecEntities;
            set => moecEntities = value;
        }

        public System.Drawing.Graphics Graphics { get => mogGraphics; }

        public bool IsRunning
        {
            get => mbIsRunning;
            set => mbIsRunning = value;
        }
    }
}
