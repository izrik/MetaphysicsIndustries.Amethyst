using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Amethyst
{
    public class AmethystElementEventArgs : EventArgs
    {
        public AmethystElementEventArgs(AmethystElement element)
        {
            if (element == null) { throw new ArgumentNullException("element"); }

            _element = element;
        }

        private AmethystElement _element;
        public AmethystElement Element
        {
            get { return _element; }
        }
    }
}
