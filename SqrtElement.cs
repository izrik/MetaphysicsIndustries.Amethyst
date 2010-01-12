using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class SqrtElement : AmethystElement
    {
        public SqrtElement()
            : base(new SqrtNode())
        {
        }

        public new SqrtNode Node
        {
            get { return (SqrtNode)base.Node; }
        }

        [Serializable]
        public class SqrtNode : Node
        {
            public SqrtNode()
                : base("sqrt")
            {
            }

            private OutputConnection<double> _output = new OutputConnection<double>("output");
            public OutputConnection<double> Output
            {
                get { return _output; }
            }

            private InputConnection<double> _input = new InputConnection<double>("x");
            public InputConnection<double> Input
            {
                get { return _input; }
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(Input);
                OutputConnectionBases.Add(Output);
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                double x = (double)inputs[Input];

                outputs[Output] = (double)Math.Sqrt(x);
            }
        }

    }
}