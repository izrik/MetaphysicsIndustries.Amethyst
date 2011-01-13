using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Giza;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Utilities;


namespace MetaphysicsIndustries.Amethyst
{
    public class GenericParserElement : AmethystElement
    {
        public GenericParserElement()
            : base(new GenericParserNode(), new SizeV(100,80))
        {
        }

        [Serializable]
        public class GenericParserNode : MetaphysicsIndustries.Epiphany.Node
        {
            public GenericParserNode()
                : base("Generic Parser")
            {
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(Input);
                InputConnectionBases.Add(Definitions);
                OutputConnectionBases.Add(Output);
            }

            private InputConnection<string> _input = new InputConnection<string>("Input");
            public InputConnection<string> Input
            {
                get { return _input; }
            }

            private InputConnection<SimpleDefinitionNode[]> _definitions = new InputConnection<SimpleDefinitionNode[]>("Definitions");
            public InputConnection<SimpleDefinitionNode[]> Definitions
            {
                get { return _definitions; }
            }

            private InputConnection<string> _startName = new InputConnection<string>("Start Name");
            public InputConnection<string> StartName
            {
                get { return _startName; }
            }

            private OutputConnection<ParseSpan> _output = new OutputConnection<ParseSpan>("Output");
            public OutputConnection<ParseSpan> Output
            {
                get { return _output; }
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                SimpleDefinitionNode[] defs = (SimpleDefinitionNode[])inputs[Definitions];
                string startName = (string)inputs[StartName];
                string input = (string)inputs[Input];

                GenericParser parser = new GenericParser();

                outputs[Output] = parser.Parse(defs, startName, input);
            }
        }

        protected override void InitTerminals()
        {
            InputTerminal term;
            GenericParserNode node = (GenericParserNode)Node;

            term = new InputTerminal(node.Input);
            term.Position = Height / 2;
            term.Side = BoxOrientation.Left;
            //term.Size *= 2;
            Terminals.Add(term);

            term = new InputTerminal(node.Definitions);
            term.Position = Width / 3;
            term.Side = BoxOrientation.Up;
            term.DisplayText = "defs";
            Terminals.Add(term);

            term = new InputTerminal(node.StartName);
            term.Position = 2 * Width / 3;
            term.Side = BoxOrientation.Up;
            term.DisplayText = "start";
            Terminals.Add(term);

            OutputTerminal term2;

            term2 = new OutputTerminal(node.Output);
            term2.Position = Height / 2;
            term2.Side = BoxOrientation.Right;
            //term2.Size *= 2;
            Terminals.Add(term2);
        }
    }
}
