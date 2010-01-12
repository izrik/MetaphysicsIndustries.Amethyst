using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class RadiansToDegreesElement : AmethystElement
    {
        public RadiansToDegreesElement()
            : base(new RadiansToDegreesNode())
        {
        }

        public new RadiansToDegreesNode Node
        {
            get { return (RadiansToDegreesNode)base.Node; }
        }

        [Serializable]
        public class RadiansToDegreesNode : Node
        {
            public RadiansToDegreesNode()
                : base("r-d")
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

                outputs[Output] = x * 180 / Math.PI;
            }
        }


    }
}
