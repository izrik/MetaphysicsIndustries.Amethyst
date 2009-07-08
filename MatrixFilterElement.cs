using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;
using System.Drawing;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Acuity;

namespace MetaphysicsIndustries.Amethyst
{
    public abstract class MatrixFilterElement : AmethystElement
    {
        public MatrixFilterElement(MatrixFilter filter, string name)
            : this(new MatrixFilterNode(filter, name))
        {
        }

        protected MatrixFilterElement(MatrixFilterNode node)
            : base(node)
        {
        }

        protected MatrixFilterElement(MatrixFilterNode node, SizeF size)
            : base(node, size)
        {
        }

        public class MatrixFilterNode : Node
        {
            public MatrixFilterNode(string name)
                : this(new IdentityFilter(), name)
            {
            }

            public MatrixFilterNode(MatrixFilter filter, string name)
                :base(name)
            {
                _filter = filter;
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(Input);
                OutputConnectionBases.Add(Output);
            }

            private MatrixFilter _filter;
            public MatrixFilter Filter
            {
                get { return _filter; }
                protected set { _filter = value; }
            }

            private InputConnection<Matrix> _input = new InputConnection<Matrix>("Input");
            public InputConnection<Matrix> Input
            {
                get { return _input; }
            }


            private OutputConnection<Matrix> _output = new OutputConnection<Matrix>("Output");
            public OutputConnection<Matrix> Output
            {
                get { return _output; }
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                Matrix image = (Matrix)inputs[Input];

                outputs[Output] = Filter.Apply(image);
            }
        }
    }
}
