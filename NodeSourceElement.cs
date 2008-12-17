using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Epiphany.Amethyst
{
    public class NodeSourceElement : AmethystElement
    {
        public NodeSourceElement()
            : base(new NodeSourceNode())
        {
        }

        public override void ProcessDoubleClick(AmethystControl control)
        {
            
        }

        public override bool ShallProcessDoubleClick
        {
            get { return true; }
        }

        public class NodeSourceNode : Node
        {
            public NodeSourceNode()
                : base("Node Source")
            {
            }

            private Node _node;
            public Node Node
            {
                get { return _node; }
                set { _node = value; }
            }


            private OutputConnection<Node> _output = new OutputConnection<Node>("Output");
            public OutputConnection<Node> Output
            {
                get { return _output; }
            }

            protected override void InitConnections()
            {
                OutputConnectionBases.Add(Output);
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                outputs[Output] = Node;
            }
        }
    }


}

