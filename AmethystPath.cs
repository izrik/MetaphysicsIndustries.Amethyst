using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Crystalline;

namespace MetaphysicsIndustries.Epiphany.Amethyst
{
    public class AmethystPath : Path
    {
        private OutputTerminal _fromTerminal;
        public OutputTerminal FromTerminal
        {
            get { return _fromTerminal; }
            set
            {
                if (_fromTerminal != value)
                {
                    if (_fromTerminal != null)
                    {
                        _fromTerminal.AmethystPaths.Remove(this);
                    }

                    From = null;
                    _fromTerminal = value;
                    if (_fromTerminal != null) { From = _fromTerminal.ParentAmethystElement; }

                    if (_fromTerminal != null)
                    {
                        _fromTerminal.AmethystPaths.Add(this);
                    }
                }
            }
        }

        private InputTerminal _toTerminal;
        public InputTerminal ToTerminal
        {
            get { return _toTerminal; }
            set
            {
                if (_toTerminal != value)
                {
                    InputTerminal tempTerminal = _toTerminal;

                    To = null;
                    _toTerminal = value;
                    if (_toTerminal != null) { To = _toTerminal.ParentAmethystElement; }

                    if (tempTerminal != null)
                    {
                        tempTerminal.Path = null;
                    }

                    if (_toTerminal != null)
                    {
                        _toTerminal.Path = this;
                    }
                }
            }
        }

    }
}
