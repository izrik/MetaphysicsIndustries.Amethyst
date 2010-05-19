using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;
using System.Drawing;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Acuity;
using MetaphysicsIndustries.Utilities;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public abstract class MatrixFilterElement : AmethystElement
    {
        public MatrixFilterElement(MatrixFilter filter, string name)
            : this(new MatrixFilterNode(filter, name))
        {
        }
        public MatrixFilterElement(MatrixFilter filter, string name, SizeV size)
            : this(new MatrixFilterNode(filter, name), size)
        {
        }

        protected MatrixFilterElement(MatrixFilterNode node)
            : base(node)
        {
        }

        protected MatrixFilterElement(MatrixFilterNode node, SizeV size)
            : base(node, size)
        {
        }

        [Serializable]
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
                Execute(inputs, outputs, Filter);
            }
            public virtual void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs, MatrixFilter filter)
            {
                Matrix image = (Matrix)inputs[Input];

                outputs[Output] = Filter.Apply(image);
            }
        }
    }
}
