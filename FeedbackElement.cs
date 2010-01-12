using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class FeedbackElement : AmethystElement
    {
        public FeedbackElement()
            : base(new FeedbackNode(), new SizeF(100, 100))
        {
        }

        [Serializable]
        protected class FeedbackNode : Node
        {
            public FeedbackNode()
                : base("Feedback")
            {
            }

            protected override void InitConnections()
            {
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
            }
        }

        //protected override void RenderShape(Graphics g, Pen pen, Brush fillBrush, RectangleF rect)
        //{
        //    g.FillEllipse(Brushes.White, rect);
        //    g.DrawEllipse(pen, rect);
        //}

        public override bool ShallProcessDoubleClick
        {
            get { return true; }
        }

        public override void ProcessDoubleClick(AmethystControl control)
        {
        }
    }
}
