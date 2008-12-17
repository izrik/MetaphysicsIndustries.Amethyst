using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;

namespace MetaphysicsIndustries.Epiphany.Amethyst
{
    public class HistogramElement : AmethystElement
    {
        public HistogramElement()
            : base(new HistogramNode())
        {
        }

        public class HistogramNode : Node
        {
            public HistogramNode()
                : base("Histogram")
            {
            }

            private static HistogramMatrixFilter _filter = new HistogramMatrixFilter();

            private InputConnection<IEnumerable<double>> _input = new InputConnection<IEnumerable<double>>("Input");
            public InputConnection<IEnumerable<double>> Input
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
                List<double> input = new List<double>((IEnumerable<double>)inputs[Input]);

                Matrix output = _filter.Apply(new Matrix(1, input.Count, input.ToArray()));

                outputs[Output] = output;
            }
        }
    }
}
