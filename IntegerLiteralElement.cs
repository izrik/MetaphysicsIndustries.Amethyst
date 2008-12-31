using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MetaphysicsIndustries.Amethyst
{
    public class IntegerLiteralElement : LiteralElement<int>
    {
        public IntegerLiteralElement()
            : base(new LiteralNode("Integer Literal"), new SizeF(50, 50))
        {
        }

        protected override int ConvertString(string value)
        {
            return int.Parse(value);
        }

        protected override bool IsConvertable(string value)
        {
            int v;
            return int.TryParse(value, out v);
        }
    }
}
