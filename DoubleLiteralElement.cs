using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MetaphysicsIndustries.Epiphany.Amethyst
{
    public class DoubleLiteralElement : LiteralElement<double>
    {
        public DoubleLiteralElement()
            : base(new LiteralNode("Double Literal"), new SizeF(80, 40))
        {
        }

        protected override double ConvertString(string value)
        {
            return double.Parse(value);
        }

        protected override bool IsConvertable(string value)
        {
            double v;
            return double.TryParse(value, out v);
        }

        public override string Text
        {
            get { return Value.ToString("G5"); }
        }
    }
}
