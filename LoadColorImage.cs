using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Acuity;

namespace MetaphysicsIndustries.Amethyst
{
    public class LoadColorImageElement : AmethystElement
    {
        public LoadColorImageElement()
            : base(new LoadColorImageNode(), new SizeF(120, 80))
        {
        }

        public new LoadColorImageNode Node
        {
            get { return (LoadColorImageNode)base.Node; }
        }

        protected override void InitTerminals()
        {
            base.InitTerminals();

            TerminalsByConnection[Node.RedChannel].DisplayText = "r";
            TerminalsByConnection[Node.GreenChannel].DisplayText = "g";
            TerminalsByConnection[Node.BlueChannel].DisplayText = "b";
        }

        public class LoadColorImageNode : Node
        {
            protected static SolusEngine _engine = new SolusEngine();

            public LoadColorImageNode()
                : base("Load Color Image")
            {
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(Filename);
                OutputConnectionBases.Add(RedChannel);
                OutputConnectionBases.Add(GreenChannel);
                OutputConnectionBases.Add(BlueChannel);
            }

            private InputConnectionBase _filename = new InputConnection<string>("Filename");
            public InputConnectionBase Filename
            {
                get { return _filename; }
            }
            private OutputConnectionBase _redChannel = new OutputConnection<Matrix>("Red Channel");
            public OutputConnectionBase RedChannel
            {
                get { return _redChannel; }
            }
            private OutputConnectionBase _greenChannel = new OutputConnection<Matrix>("Green Channel");
            public OutputConnectionBase GreenChannel
            {
                get { return _greenChannel; }
            }
            private OutputConnectionBase _blueChannel = new OutputConnection<Matrix>("Blue Channel");
            public OutputConnectionBase BlueChannel
            {
                get { return _blueChannel; }
            }


            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                string filename = (string)inputs[Filename];
                Matrix image = AcuityEngine.LoadImage2(filename);
                Matrix r = image.CloneSize();
                Matrix g = image.CloneSize();
                Matrix b = image.CloneSize();

                int i;
                int j;

                for (i = 0; i < image.RowCount; i++)
                {
                    for (j = 0; j < image.ColumnCount; j++)
                    {
                        int rr = ((int)(image[i, j]) & 0xFF0000) >> 16;
                        int gg = ((int)(image[i, j]) & 0xFF00) >> 8;
                        int bb = ((int)(image[i, j]) & 0xFF);
                        r[i, j] = rr / 255.0;
                        g[i, j] = gg / 255.0;
                        b[i, j] = bb / 255.0;
                    }
                }

                outputs[RedChannel] = r;
                outputs[GreenChannel] = g;
                outputs[BlueChannel] = b;
            }
        }
    }
}
