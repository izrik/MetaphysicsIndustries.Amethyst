using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Utilities;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public abstract class WindowProcessorElement : AmethystElement
    {
        public WindowProcessorElement(WindowProcessorNode node)
            : this(node, CalcSizeFromNodeConnections(node))
        {
        }

        public WindowProcessorElement(WindowProcessorNode node, SizeV size)
            : base(node , size)
        {
        }

        [Serializable]
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

            private InputConnection<IEnumerable<float>> _windowInput = new InputConnection<IEnumerable<float>>("WindowInput");
            public InputConnection<IEnumerable<float>> WindowInput
            {
                get { return _windowInput; }
            }

            private OutputConnection<IEnumerable<float>> _windowOutput = new OutputConnection<IEnumerable<float>>("WindowOutput");
            public OutputConnection<IEnumerable<float>> WindowOutput
            {
                get { return _windowOutput; }
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                List<float> window = new List<float>((IEnumerable<float>)inputs[WindowInput]);

                window.Sort();

                outputs[WindowOutput] = InternalExecuteOnOrderedWindow(inputs, outputs, window);
            }

            protected abstract IEnumerable<float> InternalExecuteOnOrderedWindow(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs, List<float> window);
        }
    }
}
