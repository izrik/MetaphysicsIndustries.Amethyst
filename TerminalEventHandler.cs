using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Amethyst
{
    public class TerminalEventArgs : EventArgs
    {
        public TerminalEventArgs(Terminal terminal)
        {
            if (terminal == null) { throw new ArgumentNullException("terminal"); }

            _terminal = terminal;
        }

        private Terminal _terminal;
        public Terminal Terminal
        {
            get { return _terminal; }
        }
    }
}
