using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Acuity;

namespace MetaphysicsIndustries.Amethyst
{
    public class PyramidProcessorMatrixFilterElement : MatrixFilterElement
    {
        public delegate double Calculation(IEnumerable<double> measures);

        public PyramidProcessorMatrixFilterElement(Calculation estimator, string name)
            : base(new PyramidProcessorMatrixFilter(estimator), name + " Pyramid", new SizeF(60,100))
        {
        }

        protected override void RenderShape(Graphics g, Pen pen, Brush fillBrush, RectangleF rect)
        {
            float th = Height / 4;

            PointF[] pts = new PointF[] {   new PointF(Left, Top), 
                                            new PointF(Right, Top + th), 
                                            new PointF(Right, Bottom - th), 
                                            new PointF(Left, Bottom) };

            g.FillPolygon(fillBrush, pts);
            g.DrawPolygon(pen, pts);
        }

        public class PyramidProcessorMatrixFilter : MatrixFilter
        {
            public PyramidProcessorMatrixFilter(Calculation estimator)
            {
                if (estimator == null) { throw new ArgumentNullException("estimator"); }
							
                _estimator = estimator;
            }

            private Calculation _estimator;

            public override Matrix Apply(Matrix input)
            {
                int row;
                int col;
                double[] samples = new double[4];

                int columnCount = input.ColumnCount - input.ColumnCount % 2;
                int rowCount = input.RowCount - input.RowCount % 2;

                Matrix res = new Matrix(rowCount / 2, columnCount / 2);

                for (row = 0; row < rowCount; row += 2)
                {
                    for (col = 0; col < columnCount; col += 2)
                    {
                        samples[0] = input[row, col];
                        samples[1] = input[row + 1, col];
                        samples[2] = input[row, col + 1];
                        samples[3] = input[row + 1, col + 1];

                        res[row / 2, col / 2] = _estimator(samples);
                    }
                }

                return res;
            }
        }
    }

    public class ArithmeticMeanPyramidProcessor : PyramidProcessorMatrixFilterElement
    {
        public ArithmeticMeanPyramidProcessor()
            : base(AcuityEngine.CalculateMean, "Arith Mean")
        {
        }
    }

    public class GeometricMeanPyramidProcessor : PyramidProcessorMatrixFilterElement
    {
        public GeometricMeanPyramidProcessor()
            : base(AcuityEngine.CalculateGeometricMean, "Geo Mean")
        {
        }
    }

    public class MaxPyramidProcessor : PyramidProcessorMatrixFilterElement
    {
        public static double Max(IEnumerable<double> measures)
        {
            double max = 0;

            foreach (double measure in measures)
            {
                max = Math.Max(max, measure);
            }

            return max;
        }

        public MaxPyramidProcessor()
            : base(Max, "Max")
        {
        }
    }

}
