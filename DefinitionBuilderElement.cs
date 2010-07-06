using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Giza;
using MetaphysicsIndustries.Utilities;

namespace MetaphysicsIndustries.Amethyst
{
    public  class DefinitionBuilderElement : AmethystElement
    {
        public DefinitionBuilderElement()
            : base(new DefinitionBuilderNode(), new SizeV(80, 60))
        {
        }

        public class DefinitionBuilderNode : MetaphysicsIndustries.Epiphany.Node
        {
            public DefinitionBuilderNode()
                : base("DefinitionBuilder")
            {
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(Input);
                OutputConnectionBases.Add(Output);
            }

            private InputConnection<ParseSpan> _input = new InputConnection<ParseSpan>("Input");
            public InputConnection<ParseSpan> Input
            {
                get { return _input; }
            }

            private OutputConnection<SimpleDefinitionNode[]> _output = new OutputConnection<SimpleDefinitionNode[]>("Output");
            public OutputConnection<SimpleDefinitionNode[]> Output
            {
                get { return _output; }
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                DefinitionBuilder builder = new DefinitionBuilder();
                ParseSpan grammar = (ParseSpan)inputs[Input];

                outputs[Output] = builder.BuildDefinitions(grammar);
            }
        }
    }
}
