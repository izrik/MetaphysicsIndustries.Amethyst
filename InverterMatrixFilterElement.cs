using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Acuity;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class InverterMatrixFilterElement : MatrixFilterElement
    {
        public InverterMatrixFilterElement()
            : base(new InverterMatrixFilterNode())
        {
        }

        public new InverterMatrixFilterNode Node
        {
            get { return (InverterMatrixFilterNode)base.Node; }
        }

        //protected override void InitTerminals()
        //{
        //    base.InitTerminals();

        //    //TerminalsByConnection[Node.Input].Position = Height / 2;
        //    TerminalsByConnection[Node.Input].DisplayText = "A";
        //    //TerminalsByConnection[Node.Input2].Side = BoxOrientation.Up;
        //    TerminalsByConnection[Node.Input2].DisplayText = "B";
        //    //TerminalsByConnection[Node.Input2].Position = Width / 2;
        //}

        [Serializable]
        public class InverterMatrixFilterNode : MatrixFilterNode
        {
            public InverterMatrixFilterNode()
                : base(new InverterModulatorMatrixFilter(), "Inv")
            {
            }

            //private InputConnection<Matrix> _input2 = new InputConnection<Matrix>("Input2");
            //public InputConnection<Matrix> Input2
            //{
            //    get { return _input2; }
            //}

            public new InverterModulatorMatrixFilter Filter
            {
                get { return (InverterModulatorMatrixFilter)base.Filter; }
            }

            //protected override void InitConnections()
            //{
            //    base.InitConnections();

            //    InputConnectionBases.Add(Input2);
            //}

            //public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            //{
            //    Matrix a = (Matrix)inputs[Input];
            //    Matrix b = (Matrix)inputs[Input2];

            //    outputs[Output] = Filter.(new Pair<Matrix>(a, b));
            //}
        }

        [Serializable]
        public class InverterModulatorMatrixFilter : ModulatorMatrixFilter
        {
            public InverterModulatorMatrixFilter()
            {
            }

            public override float Modulate(float x)
            {
                return 1 - x;
            }
        }

    }
}
