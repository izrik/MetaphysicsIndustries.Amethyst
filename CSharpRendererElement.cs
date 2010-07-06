using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Build;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Utilities;

namespace MetaphysicsIndustries.Amethyst
{
    public class CSharpRendererElement : AmethystElement
    {
        public CSharpRendererElement()
            : base(new CSharpRendererNode(), new SizeV(80, 60))
        {
        }

        public class CSharpRendererNode : MetaphysicsIndustries.Epiphany.Node
        {
            public CSharpRendererNode()
                : base("CSharpRenderer")
            {
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(Input);
                OutputConnectionBases.Add(Output);
            }

            private InputConnection<Build.Type> _input = new InputConnection<Build.Type>("Input");
            public InputConnection<Build.Type> Input
            {
                get { return _input; }
            }

            private OutputConnection<string> _output = new OutputConnection<string>("Output");
            public OutputConnection<string> Output
            {
                get { return _output; }
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                CSharpRenderer renderer = new CSharpRenderer();
                Build.Type type = (Build.Type)inputs[Input];

                outputs[Output] = renderer.RenderType(type);
            }
        }
    }
}
