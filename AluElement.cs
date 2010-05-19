using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Crystalline;
using System.Windows.Forms;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Utilities;

namespace MetaphysicsIndustries.Amethyst
{
    public class AluElement : AmethystElement
    {
        protected AluElement(Node node, SizeV size)
            : base(node, size)
        {
        }

        public AluElement()
            : this(new NullNode(), new SizeV(80, 60))
        {
        }

        private string _text = string.Empty;
        public override string Text
        {
            get { return _text; }
        }

        public override bool ShallProcessDoubleClick
        {
            get { return true; }
        }

        public override void ProcessDoubleClick(AmethystControl control)
        {
            TextElementPropertiesForm form = new TextElementPropertiesForm();

            form.ElementText = Text;
            form.ElementWidth = Width;
            form.ElementHeight = Height;
            form.ElementShallRenderTerminals = ShallRenderTerminals;

            if (form.ShowDialog(control) == DialogResult.OK)
            {
                _text = form.ElementText;
                Width = form.ElementWidth;
                Height = form.ElementHeight;
                _shallRenderTerminals = form.ElementShallRenderTerminals;
            }
        }

        private bool _shallRenderTerminals = true;
        public override bool ShallRenderTerminals
        {
            get { return _shallRenderTerminals; }
        }

        protected override void InitTerminals()
        {
            Terminal terminal;

            terminal = new InputTerminal(new InputConnection<object>("s"));
            terminal.Side = BoxOrientation.Left;
            terminal.Position = Height / 2;
            Terminals.Add(terminal);

            terminal = new InputTerminal(new InputConnection<object>("a"));
            terminal.Side = BoxOrientation.Up;
            terminal.Position = Width / 3;
            Terminals.Add(terminal);

            terminal = new InputTerminal(new InputConnection<object>("b"));
            terminal.Side = BoxOrientation.Up;
            terminal.Position = 2 * Width / 3;
            Terminals.Add(terminal);


            terminal = new OutputTerminal(new OutputConnection<object>("r"));
            terminal.Side = BoxOrientation.Right;
            terminal.Position = Height / 2;
            Terminals.Add(terminal);


            InitOutTerminals();

        }

        protected virtual void InitOutTerminals()
        {
            Terminal terminal;

            terminal = new OutputTerminal(new OutputConnection<object>("do"));
            terminal.Side = BoxOrientation.Down;
            terminal.Position = Width / 2;
            Terminals.Add(terminal);
        }
    }

    [Serializable]
    public class MuxElement : AluElement
    {
        public MuxElement()
            : base(new NullNode(), new SizeV(180, 60))
        {
        }

        protected override void InitTerminals()
        {
            Terminal terminal;

            terminal = new InputTerminal(new InputConnection<object>("A"));
            terminal.Side = BoxOrientation.Up;
            terminal.Position = 20;
            Terminals.Add(terminal);

            terminal = new InputTerminal(new InputConnection<object>("B"));
            terminal.Side = BoxOrientation.Up;
            terminal.Position = 40;
            Terminals.Add(terminal);

            terminal = new InputTerminal(new InputConnection<object>("Adder"));
            terminal.Side = BoxOrientation.Up;
            terminal.Position = 60;
            Terminals.Add(terminal);

            terminal = new InputTerminal(new InputConnection<object>("Bitwise"));
            terminal.Side = BoxOrientation.Up;
            terminal.Position = 80;
            Terminals.Add(terminal);

            terminal = new InputTerminal(new InputConnection<object>("Shift"));
            terminal.Side = BoxOrientation.Up;
            terminal.Position = 100;
            Terminals.Add(terminal);

            terminal = new InputTerminal(new InputConnection<object>("MultHi"));
            terminal.Side = BoxOrientation.Up;
            terminal.Position = 120;
            Terminals.Add(terminal);

            terminal = new InputTerminal(new InputConnection<object>("MultLo"));
            terminal.Side = BoxOrientation.Up;
            terminal.Position = 140;
            Terminals.Add(terminal);

            terminal = new InputTerminal(new InputConnection<object>("Comp"));
            terminal.Side = BoxOrientation.Up;
            terminal.Position = 160;
            Terminals.Add(terminal);

            //terminal = new InputTerminal(new InputConnection<object>("S0"));
            //terminal.Side = BoxOrientation.Left;
            //terminal.Position = 15;
            //Terminals.Add(terminal);

            terminal = new InputTerminal(new InputConnection<object>("S1"));
            terminal.Side = BoxOrientation.Left;
            terminal.Position = 30;
            Terminals.Add(terminal);

            //terminal = new InputTerminal(new InputConnection<object>("S2"));
            //terminal.Side = BoxOrientation.Left;
            //terminal.Position = 45;
            //Terminals.Add(terminal);

            terminal = new OutputTerminal(new OutputConnection<object>("Output"));
            terminal.Side = BoxOrientation.Down;
            terminal.Position = Width / 2;
            Terminals.Add(terminal);
        }
    }

    [Serializable]
    public class MultAluElement : AluElement
    {
        protected override void InitOutTerminals()
        {
            Terminal terminal;

            terminal = new OutputTerminal(new OutputConnection<object>("hi"));
            terminal.Side = BoxOrientation.Down;
            terminal.Position = 30;
            Terminals.Add(terminal);

            terminal = new OutputTerminal(new OutputConnection<object>("lo"));
            terminal.Side = BoxOrientation.Down;
            terminal.Position = 50;
            Terminals.Add(terminal);
        }
    }
}
