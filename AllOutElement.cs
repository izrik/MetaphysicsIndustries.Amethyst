using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Crystalline;

namespace MetaphysicsIndustries.Epiphany.Amethyst
{
    public class AllOutElement : AmethystElement
    {
        public AllOutElement()
            : base(new NullNode(), new SizeF(50, 50))
        {
        }

        protected override void InitTerminals()
        {
            OutputTerminal terminal;

            terminal = new OutputTerminal(new OutputConnection<object>("1"));
            terminal.Side = BoxOrientation.Left;
            terminal.Position = Height / 2;
            Terminals.Add(terminal);

            terminal = new OutputTerminal(new OutputConnection<object>("2"));
            terminal.Side = BoxOrientation.Up;
            terminal.Position = Width / 2;
            Terminals.Add(terminal);

            terminal = new OutputTerminal(new OutputConnection<object>("3"));
            terminal.Side = BoxOrientation.Right;
            terminal.Position = Height / 2;
            Terminals.Add(terminal);

            terminal = new OutputTerminal(new OutputConnection<object>("4"));
            terminal.Side = BoxOrientation.Down;
            terminal.Position = Width / 2;
            Terminals.Add(terminal);
        }    
    }
}
