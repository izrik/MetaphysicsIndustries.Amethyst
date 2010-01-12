using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;
using System.Drawing;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Acuity;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public abstract class MatrixFilterGeneratorElement : AmethystElement
    {
        public MatrixFilterGeneratorElement(MatrixFilterGeneratorNode node, SizeF size)
            : base(node, size)
        {
        }

        [Serializable]
        public abstract class MatrixFilterGeneratorNode : Node
        {
            public MatrixFilterGeneratorNode(string name)
                : base(name)
            {
            }

            protected sealed override void InitConnections()
            {
                OutputConnectionBases.Add(Output);
                InternalInitConnections();
            }

            protected virtual void InternalInitConnections()
            {
            }

            private OutputConnectionBase _output = new OutputConnection<MatrixFilter>("Output");
            public OutputConnectionBase Output
            {
                get { return _output; }
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                outputs[Output] = GenerateFilter(inputs);
            }

            public abstract MatrixFilter GenerateFilter(Dictionary<InputConnectionBase, object> inputs);
        }

        protected abstract void InternalInitTerminals();

        protected override void InitTerminals()
        {
            OutputTerminal terminal = new OutputTerminal(((MatrixFilterGeneratorNode)Node).Output);
            terminal.Position = Width / 2;
            terminal.Side = BoxOrientation.Down;
            Terminals.Add(terminal);

            InternalInitTerminals();
        }
    }
}
