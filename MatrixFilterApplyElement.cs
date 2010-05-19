using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Acuity;
using MetaphysicsIndustries.Utilities;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class MatrixFilterApplyElement/*<T>*/ : AmethystElement
        //where T : MatrixFilter
    {
        public MatrixFilterApplyElement()
            : base(new MatrixFilterApplyNode(), new SizeV(120,60))
        {
        }

        [Serializable]
        public class MatrixFilterApplyNode : Node
        {
            public MatrixFilterApplyNode()
                : base("Filter Apply")
            {
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(Input);
                InputConnectionBases.Add(Filter);
                OutputConnectionBases.Add(Output);
            }

            private InputConnection<Matrix> _input = new InputConnection<Matrix>("Input");
            public InputConnection<Matrix> Input
            {
                get { return _input; }
            }

            private InputConnection<MatrixFilter> _filter = new InputConnection<MatrixFilter>("Filter");
            public InputConnection<MatrixFilter> Filter
            {
                get { return _filter; }
            }

            private OutputConnection<Matrix> _output = new OutputConnection<Matrix>("Output");
            public OutputConnection<Matrix> Output
            {
                get { return _output; }
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                Matrix image = (Matrix)inputs[Input];
                MatrixFilter filter = (MatrixFilter)inputs[Filter];

                outputs[Output] = filter.Apply(image);
            }
        }

        protected override void InitTerminals()
        {
            InputTerminal term;
            MatrixFilterApplyNode node = (MatrixFilterApplyNode)Node;

            term = new InputTerminal(node.Input);
            term.Position = Height / 2;
            term.Side = BoxOrientation.Left;
            term.Size *= 2;
            Terminals.Add(term);

            term = new InputTerminal(node.Filter);
            term.Position = Width / 2;
            term.Side = BoxOrientation.Up;
            Terminals.Add(term);

            OutputTerminal term2;

            term2 = new OutputTerminal(node.Output);
            term2.Position = Height / 2;
            term2.Side = BoxOrientation.Right;
            term2.Size *= 2;
            Terminals.Add(term2);
        }
    }
}
