using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    public class NodeElementConverterNode : Node
    {

        public NodeElementConverterNode()
            : base("Node/Element Converter")
        {
        }

        protected override void InitConnections()
        {
            InputConnectionBases.Add(Input);
            OutputConnectionBases.Add(Output);
        }

        private InputConnection<Node> _input = new InputConnection<Node>("Input");
        public InputConnection<Node> Input
        {
            get { return _input; }
        }

        private OutputConnection<AmethystElement> _output = new OutputConnection<AmethystElement>("Output");
        public OutputConnection<AmethystElement> Output
        {
            get { return _output; }
        }

        public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
        {
            Node node = (Node)inputs[Input];

            outputs[Output] = new NodeElementConverterElement(node);
        }

        public class NodeElementConverterElement : AmethystElement
        {
            public NodeElementConverterElement()
                : this(new NodeElementConverterNode())
            {
            }

            public NodeElementConverterElement(Node node)
                : base(node)
            {
            }
        }
    }
}
