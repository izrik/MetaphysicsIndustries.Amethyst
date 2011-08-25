using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
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

        [Serializable]
        public class MultNode : Node
        {
            public MultNode()
                : base("*")
            {
            }

            private OutputConnection<float> _output = new OutputConnection<float>("output");
            public OutputConnection<float> Output
            {
                get { return _output; }
            }

            private InputConnection<float> _inputA = new InputConnection<float>("a");
            public InputConnection<float> InputA
            {
                get { return _inputA; }
            }

            private InputConnection<float> _inputB = new InputConnection<float>("b");
            public InputConnection<float> InputB
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
                float a = (float)inputs[InputA];
                float b = (float)inputs[InputB];

                outputs[Output] = a * b;
            }
        }




    }
}
