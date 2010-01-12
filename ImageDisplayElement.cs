using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Ligra;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Acuity;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class ImageDisplayElement : AmethystElement
    {
        public ImageDisplayElement()
            : base(new ImageDisplayNode(), new SizeF(60, 60))
        {
        }

        public new ImageDisplayNode Node
        {
            get { return (ImageDisplayNode)base.Node; }
        }

        [Serializable]
        public class ImageDisplayNode : Node
        {
            public ImageDisplayNode()
                : base("Image Display")
            {
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(Input);
            }

            private InputConnectionBase _input = new InputConnection<Matrix>("Input");
            public InputConnectionBase Input
            {
                get { return _input; }
            }

            private Matrix _image;
            public Matrix Image
            {
                get { return _image; }
                set { _image = value; }
            }


            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                Image = (Matrix)inputs[Input];
            }
        }

        public override bool ShallProcessDoubleClick
        {
            get { return true; }
        }

        protected override void RenderPreTransform(Graphics g, Pen pen, Brush brush, Font font)
        {
            UpdateImageCache();

            if (_lastBitmap != null)
            {
                RectangleF rect = Rect;
                rect.Inflate(-4, -4);
                g.DrawImage(_lastBitmap, rect);
            }
        }

        protected override void RenderText(Graphics g, Pen pen, Brush brush, Font font)
        {
            UpdateImageCache();

            if (_lastBitmap == null)
            {
                base.RenderText(g, pen, brush, font);
            }
        }

        Matrix _lastMatrixUnclone;
        Matrix _lastMatrix;
        Bitmap _lastBitmap;

        protected void UpdateImageCache()
        {
            Matrix matrix = ((ImageDisplayNode)Node).Image;

            if (_lastMatrixUnclone != matrix && matrix != null)
            {
                _lastMatrixUnclone = matrix;

                matrix = matrix.Clone();

                matrix.ApplyToAll(AcuityEngine.ConvertFloatTo24g);
                Bitmap bitmap = LigraControl.RenderMatrixToBitmapS(matrix);

                if (_lastMatrix == null || _lastBitmap == null)
                {
                }

                _lastMatrix = matrix;
                _lastBitmap = bitmap;

                if (_lastMatrix == null || _lastBitmap == null)
                {
                }
            }
        }

        public override void ProcessDoubleClick(AmethystControl control)
        {
            UpdateImageCache();

            //ImageDisplayForm form = new ImageDisplayForm();
            //form.Image = _lastBitmap;
            //form.ShowDialog(control);

            ImageDisplayForm.OpenDisplay(_lastBitmap, control);
        }
    }
}
