using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Acuity;
using MetaphysicsIndustries.Utilities;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class PyramidProcessorMatrixFilterElement : MatrixFilterElement
    {
        //public delegate double Calculation(IEnumerable<double> measures);
        public interface ICalculation
        {
            double Calculate(IEnumerable<double> measures);
        }

        public PyramidProcessorMatrixFilterElement(ICalculation estimator, string name)
            : base(new PyramidProcessorMatrixFilter(estimator), name + " Pyramid", new SizeV(60, 100))
        {
        }

        protected override void RenderShape(Graphics g, Pen pen, Brush fillBrush, RectangleV rect)
        {
            float th = Height / 4;

            PointF[] pts = new PointF[] {   new PointF(Left, Top), 
                                            new PointF(Right, Top + th), 
                                            new PointF(Right, Bottom - th), 
                                            new PointF(Left, Bottom) };

            g.FillPolygon(fillBrush, pts);
            g.DrawPolygon(pen, pts);
        }

        [Serializable]
        public class PyramidProcessorMatrixFilter : MatrixFilter
        {
            public PyramidProcessorMatrixFilter(ICalculation estimator)
            {
                if (estimator == null) { throw new ArgumentNullException("estimator"); }

                _estimator = estimator;
            }

            private ICalculation _estimator;

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

                        res[row / 2, col / 2] = _estimator.Calculate(samples);
                    }
                }

                return res;
            }
        }
    }

    [Serializable]
    public class ArithmeticMeanPyramidProcessor : PyramidProcessorMatrixFilterElement
    {
        public ArithmeticMeanPyramidProcessor()
            : base(new MeanCalculator(), "Arith Mean")
        {
        }

        public class MeanCalculator : ICalculation
        {
            public double Calculate(IEnumerable<double> measures)
            {
                return AcuityEngine.CalculateMean(measures);
            }
        }
    }

    [Serializable]
    public class GeometricMeanPyramidProcessor : PyramidProcessorMatrixFilterElement
    {
        public GeometricMeanPyramidProcessor()
            : base(new GeometricMeanCalculator(), "Geo Mean")
        {
        }

        public class GeometricMeanCalculator : ICalculation
        {
            public double Calculate(IEnumerable<double> measures)
            {
                return AcuityEngine.CalculateGeometricMean(measures);
            }
        }
    }

    [Serializable]
    public class MaxPyramidProcessor : PyramidProcessorMatrixFilterElement
    {

        public MaxPyramidProcessor()
            : base(new MaxCalculator(), "Max")
        {
        }


        public class MaxCalculator : ICalculation
        {
            //public static double Max(IEnumerable<double> measures)
            public double Calculate(IEnumerable<double> measures)
            {
                double max = 0;

                foreach (double measure in measures)
                {
                    max = Math.Max(max, measure);
                }

                return max;
            }
        }

    }

}
