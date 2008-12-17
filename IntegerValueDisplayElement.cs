using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MetaphysicsIndustries.Epiphany.Amethyst
{
    public class IntegerValueDisplayElement : ValueDisplayElement<int>
    {
        public IntegerValueDisplayElement()
            : base(new ValueDisplayNode("Integer Value"), new SizeF(80, 40))
        {
        }
    }
}
