using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    public class TextElement : AmethystElement
    {
        public TextElement()
            : base(new NullNode())
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

        protected override void OnRectChanged(EventArgs e)
        {
            UpdateTerminalPositions();

            base.OnRectChanged(e);
        }

        private void UpdateTerminalPositions()
        {
            if (Terminals != null)
            {
                foreach (Terminal terminal in Terminals)
                {
                    if (terminal.Side == BoxOrientation.Left || terminal.Side == BoxOrientation.Right)
                    {
                        terminal.Position = Height / 2;
                    }
                    else
                    {
                        terminal.Position = Width / 2;
                    }
                }
            }
        }

        protected override void InitTerminals()
        {
            Terminal terminal;

            terminal = new InputTerminal(new InputConnection<object>("li"));
            terminal.Side = BoxOrientation.Left;
            terminal.Position = Height / 2;
            Terminals.Add(terminal);

            terminal = new InputTerminal(new InputConnection<object>("ui"));
            terminal.Side = BoxOrientation.Up;
            terminal.Position = Width / 2;
            Terminals.Add(terminal);

            terminal = new InputTerminal(new InputConnection<object>("ri"));
            terminal.Side = BoxOrientation.Right;
            terminal.Position = Height / 2;
            Terminals.Add(terminal);

            terminal = new InputTerminal(new InputConnection<object>("di"));
            terminal.Side = BoxOrientation.Down;
            terminal.Position = Width / 2;
            Terminals.Add(terminal);

            terminal = new OutputTerminal(new OutputConnection<object>("lo"));
            terminal.Side = BoxOrientation.Left;
            terminal.Position = Height / 2;
            Terminals.Add(terminal);

            terminal = new OutputTerminal(new OutputConnection<object>("uo"));
            terminal.Side = BoxOrientation.Up;
            terminal.Position = Width / 2;
            Terminals.Add(terminal);

            terminal = new OutputTerminal(new OutputConnection<object>("ro"));
            terminal.Side = BoxOrientation.Right;
            terminal.Position = Height / 2;
            Terminals.Add(terminal);

            terminal = new OutputTerminal(new OutputConnection<object>("do"));
            terminal.Side = BoxOrientation.Down;
            terminal.Position = Width / 2;
            Terminals.Add(terminal);

        }
    }
}
