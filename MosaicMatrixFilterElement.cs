using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Acuity;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    class MosaicMatrixFilterElement : MatrixFilterElement
    {
        public MosaicMatrixFilterElement()
            :base(new MosaicMatrixFilterNode())
        {
        }

        protected override void InitTerminals()
        {
            base.InitTerminals();
        }

        class MosaicMatrixFilter : MatrixFilter
        {
            public MosaicMatrixFilter(int cellSize)
            {
                _cellSize = cellSize;
            }

            int _cellSize;

            public override Matrix Apply(Matrix input)
            {
                Matrix output = input.CloneSize();

                int i;
                int j;

                int nx = (int)(Math.Ceiling(input.ColumnCount / (float)_cellSize));
                int ny = (int)(Math.Ceiling(input.RowCount / (float)_cellSize));

                int ci;
                int cj;

                double[] values = new double[_cellSize*_cellSize];
                for (i = 0; i < nx; i++)
                {
                    for (j = 0; j < ny; j++)
                    {
                        int k = 0;
                        for (ci = 0; ci < _cellSize; ci++)
                        {
                            if (_cellSize * i + ci >= input.ColumnCount) break;

                            for (cj = 0; cj < _cellSize; cj++)
                            {
                                if (_cellSize * j + cj >= input.RowCount) break;
                                values[k] = input[_cellSize * j + cj, _cellSize * i + ci];
                                k++;
                            }
                        }
                        double sum = 0;
                        for (int vi = 0; vi < k; vi++)
                        {
                            sum += values[vi];
                        }
                        sum /= k;
                        for (ci = 0; ci < _cellSize; ci++)
                        {
                            if (_cellSize * i + ci >= input.ColumnCount) break;
                            for (cj = 0; cj < _cellSize; cj++)
                            {
                                if (_cellSize * j + cj >= input.RowCount) break;
                                output[_cellSize * j + cj, _cellSize * i + ci] = sum;
                            }
                        }
                    }
                }

                return output;
            }
        }


        class MosaicMatrixFilterNode : MatrixFilterNode
        {
            public MosaicMatrixFilterNode()
                : base("Mosaic")
            {
            }

            InputConnection<int> _cellSize = new InputConnection<int>("Cell size");
            public InputConnection<int> CellSize
            {
                get { return _cellSize; }
            }
            protected override void InitConnections()
            {
                base.InitConnections();

                InputConnectionBases.Add(CellSize);
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                MosaicMatrixFilter filter = new MosaicMatrixFilter((int)inputs[CellSize]);
                base.Execute(inputs, outputs, filter);
            }
        }
    }
}
