using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class LoadTextFileElement : AmethystElement
    {

        public LoadTextFileElement()
            : base(new LoadTextFileNode(), new SizeF(120, 60))
        {
        }

        public new LoadTextFileNode Node
        {
            get { return (LoadTextFileNode)base.Node; }
        }

        [Serializable]
        public class LoadTextFileNode : Node
        {
            public LoadTextFileNode()
                : base("Load Text File")
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
            private OutputConnection<string> _output = new OutputConnection<string>("Output");
            public OutputConnection<string> Output
            {
                get { return _output; }
            }


            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                string filename = (string)inputs[Input];
                
                outputs[Output] = File.ReadAllText(filename);
            }
        }
    }
}
