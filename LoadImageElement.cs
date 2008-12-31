using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;
using System.Drawing;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    public class LoadImageElement : AmethystElement
    {
        public LoadImageElement()
            : base(new LoadImageNode(), new SizeF(120, 60))
        {
        }

        public new LoadImageNode Node
        {
            get { return (LoadImageNode)base.Node; }
        }

        public class LoadImageNode : Node
        {
            protected static SolusEngine _engine = new SolusEngine();

            public LoadImageNode()
                : base("Load Image")
            {
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(Input);
                OutputConnectionBases.Add(Output);
            }

            private InputConnectionBase _input = new InputConnection<string>("Input");
            public InputConnectionBase Input
            {
                get { return _input; }
            }
            private OutputConnectionBase _output = new OutputConnection<Matrix>("Output");
            public OutputConnectionBase Output
            {
                get { return _output; }
            }


            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                string filename = (string)inputs[Input];
                Matrix image = SolusEngine.LoadImage2(filename);

                image.ApplyToAll(SolusEngine.Convert24gToFloat);

                outputs[Output] = image;
            }
        }
    }
}
