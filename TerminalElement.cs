using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Crystalline;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public abstract class TerminalElement : AmethystElement
    {
        public TerminalElement(Terminal terminal)
            : base(new NullNode(), new SizeF(60,60))
        {
            _terminal = terminal;

            InitTerminals2();
        }

        //eww...
        protected abstract void InitTerminals2();
        protected override void InitTerminals()
        {
        }

        protected override void RenderShape(Graphics g, Pen pen, Brush fillBrush, RectangleF rect)
        {
            g.FillEllipse(fillBrush, rect);
            g.DrawEllipse(pen, rect);

            RenderPolygon(g, pen, fillBrush, rect);
        }

        protected abstract PointF[] GetPolygon();

        protected virtual void RenderPolygon(Graphics g, Pen pen, Brush brush, RectangleF rect)
        {
            PointF[] pt = GetPolygon();
            int i;

            SizeF position = new SizeF(GetCenterOfBox());

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

        //protected override void RenderText(Graphics g, Pen pen, Brush brush, Font font)
        //{
        //    base.RenderText(g, pen, brush, font);
        //}

        Terminal _terminal;
        public Terminal Terminal
        {
            get { return _terminal; }
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
            //TerminalEditorForm form = new TerminalEditorForm(Terminal);

            //if (form.ShowDialog(control) == System.Windows.Forms.DialogResult.OK)
            //{
            //}
        }
    }
}
