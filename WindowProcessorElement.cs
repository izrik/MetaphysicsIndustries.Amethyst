using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MetaphysicsIndustries.Epiphany.Amethyst
{
    public abstract class WindowProcessorElement : AmethystElement
    {
        public WindowProcessorElement(WindowProcessorNode node)
            : this(node, CalcSizeFromNodeConnections(node))
        {
        }

        public WindowProcessorElement(WindowProcessorNode node, SizeF size)
            : base(node , size)
        {
        }

        public abstract class WindowProcessorNode : Node
        {
            public WindowProcessorNode(string name)
                : base(name)
            {
            }

            protected sealed override void InitConnections()
            {
                InputConnectionBases.Add(WindowInput);
                OutputConnectionBases.Add(WindowOutput);

                InternalInitConnections();
            }

            protected abstract void InternalInitConnections();

            private InputConnection<IEnumerable<double>> _windowInput = new InputConnection<IEnumerable<double>>("WindowInput");
            public InputConnection<IEnumerable<double>> WindowInput
            {
                get { return _windowInput; }
            }

            private OutputConnection<IEnumerable<double>> _windowOutput = new OutputConnection<IEnumerable<double>>("WindowOutput");
            public OutputConnection<IEnumerable<double>> WindowOutput
            {
                get { return _windowOutput; }
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                List<double> window = new List<double>((IEnumerable<double>)inputs[WindowInput]);

                window.Sort();

                outputs[WindowOutput] = InternalExecuteOnOrderedWindow(inputs, outputs, window);
            }

            protected abstract IEnumerable<double> InternalExecuteOnOrderedWindow(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs, List<double> window);
        }
    }
}
