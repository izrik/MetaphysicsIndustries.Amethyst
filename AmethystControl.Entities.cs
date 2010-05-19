using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Collections;
using MetaphysicsIndustries.Acuity;
using MetaphysicsIndustries.Utilities;

namespace MetaphysicsIndustries.Amethyst
{
    public partial class AmethystControl : CrystallineControl
    {
        private Utilities.Vector GetConnectionSourceTerminalLocationInDocumentSpace()
        {
            if (_connectionSourceTerminal != null)
            {
                return _connectionSourceTerminal.GetLocationInDocumentSpace();
            }
            else
            {
                return new Utilities.Vector(0, 0);
            }
        }

        protected Terminal GetFrontmostTerminalAtPointInDocumentSpace(Utilities.Vector docSpace)
        {
            return GetFrontmostTerminalAtPointInDocumentSpace<Terminal>(docSpace);
        }

        protected T GetFrontmostTerminalAtPointInDocumentSpace<T>(Utilities.Vector docSpace)
            where T : Terminal
        {
            return GetFrontmostTerminalAtPointInDocumentSpace<T>(docSpace, null);
        }

        public delegate bool GetFrontmostTerminalCheck<T>(Utilities.Vector docSpace, T terminal) where T : Terminal;

        protected T GetFrontmostTerminalAtPointInDocumentSpace<T>(Utilities.Vector docSpace, GetFrontmostTerminalCheck<T> check)
            where T : Terminal
        {

            //RectangleF rect = new RectangleF(docSpace, new SizeV(0, 0));
            //rect.Inflate(20, 20);

            T ret = null;

            int i;
            ReadOnlyList<Box> list = Framework.ZOrder;
            for (i = list.Count - 1; i >= 0; i--)
            {
                if (list[i] is AmethystElement)
                {
                    AmethystElement elem = (AmethystElement)(list[i]);
                    foreach (Terminal term in elem.Terminals)
                    {
                        if (term is T && (GetRectFromTerminalInDocumentSpace(term)).Contains(docSpace) &&
                            (check == null || check(docSpace, (T)term)))
                        {
                            ret = (T)term;
                            //don't return yet because we have to search through the entire z-order
                            break;
                        }
                    }
                }
            }

            return ret;
        }

        protected InputTerminal GetFrontmostConnectableInputTerminalAtPointInDocumentSpace(Utilities.Vector docSpace)
        {
            return GetFrontmostTerminalAtPointInDocumentSpace<InputTerminal>(docSpace, GetFrontmostConnectableInputTerminalCheck);
        }

        protected bool GetFrontmostConnectableInputTerminalCheck(Utilities.Vector docSpace, InputTerminal terminal)
        {
            return terminal.IsConnectable(_connectionSourceTerminal);
        }

        protected virtual RectangleF GetRectFromTerminalInDocumentSpace(Terminal term)
        {
            RectangleF rect = new RectangleF(term.GetLocationInDocumentSpace(), new SizeV(0, 0));
            rect.Inflate(2 * term.Size, 2 * term.Size);

            switch (term.Side)
            {
                case BoxOrientation.Down:
                    rect.Y -= term.Size;
                    break;
                case BoxOrientation.Left:
                    rect.X += term.Size;
                    break;
                case BoxOrientation.Right:
                    rect.X -= term.Size;
                    break;
                case BoxOrientation.Up:
                    rect.Y += term.Size;
                    break;
                default:
                    break;
            }
            return rect;
        }

        protected override void InternalRoutePath(Path path)
        {
            if (path is AmethystPath && path.From != null && path.To != null)
            {
                AmethystPath apath = (AmethystPath)path;

                int fromQuadrant = GetTerminalQuadrant(apath.FromTerminal);
                int toQuadrant = GetTerminalQuadrant(apath.ToTerminal);
                int routingType = (toQuadrant - fromQuadrant + 4) % 4;

                switch (routingType)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        RoutePathType2(apath); return;
                        //break;
                    case 3:
                        RoutePathType3(apath); return;
                        //break;
                    default:
                        break;
                }

                apath.PathJoints.Clear();
                apath.PathJoints.Add(apath.From.GetOutboundConnectionPoint(apath));
                apath.PathJoints.Add(apath.To.GetInboundConnectionPoint(apath));
                return;
            }
            //else
            {
                base.InternalRoutePath(path);
            }
        }

        private void RoutePathType3(AmethystPath apath)
        {
            //+90 degrees

            Utilities.Vector[] pts = new Utilities.Vector[5];

            Element from = apath.From;
            Element to = apath.To;

            BoxOrientation toSide = apath.ToTerminal.Side;
            int toSideQuadrant = GetTerminalQuadrant(apath.ToTerminal);

            Utilities.Vector inbound = to.GetInboundConnectionPoint(apath);
            Utilities.Vector outbound = from.GetOutboundConnectionPoint(apath);

            float peripherySize = 2 * apath.ArrowSize;
            bool swap = (toSideQuadrant % 2) == 1;

            pts[0] = outbound;
            pts[4] = inbound;


            float toTop = to.Top;
            float toLeft = to.Left;
            float toRight = to.Right;
            float toBottom = to.Bottom;
            float fromTop = from.Top;
            float fromLeft = from.Left;
            float fromRight = from.Right;
            float fromBottom = from.Bottom;
            float toWidth = to.Width;
            float toHeight = to.Height;
            float fromWidth = from.Width;
            float fromHeight = from.Height;

            float[] toMeasure = new float[] { toLeft, toTop, toRight, toBottom };
            float[] toSizeMeasure = new float[] { toWidth, toHeight };

            float[] fromMeasure = new float[] { fromLeft, fromTop, fromRight, fromBottom };
            float[] fromSizeMeasure = new float[] { fromWidth, fromHeight };



            Utilities.Vector offset1 = new Utilities.Vector(apath.ArrowSize, 0);
            Utilities.Vector offset2 = new Utilities.Vector(0, -apath.ArrowSize);

            //switch (toSide)
            //{
            //    case BoxOrientation.Up:
            //        offset1 = new SizeV(apath.ArrowSize, 0);
            //        offset2 = new SizeV(0, -apath.ArrowSize);
            //        break;
            //    case BoxOrientation.Right:
            //        offset1 = new SizeV(0, apath.ArrowSize);
            //        offset2 = new SizeV(apath.ArrowSize, 0);
            //        break;
            //    case BoxOrientation.Down:
            //        offset1 = new SizeV(-apath.ArrowSize, 0);
            //        offset2 = new SizeV(0, apath.ArrowSize);
            //        break;
            //    default:
            //        offset1 = new SizeV(0, -apath.ArrowSize);
            //        offset2 = new SizeV(-apath.ArrowSize, 0);
            //        break;
            //}
            
            pts[1] = pts[0] + offset1;
            pts[3] = pts[4] + offset2;



            float measureForNormalVsUp = pts[3].Y - pts[0].Y;// swap ? pts[3].X - pts[0].X : pts[3].Y - pts[0].Y;
            float measureForNormalVsAside = pts[4].X - pts[1].X;//swap ? pts[4].Y - pts[1].Y : pts[4].X - pts[1].X;
            float measureForUpVsLoop = toLeft - fromRight;//toMeasure[(toSideQuadrant + 0) % 4] - fromMeasure[(toSideQuadrant + 2) % 4];

            float measureForLoopAsideVsUpNormal = pts[4].X - pts[0].X;

            float thresholdForNormalVsUp = 0;
            float thresholdForNormalVsAside = 0;
            float thresholdForUpVsLoop = peripherySize;


            if (measureForNormalVsUp > thresholdForNormalVsUp)
            {
                if (measureForNormalVsAside > thresholdForNormalVsAside)
                {
                    //normal
                    pts[2] = pts[4];
                    pts[1] = new MetaphysicsIndustries.Utilities.Vector(pts[2].X,pts[0].Y);
                    Array.Resize(ref pts, 3);
                }
                else
                {
                    //bend aside
                    float y = (fromBottom + toTop) / 2;
                    pts[3] = new MetaphysicsIndustries.Utilities.Vector(pts[3].X, y);
                    pts[2] = new MetaphysicsIndustries.Utilities.Vector(pts[1].X, y);
                }
            }
            else
            {
                if (measureForUpVsLoop > thresholdForUpVsLoop)
                {
                    //bend up
                    pts[1] = new MetaphysicsIndustries.Utilities.Vector((fromLeft + toRight) / 2, pts[1].Y);
                    pts[2] = new MetaphysicsIndustries.Utilities.Vector(pts[1].X, pts[3].Y);
                }
                else
                {
                    //loop
                    float x = Math.Max(fromRight + apath.ArrowSize, toRight + apath.ArrowSize);
                    float y = Math.Min(fromTop - apath.ArrowSize, toTop - apath.ArrowSize);

                    pts[1] = new Utilities.Vector(x, pts[1].Y);
                    pts[2] = new MetaphysicsIndustries.Utilities.Vector(x, y);
                    pts[3] = new MetaphysicsIndustries.Utilities.Vector(pts[3].X, y);
                }
            }



            apath.PathJoints.Clear();
            apath.PathJoints.AddRange(pts);
        }

        private void RoutePathType2(AmethystPath apath)
        {
            Utilities.Vector[] pts = new Utilities.Vector[6];

            Element from = apath.From;
            Element to = apath.To;

            BoxOrientation toSide = apath.ToTerminal.Side;
            int toSideQuadrant = GetTerminalQuadrant(apath.ToTerminal);

            Utilities.Vector inbound = to.GetInboundConnectionPoint(apath);
            Utilities.Vector outbound = from.GetOutboundConnectionPoint(apath);

            float peripherySize = 2 * apath.ArrowSize;
            bool swap = (toSideQuadrant % 2) == 1;

            pts[0] = outbound;
            pts[5] = inbound;




            Utilities.Vector offset;

            switch (toSide)
            {
                case BoxOrientation.Up:
                    offset = new Utilities.Vector(0, apath.ArrowSize);
                    break;
                case BoxOrientation.Right:
                    offset = new Utilities.Vector(-apath.ArrowSize, 0);
                    break;
                case BoxOrientation.Down:
                    offset = new Utilities.Vector(0, -apath.ArrowSize);
                    break;
                default:
                    offset = new Utilities.Vector(apath.ArrowSize, 0);
                    break;
            }

            pts[1] = pts[0] + offset;
            pts[4] = pts[5] - offset;


            float toTop = to.Top;
            float toLeft = to.Left;
            float toRight = to.Right;
            float toBottom = to.Bottom;
            float fromTop = from.Top;
            float fromLeft = from.Left;
            float fromRight = from.Right;
            float fromBottom = from.Bottom;
            float toWidth = to.Width;
            float toHeight = to.Height;
            float fromWidth = from.Width;
            float fromHeight = from.Height;

            float[] toMeasure = new float[] { toLeft, toTop, toRight, toBottom };
            float[] toSizeMeasure = new float[] { toWidth, toHeight };

            float[] fromMeasure = new float[] { fromLeft, fromTop, fromRight, fromBottom };
            float[] fromSizeMeasure = new float[] { fromWidth, fromHeight };


            float toMeasureForNormal = toMeasure[(toSideQuadrant + 0) % 4];
            float fromMeasureForNormal = fromMeasure[(toSideQuadrant + 2) % 4];

            float toMeasureForBendDown = toMeasure[(toSideQuadrant + 1) % 4];
            float fromMeasureForBendDown = fromMeasure[(toSideQuadrant + 3) % 4];
            float toMeasureForBendCcw = toMeasure[(toSideQuadrant + 3) % 4];
            float fromMeasureForBendCcw = fromMeasure[(toSideQuadrant + 1) % 4];

            float toMeasureForLoop = toMeasure[(toSideQuadrant + 1) % 2];
            float toMeasureForLoopSize = toSizeMeasure[(toSideQuadrant + 1) % 2];
            float fromMeasureForLoop = fromMeasure[(toSideQuadrant + 1) % 2];
            float fromMeasureForLoopSize = fromSizeMeasure[(toSideQuadrant + 1) % 2];

            float toValueForLoopDown = toMeasure[(toSideQuadrant + 3) % 4];
            float fromValueForLoopDown = fromMeasure[(toSideQuadrant + 3) % 4];
            float toValueForLoopUp = toMeasure[(toSideQuadrant + 1) % 4];
            float fromValueForLoopUp = fromMeasure[(toSideQuadrant + 1) % 4];

            float[] normalInvert = new float[] { 1, 1, -1, -1 };
            float[] bendInvert = new float[] { 1, -1, -1, 1 };
            BiModulator[] maxMin = new BiModulator[] { Math.Max, Math.Min, Math.Min, Math.Max };

            float measureForNormal = (toMeasureForNormal - fromMeasureForNormal) * normalInvert[toSideQuadrant];
            float measureForBendCcw = (toMeasureForBendCcw - fromMeasureForBendCcw) * bendInvert[(toSideQuadrant + 2) % 4];
            float measureForBendDown = (toMeasureForBendDown - fromMeasureForBendDown) * bendInvert[toSideQuadrant];
            float measureForLoop = ((toMeasureForLoop + toMeasureForLoopSize) - (fromMeasureForLoop + fromMeasureForLoopSize)) * bendInvert[toSideQuadrant];


            if (measureForNormal > peripherySize)
                //toMeasureForNormal > fromMeasureForNormal + thresholdForNormal)
            {
                //normal
                pts[3] = pts[5];
                if (swap)
                {
                    float y = (pts[0].Y + pts[3].Y) / 2;
                    pts[1] = new MetaphysicsIndustries.Utilities.Vector(pts[1].X, y);
                    pts[2] = new PointF(pts[3].X, y);
                }
                else
                {
                    float x = (pts[0].X + pts[3].X) / 2;
                    pts[1] = new MetaphysicsIndustries.Utilities.Vector(x, pts[1].Y);
                    pts[2] = new PointF(x, pts[3].Y);
                }
                Array.Resize(ref pts, 4);
            }
            else
            {
                float z;

                if (measureForBendCcw > peripherySize ||
                    measureForBendDown > peripherySize)
                    //toMeasureForBendDown > fromMeasureForBendDown + thresholdForBend ||
                    //toMeasureForBendCcw < fromMeasureForBendCcw - thresholdForBend)
                {
                    if (swap)
                    {
                        z = (pts[0].X + pts[5].X) / 2;
                    }
                    else
                    {
                        z = (pts[0].Y + pts[5].Y) / 2;
                    }
                }
                else if (measureForLoop > 0)
                    //toMeasureForLoop + toMeasureForLoopSize / 2 > fromMeasureForLoop + fromMeasureForLoopSize / 2)
                {
                    //loop back down
                    z = (float)(maxMin[toSideQuadrant])(toValueForLoopDown, fromValueForLoopDown) + apath.ArrowSize * bendInvert[toSideQuadrant];
                }
                else
                {
                    //loop back up
                    z = (float)(maxMin[(toSideQuadrant + 2) % 4])(toValueForLoopUp, fromValueForLoopUp) - apath.ArrowSize * bendInvert[toSideQuadrant];
                }

                if (swap)
                {
                    pts[2] = new Utilities.Vector(z, pts[1].Y);
                    pts[3] = new Utilities.Vector(z, pts[4].Y);
                }
                else
                {
                    pts[2] = new Utilities.Vector(pts[1].X, z);
                    pts[3] = new Utilities.Vector(pts[4].X, z);
                }
            }



            apath.PathJoints.Clear();
            apath.PathJoints.AddRange(pts);
        }

        protected int GetTerminalQuadrant(Terminal fromTerminal)
        {
            int sourceQuadrant = 0;

            switch (fromTerminal.Side)
            {
                case BoxOrientation.Left:
                    sourceQuadrant = 0;
                    break;
                case BoxOrientation.Up:
                    sourceQuadrant = 1;
                    break;
                case BoxOrientation.Right:
                    sourceQuadrant = 2;
                    break;
                case BoxOrientation.Down:
                    sourceQuadrant = 3;
                    break;
                //default:
                //    break;
            }
            return sourceQuadrant;
        }

        public override void DisconnectAndRemoveEntity(Entity ent)
        {
            if (ent is AmethystElement)
            {
                AmethystElement elem = (AmethystElement)ent;
                foreach (Terminal terminal in elem.Terminals)
                {
                    _valueCache.Remove(terminal);
                }
            }
            else if (ent is InputTerminal)
            {
                DisconnectInputTerminal(ent as InputTerminal);
            }

            base.DisconnectAndRemoveEntity(ent);
        }

        protected void DisconnectInputTerminal(InputTerminal terminalToDisconnect)
        {
            AmethystPath path = terminalToDisconnect.Path;
            terminalToDisconnect.Path = null;
            DisconnectAndRemoveEntity(path);

            _valueCache.Remove(terminalToDisconnect);
        }

        //public void UpdateTerminalState(Terminal terminal)
        //{
        //    if (terminal is InputTerminal)
        //    {
        //        UpdateInputTerminalState((InputTerminal)terminal);
        //    }
        //    else if (terminal is OutputTerminal)
        //    {
        //        UpdateOutputTerminalState((OutputTerminal)terminal);
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Unknown Terminal type: " +terminal.ToString());
        //    }
        //}

        //protected void UpdateInputTerminalState(InputTerminal inputTerminal)
        //{
        //    TerminalState state = TerminalState.Executed;

        //    if (inputTerminal.Path != null && inputTerminal.Path.FromTerminal == null)
        //    {
        //        RemovePath(inputTerminal.Path);
        //        inputTerminal.Path = null;
        //    }

        //    if (inputTerminal.Path == null)
        //    {
        //        if (inputTerminal.IsRequired)
        //        {
        //            state = TerminalState.Error;
        //        }
        //        else
        //        {
        //            state = TerminalState.DisconnectedOptional;
        //        }
        //    }
        //    else
        //    {
        //        state = inputTerminal.Path.FromTerminal.State;
        //    }

        //    if (inputTerminal.State != state)
        //    {
        //        inputTerminal.State = state;

        //        foreach (OutputConnectionBase con in inputTerminal.Connection.Dependants)
        //        {
        //            OutputTerminal term = (OutputTerminal)inputTerminal.ParentAmethystElement.TerminalsByConnection[con];
        //            UpdateOutputTerminalState(term);
        //        }
        //    }
        //}

        //protected void UpdateOutputTerminalState(OutputTerminal outputTerminal)
        //{
        //    TerminalState state;

        //    if (_valueCache.ContainsKey(outputTerminal))
        //    {
        //        state = TerminalState.Executed;
        //    }
        //    else
        //    {
        //        state = TerminalState.NeedsExecute;
        //    }

        //    foreach (InputConnectionBase con in outputTerminal.Connection.Dependencies)
        //    {
        //        InputTerminal term = (InputTerminal)outputTerminal.ParentAmethystElement.TerminalsByConnection[con];
        //        if (state == TerminalState.Executed && term.State == TerminalState.NeedsExecute)
        //        {
        //            state = TerminalState.NeedsExecute;
        //        }
        //        else if (state == TerminalState.NeedsExecute && term.State == TerminalState.Error)
        //        {
        //            state = TerminalState.Error;
        //            break;
        //        }
        //    }

        //    if (outputTerminal.State != state)
        //    {
        //        outputTerminal.State = state;

        //        foreach (AmethystPath path in outputTerminal.AmethystPaths)
        //        {
        //            UpdateInputTerminalState(path.ToTerminal);
        //        }
        //    }
        //}

        public void MakeConnection(OutputTerminal from, InputTerminal to)
        {
            if (from == null) { throw new ArgumentNullException("from"); }
            if (to == null) { throw new ArgumentNullException("to"); }
            if (from.ParentCrystallineControl != this)
            {
                throw new ArgumentException("The output terminal is not owned by the AmethystControl");
            }
            if (to.ParentCrystallineControl != this)
            {
                throw new ArgumentException("The input terminal is not owned by the AmethystControl");
            }
							
            if (to.Path != null)
            {
                DisconnectInputTerminal(to);
            }

            AmethystPath path = new AmethystPath();

            AddEntity(path);

            path.FromTerminal = from;
            path.ToTerminal = to;

            RoutePath(path);

            _valueCache.Remove(to);

            //UpdateOutputTerminalState(from);
            //UpdateInputTerminalState(to);
        }
    }
}

