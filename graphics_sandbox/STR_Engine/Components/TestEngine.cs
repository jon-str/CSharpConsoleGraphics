using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STR_GraphicsLib.STR_ApplicationSupport;
using STR_GraphicsLib.STR_ApplicationSupport.STR_ConsoleSuppport;

namespace STR_GraphicsLib.STR_Engine
{
    public class TestEngine : STR_Engine
    {
        #region Properties

        #region Public

        public int miScreenWidth;
        public int miScreenHeight;

        public STR_ConsoleSupport.NATIVE_TYPES.CHAR_INFO mciBuffScreen;
        public STR_ConsoleSupport.NATIVE_TYPES.SMALL_RECT msrWindowRect;

        public string msAppName; //should be wstring;

        public STR_ConsoleSupport.NATIVE_TYPES.CONSOLE_SCREEN_BUFFER_INFO mcsbiOriginalConsoleInfo;

        public STR_ConsoleSupport.NATIVE_TYPES.HANDLE mhOriginalConsole;  // implemented type

        public STR_ConsoleSupport.NATIVE_TYPES.HANDLE mhConsoleErr;  // plemented type
        public STR_ConsoleSupport.NATIVE_TYPES.HANDLE mhConsoleIn;  // plemented type
        public STR_ConsoleSupport.NATIVE_TYPES.HANDLE mhConsoleOut;  // demented type

        #endregion

        #region Private

        #endregion

        #endregion


        #region Constructors

        public TestEngine ( )
        {
            miScreenWidth = 80;
            miScreenHeight = 30;

            mhConsoleOut = STR_ConsoleSupport.NATIVE_METHODS.GetStdHandle ( STR_ConsoleSupport.NATIVE_FLAGS.STD_OUTPUT_HANDLE );
            mhConsoleIn = STR_ConsoleSupport.NATIVE_METHODS.GetStdHandle ( STR_ConsoleSupport.NATIVE_FLAGS.STD_INPUT_HANDLE );
            mhConsoleErr = STR_ConsoleSupport.NATIVE_METHODS.GetStdHandle ( STR_ConsoleSupport.NATIVE_FLAGS.STD_ERROR_HANDLE );

            msAppName = "Test Engine";
        }

        public override STR_Window AttachWindow ( )
        {
            throw new NotImplementedException ( );
        }

        #endregion

        #region Methods

        public int ConstructConsole ( int iWidth , int iHeight , int iFontWidth , int iFontHeight )
        {
            if ( mhConsoleOut == STR_ConsoleSupport.NATIVE_FLAGS.INVALID_HANDLE_VALUE )
            {
                return Error ( "Bad Handle" );
            }

            miScreenWidth = iWidth;
            miScreenHeight = iHeight;

            msrWindowRect = new STR_ConsoleSupport.NATIVE_TYPES.SMALL_RECT ( 0 , 0 , 1 , 1 );

            STR_ConsoleSupport.NATIVE_METHODS.SetConsoleWindowInfo ( mhConsoleOut , STR_ConsoleSupport.NATIVE_FLAGS.TRUE , ref msrWindowRect );

            return 1;
        }

        public override bool Init ( )
        {
            throw new NotImplementedException ( );
        }

        public override void Run ( )
        {
            throw new NotImplementedException ( );
        }

        #region Private

        private int Error ( string sMessage )
        {
            //get old console, print error message
            return 0;
        }

        #endregion

        #endregion
    }
}
