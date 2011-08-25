using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class CosineElement : AmethystElement
    {
        public CosineElement()
            : base(new CosineNode())
        {
        }

        public new CosineNode Node
        {
            get { return (CosineNode)base.Node; }
        }

        //protected override void InitTerminals()
        //{
        //    base.InitTerminals();

        //    TerminalsByConnection[Node.Input].DisplayText = "x";
        //}

        [Serializable]
        public class CosineNode : Node
        {
            public CosineNode()
                : base("cos")
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

                outputs[Output] = (float)Math.Cos(x);
            }
        }


    }
}
