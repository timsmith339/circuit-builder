using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuitry.Circuitry
{
    public class Switch : ISwitchable
    {
        /* PUBLIC */
        
        public event EventHandler<StateSwitchedEventArgs> StateSwitched;

        public State State { get; private set; }

        public Switch()
        {
            this.State = State.Off;
        }

        /* PRIVATE */

        public void SwitchStates()
        {
            this.State = (this.State == State.On) ? State.Off : State.On;
            
            if (StateSwitched != null)
                StateSwitched(this, new StateSwitchedEventArgs() { NewState = State });
        }
    }
}
