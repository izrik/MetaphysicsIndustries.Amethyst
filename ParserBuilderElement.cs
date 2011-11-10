using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Giza;
using MetaphysicsIndustries.Build;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Utilities;

namespace MetaphysicsIndustries.Amethyst
{
    public class ParserBuilderElement : AmethystElement
    {
        public ParserBuilderElement()
            :base (new ParserBuilderNode(), new SizeV(80,60))
        {
        }

        public class ParserBuilderNode : MetaphysicsIndustries.Epiphany.Node
        {
            public ParserBuilderNode()
                : base("ParserBuilder")
            {
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(Input);
                OutputConnectionBases.Add(Output);
            }

            private InputConnection<SimpleDefinitionNode[]> _input = new InputConnection<SimpleDefinitionNode[]>("Input");
            public InputConnection<SimpleDefinitionNode[]> Input
            {
                get { return _input; }
            }

            private InputConnection<string> _className = new InputConnection<string>("Class Name");
            public InputConnection<string> ClassName
            {
                get { return _className; }
            }

            private OutputConnection<Class> _output = new OutputConnection<Class>("Output");
            public OutputConnection<Class> Output
            {
                get { return _output; }
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                SpannerBuilder builder = new SpannerBuilder();
                SimpleDefinitionNode[] defs = (SimpleDefinitionNode[])inputs[Input];
                string className = (string)inputs[ClassName];

                className = SpannerServices.CleanTag(className);
                if (string.IsNullOrEmpty(className))
                {
                    className = "SomethingParser";
                }
                
                Class c = builder.ParserClassFromDefinitions(defs);
                c.Name = className;
                outputs[Output] = c;
            }
        }


        protected override void InitTerminals()
        {
            InputTerminal term;
            ParserBuilderNode node = (ParserBuilderNode)Node;

            term = new InputTerminal(node.Input);
            term.Position = Height / 2;
            term.Side = BoxOrientation.Left;
            //term.Size *= 2;
            Terminals.Add(term);

            term = new InputTerminal(node.ClassName);
            term.Position = Width / 3;
            term.Side = BoxOrientation.Up;
            term.DisplayText = "name";
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
