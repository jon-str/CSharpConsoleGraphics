using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using STR_GraphicsLib.STR_EntityComponents;
using System.Diagnostics;
using System.Threading;
using STR_GraphicsLib.STR_ApplicationSupport;
using STR_GraphicsLib.STR_ApplicationSupport.STR_ConsoleSuppport;

namespace STR_GraphicsLib.STR_Engine
{
    public class STR_GraphicsEngine : STR_Engine
    {
        private STR_ConsoleSupport.NATIVE_CONSOLE_CONFIG monccConsoleConfig;

        private Stopwatch moswStopwatch;

        public STR_GraphicsEngine ( string sWindowTitle , int iWindowWidthPx , int iWindowHeightPx )
        {
            monccConsoleConfig = new STR_ConsoleSupport.NATIVE_CONSOLE_CONFIG ( sWindowTitle , iWindowWidthPx , iWindowHeightPx , false );
            moswStopwatch = new Stopwatch ( );
        }

        public STR_GraphicsEngine ( STR_ConfigPackage strcpConfigPackage ) : this ( strcpConfigPackage.Title , strcpConfigPackage.WidthPx , strcpConfigPackage.HeightPx ) {; }

        public override bool Init ( )
        {
            this.Entities = new STR_EntitySupport.EntityCollection ( );
            this.Entities.Add ("en_TEST_ENTITY",  new STR_EntitySupport.FastDrawableEntity ( ) );
            //this.Entities.Add ( "en_TEST_ENTITY_2" , new STR_EntitySupport.SlowDrawableEntity ( ) );

            return ( this.Entities.Size > 0 ) ? true : false;
        }

        public override STR_Window AttachWindow ( )
        {
            mstrWindow = new STR_ConsoleWindow ( ( STR_ConsoleSupport.NATIVE_CONSOLE_CONFIG) monccConsoleConfig.Apply() );
            return mstrWindow;
            //mogGraphics = mstrWindow.GraphicsContext;
        }

        public override void Run ( )
        {          
            moswStopwatch.Start ( );

            int iFrames = 0;
            int iTickCount = 0;

            double dUnprocessedSeconds = 0;
            double dSecondsPerTick = 1 / 60.0;

            long lLastTime = moswStopwatch.ElapsedNanoSeconds ( );

            while(this.IsRunning)
            {
                long lNow = moswStopwatch.ElapsedNanoSeconds (  );
                long lPassedTime = lNow - lLastTime;

                lLastTime = lNow;

                if(lPassedTime < 0)
                {
                    lPassedTime = 0;
                }

                if ( lPassedTime > 100000000 )
                {
                    lPassedTime = 100000000;
                }

                dUnprocessedSeconds += lPassedTime / 1000000000.0;
                bool blTicked = false;

                while(dUnprocessedSeconds > dSecondsPerTick)
                {
                    this.Entities.Update ( );

                    dUnprocessedSeconds -= dSecondsPerTick;
                    blTicked = true;
                    iTickCount++;

                    if((iTickCount % 60) == 0)
                    {
                        Debug.WriteLine ( string.Format ( "FPS: {0}" , iFrames ));
                        lLastTime -= 1000;
                        iFrames = 0;
                    }
                }

                if(blTicked)
                {
                    this.Entities.Draw ( );
                    iFrames++;
                }
                else
                {
                    Thread.Sleep ( 1 );
                }               
            }
        }   
    }
}
