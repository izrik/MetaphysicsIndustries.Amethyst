using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    public class AlphaTrimWindowProcessorElement : WindowProcessorElement
    {
        public AlphaTrimWindowProcessorElement()
            : base(new AlphaTrimWindowProcessorNode())
        {
        }

        public class AlphaTrimWindowProcessorNode : WindowProcessorNode
        {
            public AlphaTrimWindowProcessorNode()
                : base("Alpha Trim")
            {
            }

            private InputConnection<double> _alphaInput = new InputConnection<double>("Alpha");
            public InputConnection<double> AlphaInput
            {
                get { return _alphaInput; }
            }

            protected override void InternalInitConnections()
            {
                InputConnectionBases.Add(AlphaInput);
            }

            protected override IEnumerable<double> InternalExecuteOnOrderedWindow(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs, List<double> window)
            {
                double alpha = (double)inputs[AlphaInput];
                int alphaCount = (int)Math.Ceiling(window.Count * alpha / 2);
                if (window.Count > alphaCount)
                {
                    window = window.GetRange(0, window.Count - alphaCount);
                }
                if (window.Count > alphaCount)
                {
                    window = window.GetRange(alphaCount, window.Count - alphaCount);
                }

                return window;
            }
        }
    }
}
