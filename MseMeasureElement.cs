using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Acuity;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class MseMeasureElement : AmethystElement
    {
        public MseMeasureElement()
            : base(new MseMeasureNode())
        {
        }

        [Serializable]
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
            private OutputConnection<float> _measureOutput = new OutputConnection<float>("Measure");
            public OutputConnection<float> MeasureOutput
            {
                get { return _measureOutput; }
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                Matrix inputA = (Matrix)inputs[InputA];
                Matrix inputB = (Matrix)inputs[InputB];

                float measure = AcuityEngine.MeanSquareError(inputA, inputB);

                outputs[MeasureOutput] = measure;
            }
        }    }
}
