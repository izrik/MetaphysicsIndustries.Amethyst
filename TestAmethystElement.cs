using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Crystalline;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class TestAmethystElement : AmethystElement
    {
        public TestAmethystElement()
            : base(new TestNode())
        {
        }

        protected override void InitTerminals()
        {
            InputTerminal it = new InputTerminal(((TestNode)Node).Input);
            it.Side = BoxOrientation.Left;
            it.Position = Height / 2;
            Terminals.Add(it);

            OutputTerminal ot = new OutputTerminal(((TestNode)Node).Output);
            ot.Side = BoxOrientation.Right;
            ot.Position = Height / 2;
            Terminals.Add(ot);
        }
    }
}
