using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class OutputTerminal : Terminal
    {
        public OutputTerminal(OutputConnectionBase outputConnectionBase)
        {
            if (outputConnectionBase == null) { throw new ArgumentNullException("outputConnectionBase"); }

            _outputConnectionBase = outputConnectionBase;

            _amethystPaths = new OutputTerminalAmethystPathParentChildrenCollection(this);
        }

        private OutputConnectionBase _outputConnectionBase;
        public OutputConnectionBase Connection
        {
            get { return _outputConnectionBase; }
        }
        public override Connection ConnectionBase
        {
            get { return Connection; }
        }

        //private object _result;
        //public object Result
        //{
        //    get { return _result; }
        //    set { _result = value; }
        //}


        protected override PointF[] GetPolygon()
        {
            PointF[] pt = new PointF[3];

            if (Side == BoxOrientation.Up)
            {
                pt[0].X = -1;
                pt[0].Y = 1.732f;
                pt[2].X = 1;
                pt[2].Y = 1.732f;
            }
            else if (Side == BoxOrientation.Right)
            {
                pt[0].X = -1.732f;
                pt[0].Y = -1;
                pt[2].X = -1.732f;
                pt[2].Y = 1;
            }
            else if (Side == BoxOrientation.Down)
            {
                pt[0].X = -1;
                pt[0].Y = -1.732f;
                pt[2].X = 1;
                pt[2].Y = -1.732f;
            }
            else //if (Side == BoxOrientation.Left)
            {
                pt[0].X = 1.732f;
                pt[0].Y = -1;
                pt[2].X = 1.732f;
                pt[2].Y = 1;
            }

            return pt;
        }

        private OutputTerminalAmethystPathParentChildrenCollection _amethystPaths;
        public OutputTerminalAmethystPathParentChildrenCollection AmethystPaths
        {
            get { return _amethystPaths; }
        }

        public override void Disconnect(out Entity[] entitiesToRemove)
        {
            List<Entity> list = new List<Entity>();
            Entity[] array;

            list.AddRange(AmethystPaths.ToArray());

            base.Disconnect(out array);
            if (array != null)
            {
                list.AddRange(array);
            }

            entitiesToRemove = list.ToArray();
        }

        public override void DisconnectTerminal()
        {
            AmethystPaths.Clear();
        }
    }
}
