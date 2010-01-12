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
    [Serializable]
    public class GaussianNoiseMatrixFilterGeneratorElement : MatrixFilterGeneratorElement
    {
        public GaussianNoiseMatrixFilterGeneratorElement()
            : base(new GaussianNoiseMatrixFilterGeneratorNode(), new SizeF(120, 80))
        {
        }

        [Serializable]
        public class GaussianNoiseMatrixFilterGeneratorNode : MatrixFilterGeneratorNode
        {
            public GaussianNoiseMatrixFilterGeneratorNode()
                : base("Gaussian Noise Filter Generator")
            {
            }

            protected override void InternalInitConnections()
            {
                InputConnectionBases.Add(NoiseVariance);
            }

            private InputConnection<double> _noiseVariance = new InputConnection<double>("Noise Variance");
            public InputConnection<double> NoiseVariance
            {
                get { return _noiseVariance; }
            }

            public override MatrixFilter GenerateFilter(Dictionary<InputConnectionBase, object> inputs)
            {
                return new GaussianNoiseMatrixFilter((double)inputs[NoiseVariance]);
            }
        }

        protected override void InternalInitTerminals()
        {
            InputTerminal term = new InputTerminal(((GaussianNoiseMatrixFilterGeneratorNode)Node).NoiseVariance);
            term.Side = BoxOrientation.Up;
            term.Position = Width / 2;
            term.DisplayText = "σ²";
            Terminals.Add(term);
        }
    }
}
