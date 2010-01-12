using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;
using System.Drawing;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Acuity;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class MatrixConvolutionElement : AmethystElement
    {
        public MatrixConvolutionElement()
            : base(new MatrixConvolutionNode(), new SizeF(80,80))
        {
        }

        [Serializable]
        public class MatrixConvolutionNode : Node
        {
            public MatrixConvolutionNode()
                :base("Matrix Convolution")
            {
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(InputA);
                InputConnectionBases.Add(InputB);
                OutputConnectionBases.Add(Output);
            }

            private InputConnectionBase _inputA = new InputConnection<Matrix>("Input A");
            public InputConnectionBase InputA
            {
                get { return _inputA; }
            }
            private InputConnectionBase _inputB = new InputConnection<Matrix>("Input B");
            public InputConnectionBase InputB
            {
                get { return _inputB; }
            }
            private OutputConnectionBase _output = new OutputConnection<Matrix>("Output");
            public OutputConnectionBase Output
            {
                get { return _output; }
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                Matrix a = (Matrix)inputs[InputA];
                Matrix b = (Matrix)inputs[InputB];

                Matrix conv = a.Convolution(b);

                outputs[Output] = conv;
            }
        }
    }
}
