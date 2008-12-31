using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    public class AveragerElement : AmethystElement
    {
        public AveragerElement()
            : base(new AveragerNode(), new SizeF(60, 60))
        {
        }

        public class AveragerNode : Node
        {
            public AveragerNode()
                : base("μ")
            {
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(Input);
                OutputConnectionBases.Add(Output);
            }

            private InputConnectionBase _input = new InputConnection<IEnumerable<double>>("Input");
            public InputConnectionBase Input
            {
                get { return _input; }
            }
            private OutputConnectionBase _output = new OutputConnection<double>("Output");
            public OutputConnectionBase Output
            {
                get { return _output; }
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                IEnumerable<double> input = (IEnumerable<double>)inputs[Input];

                double sum = 0;
                int count = 0;
                foreach (double value in input)
                {
                    sum += value;
                    count++;
                }

                outputs[Output] = sum / count;
            }
        }
    }
}
