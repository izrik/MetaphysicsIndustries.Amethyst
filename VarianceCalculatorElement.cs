using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Crystalline;
using System.Drawing;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Utilities;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class VarianceCalculatorElement : AmethystElement
    {
        public VarianceCalculatorElement()
            : base(new VarianceCalculatorNode(), new SizeV(60,60))
        {
        }

        [Serializable]
        public class VarianceCalculatorNode : Node
        {
            public VarianceCalculatorNode()
                : base("σ²")
            {
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(WindowInput);
                InputConnectionBases.Add(MeanInput);
                OutputConnectionBases.Add(VarianceOutput);
            }

            private InputConnectionBase _windowInput = new InputConnection<IEnumerable<double>>("Window");
            public InputConnectionBase WindowInput
            {
                get { return _windowInput; }
            }
            private InputConnection<double> _meanInput = new InputConnection<double>("Mean");
            public InputConnection<double> MeanInput
            {
                get { return _meanInput; }
            }

            private OutputConnectionBase _varianceOutput = new OutputConnection<double>("Variance");
            public OutputConnectionBase VarianceOutput
            {
                get { return _varianceOutput; }
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                IEnumerable<double> window = (IEnumerable<double>)inputs[WindowInput];
                double mean = (double)inputs[MeanInput];

                double sum = 0;
                int count = -1;
                foreach (double value in window)
                {
                    double value2 = mean - value;
                    sum += value2 * value2;
                    count++;
                }

                outputs[VarianceOutput] = sum / count;
            }
        }

        protected override void InitTerminals()
        {
            InputTerminal term;
            VarianceCalculatorNode node = (VarianceCalculatorNode)Node;

            term = new InputTerminal(node.WindowInput);
            term.Side = BoxOrientation.Left;
            term.Position = Height / 3.0f;
            Terminals.Add(term);

            term = new InputTerminal(node.MeanInput);
            term.Side = BoxOrientation.Left;
            term.Position = 2.0f * Height / 3.0f;
            Terminals.Add(term);

            OutputTerminal term2 = new OutputTerminal(node.VarianceOutput);
            term2.Side = BoxOrientation.Right;
            term2.Position = Height / 2.0f;
            Terminals.Add(term2);
        }
    }
}
