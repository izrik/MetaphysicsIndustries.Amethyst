using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    public class ThisElement : AmethystElement
    {
        public ThisElement()
            : base(new ThisNode())
        {
            Node.Element = this;
        }

        protected new ThisNode Node
        {
            get { return (ThisNode)base.Node; }
        }

        public class ThisNode : Node
        {
            public ThisNode()
                : base("this")
            {
            }

            private ThisElement _element;
            public ThisElement Element
            {
                get { return _element; }
                set { _element = value; }
            }

            private OutputConnection<ThisElement> _output = new OutputConnection<ThisElement>("Output");
            public OutputConnection<ThisElement> Output
            {
                get { return _output; }
            }

            protected override void InitConnections()
            {
                OutputConnectionBases.Add(Output);
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                outputs[Output] = Element;
            }
        }
    }
}
