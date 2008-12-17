using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;

namespace MetaphysicsIndustries.Epiphany.Amethyst
{
    public class MseMeasureElement : AmethystElement
    {
        public MseMeasureElement()
            : base(new MseMeasureNode())
        {
        }

        public class MseMeasureNode : Node
        {
            public MseMeasureNode()
                : base("MSE")
            {
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(InputA);
                InputConnectionBases.Add(InputB);
                OutputConnectionBases.Add(MeasureOutput);
            }

            private InputConnection<Matrix> _inputA = new InputConnection<Matrix>("Input A");
            public InputConnection<Matrix> InputA
            {
                get { return _inputA; }
            }
            private InputConnection<Matrix> _inputB = new InputConnection<Matrix>("Input B");
            public InputConnection<Matrix> InputB
            {
                get { return _inputB; }
            }
            private OutputConnection<double> _measureOutput = new OutputConnection<double>("Measure");
            public OutputConnection<double> MeasureOutput
            {
                get { return _measureOutput; }
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                Matrix inputA = (Matrix)inputs[InputA];
                Matrix inputB = (Matrix)inputs[InputB];

                double measure = SolusEngine.MeanSquareError(inputA, inputB);

                outputs[MeasureOutput] = measure;
            }
        }    }
}
