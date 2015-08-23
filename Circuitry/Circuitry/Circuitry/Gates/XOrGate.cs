using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuitry.Circuitry.Gates
{
    public class XOrGate : ISwitchable
    {
        /* Public */

        public event EventHandler<StateSwitchedEventArgs> StateSwitched;

        public State State { get; private set; }

        public Node Input1 { get; private set; }
        public Node Input2 { get; private set; }

        public XOrGate()
        {
            this.State = State.Off;
            this.Input1 = new Node();
            this.Input2 = new Node();
            this.Input1.StateSwitched += SubscribedStateSwitched;
            this.Input2.StateSwitched += SubscribedStateSwitched;
        }

        /* Private */

        private void EvaluateState()
        {
            if (Input1 == null || Input2 == null)
                return;

            var xor = (this.Input1.State == State.On && this.Input2.State == State.Off) || (this.Input1.State == State.Off && this.Input2.State == State.On);

            if (xor && this.State == State.Off)
                SwitchStates();

            if ((this.State == State.On) && (this.Input1.State == State.Off && this.Input2.State == State.Off))
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
