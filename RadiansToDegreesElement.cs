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

            private OutputConnection<float> _output = new OutputConnection<float>("output");
            public OutputConnection<float> Output
            {
                get { return _output; }
            }

            private InputConnection<float> _input = new InputConnection<float>("x");
            public InputConnection<float> Input
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
                float x = (float)inputs[Input];

                outputs[Output] = x * 180 / Math.PI;
            }
        }


    }
}
