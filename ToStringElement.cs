using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Epiphany.Amethyst
{
    public class ToStringElement : AmethystElement
    {
        public ToStringElement()
            : base(new ToStringNode())
        {
        }

        public class ToStringNode : Node
        {
            public ToStringNode()
                : base("ToString()")
            {
            }

            private InputConnection<object> _input = new InputConnection<object>("Input");
            public InputConnection<object> Input
            {
                get { return _input; }
            }
            private OutputConnection<string> _output = new OutputConnection<string>("Output");
            public OutputConnection<string> Output
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
                object input = inputs[Input];

                string output = input.ToString();

                outputs[Output] = output;
            }
        }
    }
}
