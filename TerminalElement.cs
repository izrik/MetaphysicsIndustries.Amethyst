using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Crystalline;

namespace MetaphysicsIndustries.Epiphany.Amethyst
{
    public abstract class TerminalElement : AmethystElement
    {
        public TerminalElement()
            : base(new NullNode(), new SizeF(50,50))
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
                pt[i].Y *= 25;
                pt[i] += position;
            }

            g.FillPolygon(brush, pt);
            g.DrawPolygon(pen, pt);
        }

        protected override void RenderText(Graphics g, Pen pen, Brush brush, Font font)
        {
            base.RenderText(g, pen, brush, font);
        }

        public abstract Terminal Terminal
        {
            get;
        }

    }
}
