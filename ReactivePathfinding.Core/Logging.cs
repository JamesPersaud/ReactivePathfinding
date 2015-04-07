using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactivePathfinding.Core
{
    /// <summary>
    /// This class provides simple text logging from the core module to 
    /// any listening front end app
    /// </summary>    
    public class Logging
    {
        public delegate void LogEventHandler(string s);

        public event LogEventHandler Logged;

        public void Log(string s)
        {
            Logged(s);
        }

        private static Logging instance = null;
        public static Logging Instance
        {
            get
            {
                if (instance == null)
                    instance = new Logging();

                return instance;
            }            
        }
    }
}
