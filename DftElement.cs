using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Acuity;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Collections;

namespace MetaphysicsIndustries.Amethyst
{
    public class DftElement : AmethystElement
    {
        public DftElement()
            : base(new DftNode())
        {
        }

        public class DftNode : Node
        {
            public DftNode()
                : base("DFT")
            {
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(Input);
                OutputConnectionBases.Add(Real);
                OutputConnectionBases.Add(Imag);
            }
            private InputConnection<Matrix> _input = new InputConnection<Matrix>("Input");
            public InputConnection<Matrix> Input
            {
                get { return _input; }
            }
            private OutputConnection<Matrix> _real = new OutputConnection<Matrix>("Real");
            public OutputConnection<Matrix> Real
            {
                get { return _real; }
            }
            private OutputConnection<Matrix> _imag = new OutputConnection<Matrix>("Imag");
            public OutputConnection<Matrix> Imag
            {
                get { return _imag; }
            }


            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                FourierTransformMatrixFilter filter = new FourierTransformMatrixFilter();

                Matrix input = (Matrix)inputs[Input];

                Pair<Matrix> result = filter.Apply2(input);

                outputs[Real] = result.First;
                outputs[Imag] = result.Second;
            }
        }

    }







    public class InverseDftElement : AmethystElement
    {
        public InverseDftElement()
            : base(new InverseDftNode())
        {
        }

        public class InverseDftNode : Node
        {
            public InverseDftNode()
                : base("IDFT")
            {
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(RealInput);
                InputConnectionBases.Add(ImagInput);
                OutputConnectionBases.Add(RealOutput);
                OutputConnectionBases.Add(ImagOutput);
            }
            private InputConnection<Matrix> _realInput = new InputConnection<Matrix>("RealInput");
            public InputConnection<Matrix> RealInput
            {
                get { return _realInput; }
            }
            private InputConnection<Matrix> _imagInput = new InputConnection<Matrix>("ImagInput");
            public InputConnection<Matrix> ImagInput
            {
                get { return _imagInput; }
            }
            private OutputConnection<Matrix> _realOutput = new OutputConnection<Matrix>("RealOutput");
            public OutputConnection<Matrix> RealOutput
            {
                get { return _realOutput; }
            }
            private OutputConnection<Matrix> _imagOutput = new OutputConnection<Matrix>("ImagOutput");
            public OutputConnection<Matrix> ImagOutput
            {
                get { return _imagOutput; }
            }


            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                InverseFourierTransformMatrixFilter filter = new InverseFourierTransformMatrixFilter();

                Matrix realInput = (Matrix)inputs[RealInput];
                Matrix imagInput = (Matrix)inputs[ImagInput];

                Pair<Matrix> source = new Pair<Matrix>(realInput, imagInput);
                Pair<Matrix> result = filter.Apply2(source);

                outputs[RealOutput] = result.First;
                outputs[ImagOutput] = result.Second;
            }
        }

    }
}
