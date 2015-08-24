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
            var nSwitch1 = new Switch();
            var nSwitch2 = new Switch();

            var node1 = new Node();
            var node2 = new Node();

            var xor = new XOrGate();

            node1.SubscribeTo(nSwitch1);
            node2.SubscribeTo(nSwitch2);

            xor.Input1.SubscribeTo(node1);
            xor.Input2.SubscribeTo(node2);

            Console.WriteLine("Switch 1: " + nSwitch1.State);
            Console.WriteLine("Switch 2: " + nSwitch2.State);

            while (true)
            {
                var key = Console.ReadKey().KeyChar;
                if (key == '1')
                    nSwitch1.SwitchStates();
                else if (key == '2')
                    nSwitch2.SwitchStates();

                Console.WriteLine("Switch 1: " + nSwitch1.State);
                Console.WriteLine("Switch 2: " + nSwitch2.State);

                Console.WriteLine();
            }
        }
    }
}
