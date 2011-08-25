using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class AlphaTrimWindowProcessorElement : WindowProcessorElement
    {
        public AlphaTrimWindowProcessorElement()
            : base(new AlphaTrimWindowProcessorNode())
        {
        }

        [Serializable]
        public class AlphaTrimWindowProcessorNode : WindowProcessorNode
        {
            public AlphaTrimWindowProcessorNode()
                : base("Alpha Trim")
            {
            }

            private InputConnection<float> _alphaInput = new InputConnection<float>("Alpha");
            public InputConnection<float> AlphaInput
            {
                get { return _alphaInput; }
            }

            protected override void InternalInitConnections()
            {
                InputConnectionBases.Add(AlphaInput);
            }

            protected override IEnumerable<float> InternalExecuteOnOrderedWindow(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs, List<float> window)
            {
                float alpha = (float)inputs[AlphaInput];
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
