using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Acuity;
using System.Drawing;
using MetaphysicsIndustries.Crystalline;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class GaussianBlurFilterElement : MatrixFilterElement
    {
        public GaussianBlurFilterElement()
            : base(new GaussianBlurFilterNode(), new SizeF(100, 80))
        {
        }

        public new GaussianBlurFilterNode Node
        {
            get { return (GaussianBlurFilterNode)base.Node; }
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
        public class GaussianBlurFilterNode : MatrixFilterNode
        {
            public GaussianBlurFilterNode()
                : base("Gaussian Blur")
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
                Filter = new GaussianBlurMatrixFilter(w);

                base.Execute(inputs, outputs);
            }
        }
    }
}
