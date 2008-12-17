using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Crystalline;

namespace MetaphysicsIndustries.Epiphany.Amethyst
{
    public class ThresholdMatrixFilterElement : MatrixFilterElement
    {
        public ThresholdMatrixFilterElement()
            : base(new ThresholdMatrixFilterNode(), new SizeF(100, 80))
        {
        }

        public new ThresholdMatrixFilterNode Node
        {
            get { return (ThresholdMatrixFilterNode)base.Node; }
        }

        protected override void InitTerminals()
        {
            base.InitTerminals();

            TerminalsByConnection[Node.Input].Position = Height / 2;
            TerminalsByConnection[Node.Threshold].Side = BoxOrientation.Up;
            TerminalsByConnection[Node.Threshold].DisplayText = "t";
            TerminalsByConnection[Node.Threshold].Position = Width / 2;
        }

        public class ThresholdMatrixFilterNode : MatrixFilterNode
        {
            public ThresholdMatrixFilterNode()
                : base("Threshold")
            {
            }

            private InputConnection<double> _threshold = new InputConnection<double>("Threshold");
            public InputConnection<double> Threshold
            {
                get { return _threshold; }
            }

            protected override void InitConnections()
            {
                base.InitConnections();

                InputConnectionBases.Add(Threshold);
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                double t = (double)inputs[Threshold];
                Filter = new ThresholdMatrixFilter(t);

                base.Execute(inputs, outputs);
            }

        }
    }
}
