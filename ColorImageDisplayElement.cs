using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Solus;
using System.Drawing;
using MetaphysicsIndustries.Ligra;
using MetaphysicsIndustries.Acuity;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    class ColorImageDisplayElement : AmethystElement
    {
        public ColorImageDisplayElement()
            : base(new ColorImageDisplayNode())
        {
            Size = new SizeF(100, Height);
        }

        public new ColorImageDisplayNode Node
        {
            get { return (ColorImageDisplayNode)base.Node; }
        }

        protected override bool SetInputDisplayNames
        {
            get
            {
                return true;
            }
        }
        [Serializable]
        public class ColorImageDisplayNode : Node
        {
            public ColorImageDisplayNode()
                : base("Color Image Display")
            {
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(InputR);
                InputConnectionBases.Add(InputG);
                InputConnectionBases.Add(InputB);
            }

            private InputConnectionBase _inputR = new InputConnection<Matrix>("R");
            public InputConnectionBase InputR
            {
                get { return _inputR; }
            }
            private InputConnectionBase _inputG = new InputConnection<Matrix>("G");
            public InputConnectionBase InputG
            {
                get { return _inputG; }
            }
            private InputConnectionBase _inputB = new InputConnection<Matrix>("B");
            public InputConnectionBase InputB
            {
                get { return _inputB; }
            }

            private Matrix _imageR;
            public Matrix ImageR
            {
                get { return _imageR; }
                set { _imageR = value; }
            }
            private Matrix _imageG;
            public Matrix ImageG
            {
                get { return _imageG; }
                set { _imageG = value; }
            }
            private Matrix _imageB;
            public Matrix ImageB
            {
                get { return _imageB; }
                set { _imageB = value; }
            }


            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                Matrix imageR = (Matrix)inputs[InputR];
                Matrix imageG = (Matrix)inputs[InputG];
                Matrix imageB = (Matrix)inputs[InputB];

                if (imageR.ColumnCount != imageG.ColumnCount ||
                    imageR.ColumnCount != imageB.ColumnCount ||
                    imageG.ColumnCount != imageB.ColumnCount ||
                    imageR.RowCount != imageG.RowCount ||
                    imageR.RowCount != imageB.RowCount ||
                    imageG.RowCount != imageB.RowCount)
                {
                    throw new InvalidOperationException("Input channels must be the same size");
                }

                ImageR = imageR;
                ImageG = imageG;
                ImageB = imageB;
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

        Matrix _lastMatrixUncloneR;
        Matrix _lastMatrixR;
        Matrix _lastMatrixUncloneG;
        Matrix _lastMatrixG;
        Matrix _lastMatrixUncloneB;
        Matrix _lastMatrixB;
        Bitmap _lastBitmap;
        TriModulatorMatrixFilter _colorModulator = new TriModulatorMatrixFilter(AcuityEngine.ConvertRgbTo24cTriModulator);

        protected void UpdateImageCache()
        {
            bool needsNewBitmap = false;
            Matrix matrix;

            matrix = ((ColorImageDisplayNode)Node).ImageR;
            if (_lastMatrixUncloneR != matrix && matrix != null)
            {
                needsNewBitmap = true;
                _lastMatrixUncloneR = matrix;
                matrix = matrix.Clone();
                _lastMatrixR = matrix;
            }

            matrix = ((ColorImageDisplayNode)Node).ImageG;
            if (_lastMatrixUncloneG != matrix && matrix != null)
            {
                needsNewBitmap = true;
                _lastMatrixUncloneG = matrix;
                matrix = matrix.Clone();
                _lastMatrixG = matrix;
            }

            matrix = ((ColorImageDisplayNode)Node).ImageB;
            if (_lastMatrixUncloneB != matrix && matrix != null)
            {
                needsNewBitmap = true;
                _lastMatrixUncloneB = matrix;
                matrix = matrix.Clone();
                _lastMatrixB = matrix;
            }

            if (needsNewBitmap)
            {
                _lastBitmap = LigraControl.RenderMatrixToColorBitmapS(_lastMatrixR, _lastMatrixG, _lastMatrixB);
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
