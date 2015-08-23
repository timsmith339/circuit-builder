using Circuitry.Circuitry;
using Circuitry.Circuitry.Gates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuitry
{
    class Program
    {
        static void Main(string[] args)
        {
            var nodeSwitch1 = new Switch();
            var node1 = new Node();
            var nodeSwitch2 = new Switch();
            var node2 = new Node();
            var andGate1 = new AndGate();
            var node3 = new Node();

            Console.WriteLine(node3.State);

            node1.SubscribeTo(nodeSwitch1);
            node2.SubscribeTo(nodeSwitch2);

            andGate1.Input1.SubscribeTo(node1);
            andGate1.Input2.SubscribeTo(node2);

            node3.SubscribeTo(andGate1);

            Console.WriteLine(node3.State);
            nodeSwitch1.SwitchStates();
            Console.WriteLine(node3.State);
            nodeSwitch2.SwitchStates();
            Console.WriteLine(node3.State);
            nodeSwitch2.SwitchStates();
            Console.WriteLine(node3.State);

            Console.ReadKey();
        }
    }
}
