using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Utilities;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Crystalline;

namespace MetaphysicsIndustries.Amethyst
{
    public class OneOutElement:AmethystElement
    {
        public OneOutElement()
            : base(new NullNode(), new SizeV(50, 50))
        {
        }

        protected override void InitTerminals()
        {
            OutputTerminal terminal;

            terminal = new OutputTerminal(new OutputConnection<object>("out"));
            terminal.Side = BoxOrientation.Right;
            terminal.Position = Height / 2;

            Terminals.Add(terminal);
        }
    }
}
