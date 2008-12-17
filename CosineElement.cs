using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Epiphany.Amethyst
{
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

        public class CosineNode : Node
        {
            public CosineNode()
                : base("cos")
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

                outputs[Output] = (double)Math.Cos(x);
            }
        }


    }
}
