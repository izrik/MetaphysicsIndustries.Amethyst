using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Amethyst
{
    public class TerminalEventArgs : EventArgs
    {
        public TerminalEventArgs(OutputTerminal terminal)
        {
            if (terminal == null) { throw new ArgumentNullException("terminal"); }

            _terminal = terminal;
        }

        private OutputTerminal _terminal;
        public OutputTerminal Terminal
        {
            get { return _terminal; }
        }
    }
}
