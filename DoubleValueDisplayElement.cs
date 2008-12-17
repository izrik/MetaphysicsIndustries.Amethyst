using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MetaphysicsIndustries.Epiphany.Amethyst
{
    public class DoubleValueDisplayElement : ValueDisplayElement<double>
    {
        public DoubleValueDisplayElement()
            : base(new ValueDisplayNode("Double Value"), new SizeF(80, 40))
        {
        }

        protected override string InternalText
        {
            get
            {
                return Value.ToString("G5");
            }
        }
    }
}
