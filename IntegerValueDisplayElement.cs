using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Utilities;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class IntegerValueDisplayElement : ValueDisplayElement<int>
    {
        public IntegerValueDisplayElement()
            : base(new ValueDisplayNode("Integer Value"), new SizeV(80, 40))
        {
        }
    }
}
