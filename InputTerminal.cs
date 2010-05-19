using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class InputTerminal : Terminal
    {
        public InputTerminal(InputConnectionBase inputConnectionBase)
        {
            if (inputConnectionBase == null) { throw new ArgumentNullException("inputConnectionBase"); }

            _inputConnectionBase = inputConnectionBase;
        }

        private InputConnectionBase _inputConnectionBase;
        public InputConnectionBase Connection
        {
            get { return _inputConnectionBase; }
        }
        public override Connection ConnectionBase
        {
            get { return Connection; }
        }

        //private bool _isRequired = true;
        //public bool IsRequired
        //{
        //    get { return _isRequired; }
        //    set { _isRequired = value; }
        //}

        public bool IsConnected
        {
            get { return (FromTerminal != null); }
        }
	


        //private object _inputValue;
        //public object InputValue
        //{
        //    get { return _inputValue; }
        //    set { _inputValue = value; }
        //}


        protected override PointF[] GetPolygon()
        {
            PointF[] pt = new PointF[3];

            if (Side == BoxOrientation.Up)
            {
                pt[0].X = -1;
                pt[1].Y = 1.732f;
                pt[2].X = 1;
            }
            else if (Side == BoxOrientation.Right)
            {
                pt[0].Y = -1;
                pt[1].X = -1.732f;
                pt[2].Y = 1;
            }
            else if (Side == BoxOrientation.Down)
            {
                pt[0].X = -1;
                pt[1].Y = -1.732f;
                pt[2].X = 1;
            }
            else //if (Side == BoxOrientation.Left)
            {
                pt[0].Y = -1;
                pt[1].X = 1.732f;
                pt[2].Y = 1;
            }

            return pt;
        }

        private AmethystPath _path;
        public AmethystPath Path
        {
            get { return _path; }
            set
            {
                if (_path != value)
                {
                    InvalidateWithinParentControl();

                    AmethystPath tempPath = _path;

                    _path = value;

                    if (tempPath != null)
                    {
                        tempPath.ToTerminal = null;

                        ClearUnderlyingConnections();
                    }

                    if (_path != null)
                    {
                        _path.ToTerminal = this;

                        SetUnderlyingConnections();
                    }
                }
            }
        }

        protected void ClearUnderlyingConnections()
        {
            _inputConnectionBase.Disconnect();
        }

        protected void SetUnderlyingConnections()
        {
            _inputConnectionBase.Connect(_path.FromTerminal.Connection);
        }


        public bool IsConnectable(OutputTerminal terminal)
        {
            return Connection.IsConnectable(terminal.Connection);
        }

        public OutputTerminal FromTerminal
        {
            get
            {
                if (Path == null) return null;

                return Path.FromTerminal;
            }
        }

        public override void Disconnect(out Entity[] entitiesToRemove)
        {
            List<Entity> list = new List<Entity>();

            if (Path != null)
            {
                list.Add(Path);
            }

            Path = null;

            Entity[] array;
            base.Disconnect(out array);
            if (array != null)
            {
                list.AddRange(array);
            }

            entitiesToRemove = list.ToArray();
        }
    }
}
