using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Acuity;

namespace MetaphysicsIndustries.Amethyst
{
    //[Serializable]
    //public class ImpulseNoiseMatrixFilterGeneratorElement : MatrixFilterGeneratorElement
    //{
    //    public ImpulseNoiseMatrixFilterGeneratorElement()
    //        :base(new ImpulseNoiseMatrixFilterGeneratorNode(), new SizeV(120,80))
    //    {
    //    }

    //    [Serializable]
    //    public class ImpulseNoiseMatrixFilterGeneratorNode : MatrixFilterGeneratorNode
    //    {
    //        public ImpulseNoiseMatrixFilterGeneratorNode()
    //            : base("Impulse Noise Filter Generator")
    //        {
    //        }

    //        protected override void InternalInitConnections()
    //        {
    //            InputConnectionBases.Add(ImpulseProbability);
    //        }

    //        private InputConnection<float> _impulseProbability = new InputConnection<float>("Impulse Probability");
    //        public InputConnection<float> ImpulseProbability
    //        {
    //            get { return _impulseProbability; }
    //        }

    //        public override MatrixFilter GenerateFilter(Dictionary<InputConnectionBase, object> inputs)
    //        {
    //            return new ImpulseNoiseMatrixFilter((float)inputs[ImpulseProbability]);
    //        }
    //    }

    //    protected override void InternalInitTerminals()
    //    {
    //        InputTerminal term = new InputTerminal(((ImpulseNoiseMatrixFilterGeneratorNode)Node).ImpulseProbability);
    //        term.Side = BoxOrientation.Up;
    //        term.Position = Width / 2;
    //        term.DisplayText = "p";
    //        Terminals.Add(term);
    //    }
    //}
}
