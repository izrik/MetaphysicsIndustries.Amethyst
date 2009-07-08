using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Acuity;
using System.Drawing;
using MetaphysicsIndustries.Crystalline;

namespace MetaphysicsIndustries.Amethyst
{
    public class FlattenerFilterElement:MatrixFilterElement
    {
        public FlattenerFilterElement()
            : base(new FlattenerFilterNode(), new SizeF(100, 80))
        {
        }

        public new FlattenerFilterNode Node
        {
            get { return (FlattenerFilterNode)base.Node; }
        }

        protected override void InitTerminals()
        {
            base.InitTerminals();

            TerminalsByConnection[Node.Input].Position = Height / 2;
            TerminalsByConnection[Node.Width].Side = BoxOrientation.Up;
            TerminalsByConnection[Node.Width].DisplayText = "w";
            TerminalsByConnection[Node.Width].Position = Width / 2;
        }

        public class FlattenerFilterNode : MatrixFilterNode
        {
            public FlattenerFilterNode()
                : base("Flattener")
            {
            }

            private InputConnection<int> _width = new InputConnection<int>("Width");
            public InputConnection<int> Width
            {
                get { return _width; }
            }

            protected override void InitConnections()
            {
                base.InitConnections();

                InputConnectionBases.Add(Width);
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                int w = (int)inputs[Width];
                Filter = new FlattenerMatrixFilter(w);

                base.Execute(inputs, outputs);
            }
        }
    }
}
