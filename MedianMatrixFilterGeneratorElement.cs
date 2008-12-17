using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Crystalline;

namespace MetaphysicsIndustries.Epiphany.Amethyst
{
    public class MedianMatrixFilterGeneratorElement : MatrixFilterGeneratorElement
    {
        public MedianMatrixFilterGeneratorElement()
            : base(new MedianMatrixFilterGeneratorNode(), new SizeF(120, 80))
        {
        }

        public class MedianMatrixFilterGeneratorNode : MatrixFilterGeneratorNode
        {
            public MedianMatrixFilterGeneratorNode()
                : base("Median Filter Generator")
            {
            }

            protected override void InternalInitConnections()
            {
                InputConnectionBases.Add(WindowSize);
            }

            private InputConnection<int> _windowSize = new InputConnection<int>("Window Size");
            public InputConnection<int> WindowSize
            {
                get { return _windowSize; }
            }

            public override MatrixFilter GenerateFilter(Dictionary<InputConnectionBase, object> inputs)
            {
                return new MedianMatrixFilter((int)inputs[WindowSize]);
            }
        }

        protected override void InternalInitTerminals()
        {
            InputTerminal term = new InputTerminal(((MedianMatrixFilterGeneratorNode)Node).WindowSize);
            term.Side = BoxOrientation.Up;
            term.Position = Width / 2;
            term.DisplayText = "w";
            Terminals.Add(term);
        }
    }
}
