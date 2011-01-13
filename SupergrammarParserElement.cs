using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Giza;
using MetaphysicsIndustries.Utilities;

namespace MetaphysicsIndustries.Amethyst
{
    public class SupergrammarParserElement : AmethystElement
    {
        public SupergrammarParserElement()
            : base(new SupergrammarParserNode(), new SizeV(80, 60))
        {
        }

        public class SupergrammarParserNode : MetaphysicsIndustries.Epiphany.Node
        {
            public SupergrammarParserNode()
                : base("SupergrammarParser")
            {
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(Input);
                OutputConnectionBases.Add(Output);
            }

            private InputConnection<string> _input = new InputConnection<string>("Input");
            public InputConnection<string> Input
            {
                get { return _input; }
            }

            private OutputConnection<ParseSpan> _output = new OutputConnection<ParseSpan>("Output");
            public OutputConnection<ParseSpan> Output
            {
                get { return _output; }
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                SupergrammarParser parser = new SupergrammarParser();
                string grammar = (string)inputs[Input];

                ParseSpan spans = parser.Getgrammar(grammar);
                outputs[Output] = spans;
            }
        }
    }
}
