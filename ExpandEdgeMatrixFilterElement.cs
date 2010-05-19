using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Acuity;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Utilities;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class ExpandEdgeMatrixFilterElement : MatrixFilterElement
    {
        public ExpandEdgeMatrixFilterElement()
            : base(new ExpandEdgeMatrixFilterNode(), new SizeV(120, 80))
        {
        }

        public new ExpandEdgeMatrixFilterNode Node
        {
            get { return (ExpandEdgeMatrixFilterNode)base.Node; }
        }

        protected override void InitTerminals()
        {
            base.InitTerminals();

            TerminalsByConnection[Node.Input].Position = Height / 2;
            TerminalsByConnection[Node.BorderSize].Side = BoxOrientation.Up;
            TerminalsByConnection[Node.BorderSize].DisplayText = "w";
            TerminalsByConnection[Node.BorderSize].Position = Width / 2;
        }

        [Serializable]
        public class ExpandEdgeMatrixFilterNode : MatrixFilterNode
        {
            public ExpandEdgeMatrixFilterNode()
                : base("Expand Edge Filter Generator")
            {
            }

            private InputConnection<int> _borderSize = new InputConnection<int>("Border Size");
            public InputConnection<int> BorderSize
            {
                get { return _borderSize; }
            }

            protected override void InitConnections()
            {
                base.InitConnections();

                InputConnectionBases.Add(BorderSize);
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                int w = (int)inputs[BorderSize];
                Filter = new ExpandEdgeMatrixFilter(w);

                base.Execute(inputs, outputs);
            }
        }
    }
}
