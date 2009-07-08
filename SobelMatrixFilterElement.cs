using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;
using System.Drawing;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Collections;
using MetaphysicsIndustries.Acuity;

namespace MetaphysicsIndustries.Amethyst
{
    public class SobelMatrixFilterElement : MatrixFilterElement
    {
        public SobelMatrixFilterElement()
            : base(new SobelMatrixFilterNode(), new SizeF(100,100))
        {
        }

        protected override void InitTerminals()
        {
            base.InitTerminals();

            TerminalsByConnection[SobelNode.Directionality].DisplayText = "dir";
            TerminalsByConnection[SobelNode.Gx].DisplayText = "Gx";
            TerminalsByConnection[SobelNode.Gy].DisplayText = "Gy";
        }

        public SobelMatrixFilterNode SobelNode
        {
            get { return (SobelMatrixFilterNode)Node; }
        }

        public class SobelMatrixFilterNode : MatrixFilterNode
        {
            public SobelMatrixFilterNode()
                : base(new SobelMatrixFilter(), "Sobel")
            {
            }

            protected override void InitConnections()
            {
                base.InitConnections();

                OutputConnectionBases.Add(Directionality);
                OutputConnectionBases.Add(Gx);
                OutputConnectionBases.Add(Gy);
            }

            private OutputConnection<Matrix> _directionality = new OutputConnection<Matrix>("Directionality");
            public OutputConnection<Matrix> Directionality
            {
                get { return _directionality; }
            }

            private OutputConnection<Matrix> _gx = new OutputConnection<Matrix>("Gx");
            public OutputConnection<Matrix> Gx
            {
                get { return _gx; }
            }

            private OutputConnection<Matrix> _gy = new OutputConnection<Matrix>("Gy");
            public OutputConnection<Matrix> Gy
            {
                get { return _gy; }
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                Matrix input = (Matrix)inputs[Input];

                Matrix x;
                Matrix y;
                SobelMatrixFilter.GenerateGradients(input, out x, out y);
                Pair<Matrix> pair = SobelMatrixFilter.GenerateMaps(input, true, true, x, y);

                outputs[Output] = pair.First;
                outputs[Directionality] = pair.Second;
                outputs[Gx] = x;
                outputs[Gy] = y;
            }
        }
    }
}
