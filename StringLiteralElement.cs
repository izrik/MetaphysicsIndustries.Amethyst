using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MetaphysicsIndustries.Amethyst
{
    public class StringLiteralElement : LiteralElement<string>
    {
        public StringLiteralElement()
            : base(new LiteralNode("String Literal"), new SizeF(150,30))
        {
            Value = "String Literal";
        }

        //public StringLiteralElement(LiteralNode node)
        //    : base(node, new SizeF(150,30))
        //{
        //}

        //public class StringLiteralNode : LiteralNode
        //{
        //    public StringLiteralNode()
        //        : this(string.Empty)
        //    {
        //    }
        //
        //    public StringLiteralNode(string value)
        //        : base("StringLiteral")
        //    {
        //        _value = value;
        //        OutputConnectionBases.Add(Output);
        //    }
        //
        //    private string _value;
        //    public string Value
        //    {
        //        get { return _value; }
        //        set { _value = value; }
        //    }
        //
        //    private OutputConnectionBase _output = new OutputConnection<string>("Output");
        //    public OutputConnectionBase Output
        //    {
        //        get { return _output; }
        //        set { _output = value; }
        //    }
        //
        //}

        //public override string Text
        //{
        //    get
        //    {
        //        return ((LiteralNode)Node).Value.ToString();
        //    }
        //}

        protected override string ConvertString(string value)
        {
            return value;
        }

        protected override bool IsConvertable(string value)
        {
            return true;
        }
    }
}
