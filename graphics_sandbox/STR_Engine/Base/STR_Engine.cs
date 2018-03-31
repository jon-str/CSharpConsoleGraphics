using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using STR_GraphicsLib.STR_EntityComponents;
using STR_GraphicsLib.STR_ApplicationSupport;
using STR_GraphicsLib.STR_ApplicationSupport.STR_ConsoleSuppport;


namespace STR_GraphicsLib.STR_Engine
{
    public abstract class STR_Engine
    {
        protected bool          mbIsRunning = false;
        protected STR_Window    mstrWindow  = null;

        private STR_EntitySupport.EntityCollection moecEntities = null;

        public void Start ( )
        {
            if ( mbIsRunning )
            {
                return;
            }
            //STR_ConsoleSupport.NATIVE_CONSOLE.SetWindowSize ( 1024 , 768 );

            this.AttachWindow ( );

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

        public abstract STR_Window AttachWindow ( );

        public STR_Window AttachedWindow { get => mstrWindow;  }

        protected STR_EntitySupport.EntityCollection Entities
        {
            get => moecEntities;
            set => moecEntities = value;
        }

        public bool IsRunning
        {
            get => mbIsRunning;
            set => mbIsRunning = value;
        }
    }
}
