using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;
using System.Drawing;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Acuity;
using MetaphysicsIndustries.Utilities;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class ArithmeticMeanFilterElement : MatrixFilterElement
    {
        public ArithmeticMeanFilterElement()
            : base(new ArithmeticMeanFilterNode(), new SizeV(120, 80))
        {
        }

        public new ArithmeticMeanFilterNode Node
        {
            get { return (base.Node as ArithmeticMeanFilterNode); }
        }

        protected override void InitTerminals()
        {
            base.InitTerminals();

            TerminalsByConnection[Node.Input].Position = Height / 2;

            TerminalsByConnection[Node.Width].Side = BoxOrientation.Up;
            TerminalsByConnection[Node.Width].DisplayText = "w";
            TerminalsByConnection[Node.Width].Position = Width / 2;
        }

        [Serializable]
        public class ArithmeticMeanFilterNode : MatrixFilterNode
        {
            public ArithmeticMeanFilterNode()
                : base("Arithmetic Mean")
            {
            }

            private InputConnection<int> _width = new InputConnection<int>("Window Size");
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
                int width = (int)inputs[Width];
                Filter = new ArithmeticMeanFilter(width);

                Execute(inputs, outputs, Filter);
            }
        }
    }
}
