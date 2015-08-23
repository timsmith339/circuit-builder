using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuitry.Circuitry
{
    public class Node : ISwitchable
    {
        /* PUBLIC */

        public event EventHandler<StateSwitchedEventArgs> StateSwitched;

        public State State { get; private set; }

        public Node()
        {
            this.State = State.Off;
        }

        public void SubscribeTo(ISwitchable aSwitchable)
        {
            if (aSwitchable == null)
                throw new ArgumentNullException("Need to supply a valid Node.");

            if (aSwitchable.State != this.State)
                SwitchStates();

            aSwitchable.StateSwitched += SubscribedStateSwitched;
        }


        /* PRIVATE */

        private void SwitchStates()
        {
            this.State = (this.State == State.On) ? State.Off : State.On;

            if (StateSwitched != null)
                StateSwitched(this, new StateSwitchedEventArgs() { NewState = State });
        }
                
        private void SubscribedStateSwitched(object sender, StateSwitchedEventArgs e)
        {
            SwitchStates();
        }
    }
}