using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    public class AllInElement : AmethystElement
    {
        public AllInElement()
            : base(new NullNode(), new SizeF(50, 50))
        {
        }

        protected override void InitTerminals()
        {
            InputTerminal terminal;

            terminal = new InputTerminal(new InputConnection<object>("1"));
            terminal.Side = BoxOrientation.Left;
            terminal.Position = Height / 2;
            Terminals.Add(terminal);

            terminal = new InputTerminal(new InputConnection<object>("2"));
            terminal.Side = BoxOrientation.Up;
            terminal.Position = Width / 2;
            Terminals.Add(terminal);

            terminal = new InputTerminal(new InputConnection<object>("3"));
            terminal.Side = BoxOrientation.Right;
            terminal.Position = Height / 2;
            Terminals.Add(terminal);

            terminal = new InputTerminal(new InputConnection<object>("4"));
            terminal.Side = BoxOrientation.Down;
            terminal.Position = Width / 2;
            Terminals.Add(terminal);
        }
    }
}
