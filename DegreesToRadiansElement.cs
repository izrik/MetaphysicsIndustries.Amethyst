using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    public class DegreesToRadiansElement : AmethystElement
    {
        public DegreesToRadiansElement()
            : base(new DegreesToRadiansNode())
        {
        }

        public new DegreesToRadiansNode Node
        {
            get { return (DegreesToRadiansNode)base.Node; }
        }

        public class DegreesToRadiansNode : Node
        {
            public DegreesToRadiansNode()
                : base("d-r")
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

                outputs[Output] = x * Math.PI / 180;
            }
        }

    }
}
