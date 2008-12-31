using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Crystalline;
using System.Drawing;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    public class ImpulseNoiseFilterElement : MatrixFilterElement
    {
        public ImpulseNoiseFilterElement()
            : base(new ImpulseNoiseFilterNode(), new SizeF(100, 80))
        {
        }

        public new ImpulseNoiseFilterNode Node
        {
            get { return (ImpulseNoiseFilterNode)base.Node; }
        }

        protected override void InitTerminals()
        {
            base.InitTerminals();

            TerminalsByConnection[Node.Input].Position = Height / 2;
            TerminalsByConnection[Node.ImpulseProbability].Side = BoxOrientation.Up;
            TerminalsByConnection[Node.ImpulseProbability].DisplayText = "p";
            TerminalsByConnection[Node.ImpulseProbability].Position = Width / 2;
        }

        public class ImpulseNoiseFilterNode : MatrixFilterNode
        {
            public ImpulseNoiseFilterNode()
                : base("Impulse Noise")
            {
            }

            private InputConnection<double> _impulseProbability = new InputConnection<double>("Impulse Probability");
            public InputConnection<double> ImpulseProbability
            {
                get { return _impulseProbability; }
            }

            protected override void InitConnections()
            {
                base.InitConnections();

                InputConnectionBases.Add(ImpulseProbability);
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                double p = (double)inputs[ImpulseProbability];
                Filter = new ImpulseNoiseMatrixFilter(p);

                base.Execute(inputs, outputs);
            }
        }
    }
}
