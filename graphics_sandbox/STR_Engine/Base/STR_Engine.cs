using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using STR_GraphicsLib.STR_EntityComponents;
using STR_GraphicsLib.STR_Application.STR_ConsoleSuppport;

namespace STR_GraphicsLib.STR_Engine
{
    public abstract class STR_Engine
    {
        protected bool mbIsRunning;

        protected System.Drawing.Graphics mogGraphics;

        private STR_EntitySupport.EntityCollection moecEntities;

        public void Start ( )
        {
            if ( mbIsRunning )
            {
                return;
            }

            mogGraphics = STR_ConsoleSupport.CONSOLE_CONFIG.Graphics;

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

        protected STR_EntitySupport.EntityCollection Entities
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
