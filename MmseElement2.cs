using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Acuity;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class MmseElement2 : AmethystElement
    {
        public MmseElement2()
            : base(new MmseNode2())
        {
        }


        [Serializable]
        public class MmseNode2 : Node
        {
            public MmseNode2()
                : base("MMSE")
            {
            }

            private InputConnection<Matrix> _inputImage = new InputConnection<Matrix>("InputImage");
            public InputConnection<Matrix> InputImage
            {
                get { return _inputImage; }
            }
            private InputConnection<float> _noiseVariance = new InputConnection<float>("Noise Variance");
            public InputConnection<float> NoiseVariance
            {
                get { return _noiseVariance; }
            }
            private InputConnection<int> _windowSize = new InputConnection<int>("Window Size");
            public InputConnection<int> WindowSize
            {
                get { return _windowSize; }
            }
            private OutputConnection<Matrix> _outputImage = new OutputConnection<Matrix>("OutputImage");
            public OutputConnection<Matrix> OutputImage
            {
                get { return _outputImage; }
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(InputImage);
                InputConnectionBases.Add(NoiseVariance);
                InputConnectionBases.Add(WindowSize);
                OutputConnectionBases.Add(OutputImage);
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                Matrix input = (Matrix)inputs[InputImage];
                float variance = (float)inputs[NoiseVariance];
                int windowSize = (int)inputs[WindowSize];

                MinimalMeanSquareErrorMatrixFilter filter = new MinimalMeanSquareErrorMatrixFilter(windowSize, variance);

                Matrix output = filter.Apply(input);

                outputs[OutputImage] = output;
            }
        }
    }
}
