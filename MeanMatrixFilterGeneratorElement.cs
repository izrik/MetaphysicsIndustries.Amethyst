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
    public class MeanMatrixFilterGeneratorElement : MatrixFilterGeneratorElement
    {
        public MeanMatrixFilterGeneratorElement()
            : base(new MeanMatrixFilterGeneratorNode(), new SizeF(120, 80))
        {
        }


        public class MeanMatrixFilterGeneratorNode : MatrixFilterGeneratorNode
        {
            public MeanMatrixFilterGeneratorNode()
                : base("Mean Filter Generator")
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
                return new ArithmeticMeanFilter((int)inputs[WindowSize]);
            }
        }

        protected override void InternalInitTerminals()
        {
            InputTerminal term = new InputTerminal(((MeanMatrixFilterGeneratorNode)Node).WindowSize);
            term.Side = BoxOrientation.Up;
            term.Position = Width / 2;
            term.DisplayText = "w";
            Terminals.Add(term);
        }
    }
}
