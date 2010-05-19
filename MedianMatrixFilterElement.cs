using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Acuity;
using MetaphysicsIndustries.Utilities;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class MedianMatrixFilterElement : MatrixFilterElement
    {
        public MedianMatrixFilterElement()
            : base(new MedianMatrixFilterNode(), new SizeV(120, 80))
        {
        }

        public new MedianMatrixFilterNode Node
        {
            get { return (MedianMatrixFilterNode)base.Node; }
        }

        protected override void InitTerminals()
        {
            base.InitTerminals();

            TerminalsByConnection[Node.Input].Position = Height / 2;
            TerminalsByConnection[Node.WindowSize].Side = BoxOrientation.Up;
            TerminalsByConnection[Node.WindowSize].DisplayText = "w";
            TerminalsByConnection[Node.WindowSize].Position = Width / 2;
        }

        [Serializable]
        public class MedianMatrixFilterNode : MatrixFilterNode
        {
            public MedianMatrixFilterNode()
                : base("Median Filter")
            {
            }

            private InputConnection<int> _windowSize = new InputConnection<int>("Window Size");
            public InputConnection<int> WindowSize
            {
                get { return _windowSize; }
            }

            protected override void InitConnections()
            {
                base.InitConnections();

                InputConnectionBases.Add(WindowSize);
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                int windowSize = (int)inputs[WindowSize];
                Filter = new MedianMatrixFilter(windowSize);

                Execute(inputs, outputs,Filter);
            }
        }
    }
}
