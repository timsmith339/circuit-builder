using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuitry.Circuitry.Gates
{
    public class NotGate : ISwitchable
    {
        /* Public */

        public event EventHandler<StateSwitchedEventArgs> StateSwitched;

        public State State { get; private set; }

        public Node Input1 { get; private set; }

        public NotGate()
        {
            this.State = State.Off;
            this.Input1 = new Node();
            this.Input1.StateSwitched += SubscribedStateSwitched;
        }

        /* Private */

        private void EvaluateState()
        {
            if (Input1 == null)
                return;

            if (Input1.State == State.On && this.State == State.Off)
                SwitchStates();

            if (Input1.State == State.Off && this.State == State.On)
                SwitchStates();                
        }

        private void SwitchStates()
        {
            this.State = (this.State == State.On) ? State.Off : State.On;

            if (StateSwitched != null)
                StateSwitched(this, new StateSwitchedEventArgs() { NewState = State });
        }

        private void SubscribedStateSwitched(object sender, StateSwitchedEventArgs e)
        {
            EvaluateState();
        }
    }
}
