using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Utilities;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class DoubleValueDisplayElement : ValueDisplayElement<float>
    {
        public DoubleValueDisplayElement()
            : base(new ValueDisplayNode("Double Value"), new SizeV(80, 40))
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
