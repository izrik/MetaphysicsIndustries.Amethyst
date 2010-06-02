using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Collections;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    public class ValueCache //: IDictionary<OutputTerminal, object>
    {
        Dictionary<OutputTerminal, object> _collection = new Dictionary<OutputTerminal,object>();


        public void Remove(AmethystElement element)
        {
            foreach (Terminal term in element.Terminals)
            {
                Remove(term);
            }
        }

        public void Remove(Terminal terminal)
        {
            if (terminal is OutputTerminal)
            {
                Remove((OutputTerminal)terminal);
            }
            else if (terminal is InputTerminal)
            {
                Remove((InputTerminal)terminal);
            }
        }

        public bool Remove(OutputTerminal terminal)
        {
            if (this.ContainsKey(terminal))
            {
                bool ret = _collection.Remove(terminal);

                foreach (AmethystPath apath in terminal.AmethystPaths)
                {
                    Remove(apath.ToTerminal);
                }

                OnTerminalRemoved(terminal);

                return ret;
            }

            return false;
        }

        public event EventHandler<TerminalEventArgs> TerminalRemoved;
        public void OnTerminalRemoved(Terminal terminal)
        {
            if (terminal == null) { throw new ArgumentNullException("terminal"); }

            if (TerminalRemoved != null)
            {
                TerminalRemoved(this, new TerminalEventArgs(terminal));
            }
        }

        private void Remove(InputTerminal terminal)
        {
            foreach (OutputConnectionBase con in terminal.Connection.Dependants)
            {
                Remove(terminal.ParentAmethystElement.TerminalsByConnection[con]);
            }

            OnTerminalRemoved(terminal);
        }

        public void Add(OutputTerminal key, object value)
        {
            _collection.Add(key, value);
        }

        public bool ContainsKey(OutputTerminal key)
        {
            return _collection.ContainsKey(key);
        }

        public object this[OutputTerminal key]
        {
            get
            {
                return _collection[key];
            }
            set
            {
                _collection[key] = value;
            }
        }

        public void Clear()
        {
            OutputTerminal[] terminals = _collection.Keys.ToArray();
            foreach (OutputTerminal terminal in terminals)
            {
                Remove(terminal);
            }

            _collection.Clear();
        }

        public int Count
        {
            get { return _collection.Count; }
        }
    }
}
