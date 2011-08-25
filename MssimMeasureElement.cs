using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Acuity;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class MssimMeasureElement : AmethystElement
    {
        public MssimMeasureElement()
            : base(new MssimMeasureNode())
        {
        }

        [Serializable]
        public class MssimMeasureNode : Node
        {
            public MssimMeasureNode()
                : base("MSSIM")
            {
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(InputA);
                InputConnectionBases.Add(InputB);
                OutputConnectionBases.Add(MeasureOutput);
                OutputConnectionBases.Add(MapOutput);
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
            private OutputConnection<Matrix> _mapOutput = new OutputConnection<Matrix>("Map");
            public OutputConnection<Matrix> MapOutput
            {
                get { return _mapOutput; }
            }
	

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                SsimErrorMeasure ssim = new SsimErrorMeasure();

                Matrix inputA = (Matrix)inputs[InputA];
                Matrix inputB = (Matrix)inputs[InputB];

                Matrix map = SsimErrorMeasure.GenerateMap(inputA, inputB, 7);
                float measure = SsimErrorMeasure.CalculateMeasureFromMap(map);

                outputs[MeasureOutput] = measure;
                outputs[MapOutput] = map;
            }
        }
    }
}
