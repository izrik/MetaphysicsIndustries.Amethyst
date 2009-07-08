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
    public class ExpandEdgeMatrixFilterGeneratorElement : MatrixFilterGeneratorElement
    {
        //ExpandEdgeMatrixFilter

        public ExpandEdgeMatrixFilterGeneratorElement()
            : base(new ExpandEdgeMatrixFilterNode(), new SizeF(120, 80))
        {
        }

        public class ExpandEdgeMatrixFilterNode : MatrixFilterGeneratorNode
        {
            public ExpandEdgeMatrixFilterNode()
                : base("Expand Edge Filter Generator")
            {
            }

            protected override void InternalInitConnections()
            {
                InputConnectionBases.Add(BorderSize);
            }

            private InputConnection<int> _borderSize = new InputConnection<int>("Border Size");
            public InputConnection<int> BorderSize
            {
                get { return _borderSize; }
            }

            public override MatrixFilter GenerateFilter(Dictionary<InputConnectionBase, object> inputs)
            {
                return new ExpandEdgeMatrixFilter((int)inputs[BorderSize]);
            }
        }

        protected override void InternalInitTerminals()
        {
            InputTerminal term = new InputTerminal(((ExpandEdgeMatrixFilterNode)Node).BorderSize);
            term.Side = BoxOrientation.Up;
            term.Position = Width / 2;
            term.DisplayText = "b";
            Terminals.Add(term);
        }
    }
}
