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

            var inputCount = InputOnCount();

            if (this.State == State.Off)
            {
                if (inputCount == 1)
                    SwitchStates();
            }
            else
            {
                if (inputCount != 1)
                    SwitchStates();
            }
        }

        private int InputOnCount()
        {
            var count = 0;
            count += (this.Input1.State == State.On) ? 1 : 0;
            count += (this.Input2.State == State.On) ? 1 : 0;
            return count;
        }

        private void SwitchStates()
        {
            this.State = (this.State == State.On) ? State.Off : State.On;

            Console.WriteLine("XOR Gate is now " + State);

            if (StateSwitched != null)
                StateSwitched(this, new StateSwitchedEventArgs() { NewState = State });
        }

        private void SubscribedStateSwitched(object sender, StateSwitchedEventArgs e)
        {
            EvaluateState();
        }
    }
}
