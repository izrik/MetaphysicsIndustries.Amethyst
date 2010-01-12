using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Crystalline;
using System.Drawing;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class CrystallineOpenerElement<T> : AmethystElement
        where T : CrystallineControl, new()
    {
        public CrystallineOpenerElement()
            : this(Color.White)
        {
        }
        public CrystallineOpenerElement(Color color)
            : base(new CrystallineOpenerNode(), new SizeF(120, 50))
        {
            _color = color;
            _fillBrush = new SolidBrush(color);
        }

        Color _color;
        SolidBrush _fillBrush;

        [Serializable]
        public class CrystallineOpenerNode : Node
        {
            public CrystallineOpenerNode()
                : base(typeof(T).Name)
            {
            }

            protected override void InitConnections()
            {
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
            }
        }

        protected override void RenderShape(Graphics g, Pen pen, Brush fillBrush, RectangleF rect)
        {
            base.RenderShape(g, pen, _fillBrush, rect);

            rect.Inflate(-5, -5);

            base.RenderShape(g, pen, SystemBrushes.Window, rect);
        }

        public override bool ShallProcessDoubleClick
        {
            get { return true; }
        }

        public override void ProcessDoubleClick(AmethystControl control)
        {
            CrystallineContainerForm form = new CrystallineContainerForm(new T());
            form.ShowDialog(control);
        }
    }
}
