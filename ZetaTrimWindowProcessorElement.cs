using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Collections;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    public class ZetaTrimWindowProcessorElement : WindowProcessorElement
    {
        public ZetaTrimWindowProcessorElement()
            : base(new ZetaTrimWindowProcessorNode())
        {
        }

        public class ZetaTrimWindowProcessorNode : WindowProcessorNode
        {
            public ZetaTrimWindowProcessorNode()
                : base("Zeta Trim")
            {
            }

            private InputConnection<double> _zetaInput = new InputConnection<double>("Zeta");
            public InputConnection<double> ZetaInput
            {
                get { return _zetaInput; }
            }

            protected override void InternalInitConnections()
            {
                InputConnectionBases.Add(ZetaInput);
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                List<double> window = new List<double>((IEnumerable<double>)inputs[WindowInput]);

                double zeta = Math.Abs((double)inputs[ZetaInput]);
                double signalMean = SolusEngine.CalculateMean(window);
                double signalVariance = SolusEngine.CalculateVariance(window, signalMean);
                double signalStdev = Math.Sqrt(signalVariance);
                List<double> validMeasures = new List<double>(window.Count);

                //cull all measures which fall outside the zeta-trim range
                foreach (double value in window)
                {
                    double z = CalculateZ(signalMean, signalStdev, value);
                    if (Math.Abs(z) <= zeta)
                    {
                        validMeasures.Add(value);
                    }
                }

                outputs[WindowOutput] = validMeasures;
            }

            //move this to SolusEngine
            protected double CalculateZ(double mean, double stdev, double x)
            {
                return (x - mean) / stdev;
            }

            protected override IEnumerable<double> InternalExecuteOnOrderedWindow(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs, List<double> window)
            {
                return null;
            }
        }
    }
}
