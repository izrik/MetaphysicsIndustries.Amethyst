using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Acuity;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class HistogramElement : AmethystElement
    {
        public HistogramElement()
            : base(new HistogramNode())
        {
        }

        [Serializable]
        public class HistogramNode : Node
        {
            public HistogramNode()
                : base("Histogram")
            {
            }

            private static HistogramMatrixFilter _filter = new HistogramMatrixFilter();

            private InputConnection<IEnumerable<float>> _input = new InputConnection<IEnumerable<float>>("Input");
            public InputConnection<IEnumerable<float>> Input
            {
                get { return _input; }
            }
            private OutputConnection<Matrix> _output = new OutputConnection<Matrix>("Output");
            public OutputConnection<Matrix> Output
            {
                get { return _output; }
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(Input);
                OutputConnectionBases.Add(Output);
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                List<float> input = new List<float>((IEnumerable<float>)inputs[Input]);

                Matrix output = _filter.Apply(new Matrix(1, input.Count, input.ToArray()));

                outputs[Output] = output;
            }
        }
    }
}
