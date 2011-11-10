using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Utilities;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class FloatValueDisplayElement : ValueDisplayElement<float>
    {
        public FloatValueDisplayElement()
            : base(new ValueDisplayNode("Float Value"), new SizeV(80, 40))
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
