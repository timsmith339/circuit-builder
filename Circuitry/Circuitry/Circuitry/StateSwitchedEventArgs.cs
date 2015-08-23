using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuitry.Circuitry
{
    public class StateSwitchedEventArgs : EventArgs
    {
        private State newState;
        public State NewState
        {
            get { return newState; }
            set { newState = value; }
        }
    }
}
