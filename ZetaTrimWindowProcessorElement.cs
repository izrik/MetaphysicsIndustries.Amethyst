using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Collections;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class ZetaTrimWindowProcessorElement : WindowProcessorElement
    {
        public ZetaTrimWindowProcessorElement()
            : base(new ZetaTrimWindowProcessorNode())
        {
        }

        [Serializable]
        public class ZetaTrimWindowProcessorNode : WindowProcessorNode
        {
            public ZetaTrimWindowProcessorNode()
                : base("Zeta Trim")
            {
            }

            private InputConnection<float> _zetaInput = new InputConnection<float>("Zeta");
            public InputConnection<float> ZetaInput
            {
                get { return _zetaInput; }
            }

            protected override void InternalInitConnections()
            {
                InputConnectionBases.Add(ZetaInput);
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                List<float> window = new List<float>((IEnumerable<float>)inputs[WindowInput]);

                float zeta = Math.Abs((float)inputs[ZetaInput]);
                float signalMean = SolusEngine.CalculateMean(window);
                float signalVariance = SolusEngine.CalculateVariance(window, signalMean);
                float signalStdev = (float)Math.Sqrt(signalVariance);
                List<float> validMeasures = new List<float>(window.Count);

                //cull all measures which fall outside the zeta-trim range
                foreach (float value in window)
                {
                    float z = CalculateZ(signalMean, signalStdev, value);
                    if (Math.Abs(z) <= zeta)
                    {
                        validMeasures.Add(value);
                    }
                }

                outputs[WindowOutput] = validMeasures;
            }

            //move this to SolusEngine
            protected float CalculateZ(float mean, float stdev, float x)
            {
                return (x - mean) / stdev;
            }

            protected override IEnumerable<float> InternalExecuteOnOrderedWindow(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs, List<float> window)
            {
                return null;
            }
        }
    }
}
