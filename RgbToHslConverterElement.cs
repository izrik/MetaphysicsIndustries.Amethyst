using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Collections;
using MetaphysicsIndustries.Acuity;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class RgbToHslConverterElement : AmethystElement
    {
        public RgbToHslConverterElement()
            : base(new RgbToHslConverterNode())
        {
        }

        [Serializable]
        public class RgbToHslConverterNode : Node
        {
            public RgbToHslConverterNode()
                :base("RGB --> HSL")
            {
            }

            private InputConnection<Matrix> _red = new InputConnection<Matrix>("Red");
            public InputConnection<Matrix> Red
            {
                get { return _red; }
            }
            private InputConnection<Matrix> _green = new InputConnection<Matrix>("Green");
            public InputConnection<Matrix> Green
            {
                get { return _green; }
            }
            private InputConnection<Matrix> _blue = new InputConnection<Matrix>("Blue");
            public InputConnection<Matrix> Blue
            {
                get { return _blue; }
            }

            private OutputConnection<Matrix> _hue = new OutputConnection<Matrix>("Hue");
            public OutputConnection<Matrix> Hue
            {
                get { return _hue; }
            }
            private OutputConnection<Matrix> _saturation = new OutputConnection<Matrix>("Saturation");
            public OutputConnection<Matrix> Saturation
            {
                get { return _saturation; }
            }
            private OutputConnection<Matrix> _luminance = new OutputConnection<Matrix>("Luminance");
            public OutputConnection<Matrix> Luminance
            {
                get { return _luminance; }
            }



            protected override void InitConnections()
            {
                InputConnectionBases.AddRange(Red, Green, Blue);
                OutputConnectionBases.AddRange(Hue, Saturation, Luminance);
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                Matrix r = (Matrix)inputs[Red];
                Matrix g = (Matrix)inputs[Green];
                Matrix b = (Matrix)inputs[Blue];

                Matrix h = r.CloneSize();
                Matrix s = h.CloneSize();
                Matrix l = h.CloneSize();

                int i;
                int j;

                for (i = 0; i < r.RowCount; i++)
                {
                    for (j = 0; j < r.ColumnCount; j++)
                    {
                        Triple<double> hsl = AcuityEngine.ConvertRgbToHsl(new Triple<double>(r[i, j], g[i, j], b[i, j]));
                        h[i, j] = hsl.First;
                        s[i, j] = hsl.Second;
                        l[i, j] = hsl.Third;
                    }
                }

                outputs[Hue] = h;
                outputs[Saturation] = s;
                outputs[Luminance] = l;
            }
        }
    }
}
