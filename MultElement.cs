using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    public class MultElement : AmethystElement
    {
        public MultElement()
            : base(new MultNode())
        {
        }

        public new MultNode Node
        {
            get { return (MultNode)base.Node; }
        }

        protected override void InitTerminals()
        {
            base.InitTerminals();

            TerminalsByConnection[Node.InputA].DisplayText = "A";
            TerminalsByConnection[Node.InputB].DisplayText = "B";
        }

        public class MultNode : Node
        {
            public MultNode()
                : base("*")
            {
            }

            private OutputConnection<double> _output = new OutputConnection<double>("output");
            public OutputConnection<double> Output
            {
                get { return _output; }
            }

            private InputConnection<double> _inputA = new InputConnection<double>("a");
            public InputConnection<double> InputA
            {
                get { return _inputA; }
            }

            private InputConnection<double> _inputB = new InputConnection<double>("b");
            public InputConnection<double> InputB
            {
                get { return _inputB; }
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(InputA);
                InputConnectionBases.Add(InputB);
                OutputConnectionBases.Add(Output);
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                double a = (double)inputs[InputA];
                double b = (double)inputs[InputB];

                outputs[Output] = a * b;
            }
        }




    }
}
