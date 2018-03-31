using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using STR_GraphicsLib.STR_EntityComponents;
using System.Diagnostics;
using System.Threading;

namespace STR_GraphicsLib.STR_Engine
{
    public class STR_GraphicsEngine : STR_Engine
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
            this.Entities = new STR_EntitySupport.EntityCollection ( );
            this.Entities.Add ("en_TEST_ENTITY",  new STR_EntitySupport.TestEntity ( ) );

            return ( this.Entities.Size > 0 ) ? true : false;
        }

        public override void Run ( )
        {
            Stopwatch oStopwatch = new Stopwatch ( );
            oStopwatch.Start ( );

            int iFrames = 0;

            double dUnprocessedSeconds = 0;

            long lLastTime = oStopwatch.ElapsedNanoSeconds ( );

            double dSecondsPerTick = 1 / 60.0;

            int iTickCount = 0;

            while(this.IsRunning)
            {
                long lNow = oStopwatch.ElapsedNanoSeconds (  );
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
