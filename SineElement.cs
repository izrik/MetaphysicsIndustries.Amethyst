using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class SineElement : AmethystElement
    {
        public SineElement()
            : base(new SineNode())
        {
        }

        public new SineNode Node
        {
            get { return (SineNode)base.Node; }
        }

        //protected override void InitTerminals()
        //{
        //    base.InitTerminals();

        //    TerminalsByConnection[Node.Input].DisplayText = "x";
        //}

        [Serializable]
        public class SineNode : Node
        {
            public SineNode()
                : base("sin")
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

                outputs[Output] = (double)Math.Sin(x);
            }
        }
    }
}
