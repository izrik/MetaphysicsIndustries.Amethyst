using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
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

        [Serializable]
        public class DegreesToRadiansNode : Node
        {
            public DegreesToRadiansNode()
                : base("d-r")
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

                outputs[Output] = x * Math.PI / 180;
            }
        }

    }
}
