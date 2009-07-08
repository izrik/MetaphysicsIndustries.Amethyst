using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;
using System.Drawing;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Acuity;

namespace MetaphysicsIndustries.Amethyst
{
    public class MatrixSlicerElement : AmethystElement
    {
        public MatrixSlicerElement()
            : base(new MatrixSlicerNode())
        {
            Size = Size + new SizeF(50, 0);
        }

        protected override void InitTerminals()
        {
            base.InitTerminals();

            TerminalsByConnection[Node.MatrixInput].Size *= 2;
            TerminalsByConnection[Node.StartRow].DisplayText = "r";
            TerminalsByConnection[Node.StartColumn].DisplayText = "c";
            TerminalsByConnection[Node.NumberOfRows].DisplayText = "Nr";
            TerminalsByConnection[Node.NumberOfColumns].DisplayText = "Nc";
            TerminalsByConnection[Node.Output].Size *= 2;
        }

        public new MatrixSlicerNode Node
        {
            get { return (MatrixSlicerNode)base.Node; }
        }

        public class MatrixSlicerNode : Node
        {
            public MatrixSlicerNode()
                : base("Slicer")
            {
            }

            private InputConnection<Matrix> _matrixInput = new InputConnection<Matrix>("Matrix Input");
            public InputConnection<Matrix> MatrixInput
            {
                get { return _matrixInput; }
            }
            private InputConnection<int> _startRow = new InputConnection<int>("StartRow");
            public InputConnection<int> StartRow
            {
                get { return _startRow; }
            }
            private InputConnection<int> _startColumn = new InputConnection<int>("Start Column");
            public InputConnection<int> StartColumn
            {
                get { return _startColumn; }
            }
            private InputConnection<int> _numberOfRows = new InputConnection<int>("Number Of Rows");
            public InputConnection<int> NumberOfRows
            {
                get { return _numberOfRows; }
            }
            private InputConnection<int> _numberOfColumns = new InputConnection<int>("Number Of Columns");
            public InputConnection<int> NumberOfColumns
            {
                get { return _numberOfColumns; }
            }

            private OutputConnection<Matrix> _output = new OutputConnection<Matrix>("Output");
            public OutputConnection<Matrix> Output
            {
                get { return _output; }
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(MatrixInput);
                InputConnectionBases.Add(StartRow);
                InputConnectionBases.Add(StartColumn);
                InputConnectionBases.Add(NumberOfRows);
                InputConnectionBases.Add(NumberOfColumns);

                OutputConnectionBases.Add(Output);
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                Matrix input = (Matrix)inputs[MatrixInput];
                int startRow = (int)inputs[StartRow];
                int startColumn = (int)inputs[StartColumn];
                int numberOfRows = (int)inputs[NumberOfRows];
                int numberOfColumns = (int)inputs[NumberOfColumns];

                Matrix output = input.GetSlice(startRow, startColumn, numberOfRows, numberOfColumns);

                outputs[Output] = output;
            }
        }
    }
}
