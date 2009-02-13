using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;
using System.Drawing;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Collections;

namespace MetaphysicsIndustries.Amethyst
{
    public class CalculateIntervalMeasureElement : AmethystElement
    {
        public CalculateIntervalMeasureElement()
            : base(new CalculateIntervalMeasureNode(), new SizeF(80,60))
        {
        }

        public new CalculateIntervalMeasureNode Node
        {
            get { return (CalculateIntervalMeasureNode)base.Node; }
        }

        public class CalculateIntervalMeasureNode : Node
        {
            public CalculateIntervalMeasureNode()
                : base("Calc Interval")
            {
            }

            private InputConnection<Matrix> _input = new InputConnection<Matrix>("Input");
            public InputConnection<Matrix> Input
            {
                get { return _input; }
            }

            private OutputConnection<double> _min = new OutputConnection<double>("Min");
            public OutputConnection<double> Min
            {
                get { return _min; }
            }

            private OutputConnection<double> _max = new OutputConnection<double>("Max");
            public OutputConnection<double> Max
            {
                get { return _max; }
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(Input);
                OutputConnectionBases.AddRange(Min, Max);
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                Matrix input = (Matrix)inputs[Input];

                Pair<double> ret = IntervalFitMatrixFilter.CalcInterval(input);

                outputs[Min] = ret.First;
                outputs[Max] = ret.Second;
            }
        }

        protected override void InitTerminals()
        {
            base.InitTerminals();

            TerminalsByConnection[Node.Min].DisplayText = "min";
            TerminalsByConnection[Node.Max].DisplayText = "max";
        }
    }
}
