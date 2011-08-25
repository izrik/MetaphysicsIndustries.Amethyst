using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Acuity;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class HslToRgbConverterElement : AmethystElement
    {
        public HslToRgbConverterElement()
            : base(new HslToRgbConverterNode())
        {
        }

        [Serializable]
        public class HslToRgbConverterNode : Node
        {
            public HslToRgbConverterNode()
                : base("HSL --> RGB")
            {
            }

            private OutputConnection<Matrix> _red = new OutputConnection<Matrix>("Red");
            public OutputConnection<Matrix> Red
            {
                get { return _red; }
            }
            private OutputConnection<Matrix> _green = new OutputConnection<Matrix>("Green");
            public OutputConnection<Matrix> Green
            {
                get { return _green; }
            }
            private OutputConnection<Matrix> _blue = new OutputConnection<Matrix>("Blue");
            public OutputConnection<Matrix> Blue
            {
                get { return _blue; }
            }

            private InputConnection<Matrix> _hue = new InputConnection<Matrix>("Hue");
            public InputConnection<Matrix> Hue
            {
                get { return _hue; }
            }
            private InputConnection<Matrix> _saturation = new InputConnection<Matrix>("Saturation");
            public InputConnection<Matrix> Saturation
            {
                get { return _saturation; }
            }
            private InputConnection<Matrix> _luminance = new InputConnection<Matrix>("Luminance");
            public InputConnection<Matrix> Luminance
            {
                get { return _luminance; }
            }



            protected override void InitConnections()
            {
                InputConnectionBases.AddRange(Hue, Saturation, Luminance);
                OutputConnectionBases.AddRange(Red, Green, Blue);
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {

                Matrix h = (Matrix)inputs[Hue];
                Matrix s = (Matrix)inputs[Saturation];
                Matrix l = (Matrix)inputs[Luminance];

                Matrix r = h.CloneSize();
                Matrix g = h.CloneSize();
                Matrix b = h.CloneSize();

                int i;
                int j;

                for (i = 0; i < h.RowCount; i++)
                {
                    for (j = 0; j < h.ColumnCount; j++)
                    {
                        float rr;
                        float gg;
                        float bb;

                        AcuityEngine.ConvertHslToRgb(h[i, j], s[i, j], l[i, j], out rr, out gg, out bb);

                        r[i, j] = rr;
                        g[i, j] = gg;
                        b[i, j] = bb;
                    }
                }

                outputs[Red] = r;
                outputs[Green] = g;
                outputs[Blue] = b;
            }
        }
    }
}
