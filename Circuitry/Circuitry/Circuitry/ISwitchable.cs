using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuitry.Circuitry
{
    public interface ISwitchable
    {
        event EventHandler<StateSwitchedEventArgs> StateSwitched;

        State State { get; }
    }
}
