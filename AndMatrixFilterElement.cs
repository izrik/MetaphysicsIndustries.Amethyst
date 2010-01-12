using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Collections;
using MetaphysicsIndustries.Acuity;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class AndMatrixFilterElement : MatrixFilterElement
    {
        public AndMatrixFilterElement()
            : base(new AndMatrixFilterNode())
        {
        }

        public new AndMatrixFilterNode Node
        {
            get { return (AndMatrixFilterNode)base.Node; }
        }

        protected override void InitTerminals()
        {
            base.InitTerminals();

            //TerminalsByConnection[Node.Input].Position = Height / 2;
            TerminalsByConnection[Node.Input].DisplayText = "A";
            //TerminalsByConnection[Node.Input2].Side = BoxOrientation.Up;
            TerminalsByConnection[Node.Input2].DisplayText = "B";
            //TerminalsByConnection[Node.Input2].Position = Width / 2;
        }

        [Serializable]
        public class AndMatrixFilterNode : MatrixFilterNode
        {
            public AndMatrixFilterNode()
                : base(new AndBiModulatorMatrixFilter(), "And")
            {
            }

            private InputConnection<Matrix> _input2 = new InputConnection<Matrix>("Input2");
            public InputConnection<Matrix> Input2
            {
                get { return _input2; }
            }

            public new AndBiModulatorMatrixFilter Filter
            {
                get { return (AndBiModulatorMatrixFilter)base.Filter; }
            }

            protected override void InitConnections()
            {
                base.InitConnections();

                InputConnectionBases.Add(Input2);
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                Matrix a = (Matrix)inputs[Input];
                Matrix b = (Matrix)inputs[Input2];

                outputs[Output] = Filter.Apply2(new Pair<Matrix>(a, b));
            }
        }

        public class AndBiModulatorMatrixFilter : BiModulatorMatrixFilter
        {
            public AndBiModulatorMatrixFilter()
                : base(AndBiModulator)
            {
            }

            public static double AndBiModulator(double x, double y)
            {
                return x * y;
            }
        }

        
    }
}
