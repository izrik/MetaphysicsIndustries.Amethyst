using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Utilities;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public abstract class TerminalElement : AmethystElement
    {
        public TerminalElement(Terminal terminal)
            : base(new NullNode(), new SizeV(60,60))
        {
            Terminal = terminal;

            InitTerminals2();
        }

        //eww...
        protected abstract void InitTerminals2();
        protected override void InitTerminals()
        {
        }

        protected override void RenderShape(Graphics g, Pen pen, Brush fillBrush, RectangleV rect)
        {
            g.FillEllipse(fillBrush, rect);
            g.DrawEllipse(pen, rect);

            RenderPolygon(g, pen, fillBrush, rect);
        }

        protected abstract PointF[] GetPolygon();

        protected virtual void RenderPolygon(Graphics g, Pen pen, Brush brush, RectangleV rect)
        {
            PointF[] pt = GetPolygon();
            int i;

            SizeV position = new SizeV(GetCenterOfBox());

            for (i = 0; i < pt.Length; i++)
            {
                pt[i].X *= 25;
                pt[i].X -= 25;
                pt[i].Y *= 25;
                pt[i] += position;
            }

            g.FillPolygon(brush, pt);
            g.DrawPolygon(pen, pt);
        }

        Terminal _terminal;
        public Terminal Terminal
        {
            get { return _terminal; }
            protected set { _terminal = value; }
        }

        public override string Text
        {
            get
            {
                return Terminal != null ? Terminal.DisplayText : "{null}";
            }
        }

        public override bool ShallProcessDoubleClick
        {
            get
            {
                return true;
            }
        }

        public override void ProcessDoubleClick(AmethystControl control)
        {
            TerminalEditorForm form =
                new TerminalEditorForm(
                    Terminal.ConnectionBase.Name,
                    Terminal.DisplayText,
                    Terminal.ConnectionBase.TypeForConnection,
                    Terminal.Side,
                    Terminal.Position, 
                    this.Size);

            if (form.ShowDialog(control) == System.Windows.Forms.DialogResult.OK)
            {
                if (form.TerminalType != Terminal.ConnectionBase.TypeForConnection ||
                    form.TerminalName != Terminal.ConnectionBase.Name)
                {
                    Terminal term = CreateTerminal(form.TerminalType, form.TerminalName);
                    Terminal.ParentAmethystElement.SwapTerminal(Terminal, term);
                    Terminal = term;
                }

                Terminal.DisplayText = form.TerminalDisplayText;
                Terminal.Side = form.TerminalOrientation;
                Terminal.Position = form.TerminalPosition;
            }
        }

        protected abstract Terminal CreateTerminal(Type type, string name);
    }
}
