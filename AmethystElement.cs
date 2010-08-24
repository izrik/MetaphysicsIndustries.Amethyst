using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Acuity;
using System.Diagnostics;
using MetaphysicsIndustries.Utilities;
using System.Drawing;
using MetaphysicsIndustries.Collections;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public abstract class AmethystElement : Element
    {
        public AmethystElement(Node node)
            : this(node, CalcSizeFromNodeConnections(node))
        {
        }

        protected static SizeV CalcSizeFromNodeConnections(Node node)
        {
            return new SizeV(60, 20 + 20 * (int)Math.Max(node.InputConnectionBases.Count, node.OutputConnectionBases.Count));
        }

        public AmethystElement(Node node, SizeV size)
        {
            if (node == null) { throw new ArgumentNullException("node"); }

            _node = node;

            _terminals = new AmethystElementTerminalParentChildrenCollection(this);

            Size = size;

            InitTerminals();
        }

        protected virtual bool SetInputDisplayNames
        {
            get { return false; }
        }
        protected virtual bool SetOutputDisplayNames
        {
            get { return false; }
        }

        protected virtual void InitTerminals()
        {
            float y = Math.Min(Height / 2 - 10 * (Node.InputConnectionBases.Count - 1), Height / 2);
            foreach (InputConnectionBase icb in Node.InputConnectionBases)
            {
                InputTerminal term = new InputTerminal(icb);
                term.Side = BoxOrientation.Left;
                term.Position = y;
                if (SetInputDisplayNames)
                {
                    term.DisplayText = icb.Name;
                }
                y += 20;
                Terminals.Add(term);
            }

            y = Math.Min(Height / 2 - 10 * (Node.OutputConnectionBases.Count - 1), Height / 2);
            foreach (OutputConnectionBase ocb in Node.OutputConnectionBases)
            {
                OutputTerminal term = new OutputTerminal(ocb);
                term.Side = BoxOrientation.Right;
                term.Position = y;
                if (SetOutputDisplayNames)
                {
                    term.DisplayText = ocb.Name;
                }
                y += 20;
                Terminals.Add(term);
            }
        }

        private Node _node;
        public Node Node
        {
            get { return _node; }
        }

        public override void Render(Graphics g, Pen pen, Brush brush, Font font)
        {
            RenderShape(g, pen, SystemBrushes.Window, Rect);

            RenderPreTransform(g, pen, brush, font);

            System.Drawing.Drawing2D.Matrix transform = g.Transform;
            g.TranslateTransform(X , Y );


            AmethystControl control = ParentAmethystControl;
            Debug.Assert(control != null);

            if (control != null && ShallRenderTerminals)
            {
                RenderTerminals(g, pen, brush, font, control);
            }

            g.Transform = transform;

            RenderText(g, pen, brush, font);

            //base.Render(g, pen, brush, font);
        }

        public virtual bool ShallRenderTerminals
        {
            get { return true; }
        }

        private void RenderTerminals(Graphics g, Pen pen, Brush brush, Font font, AmethystControl control)
        {
            foreach (Terminal terminal in Terminals)
            {
                terminal.Render(g,
                    control.ChoosePenForTerminal(terminal, pen),
                    control.ChooseBrushForTerminal(terminal, brush),
                    font);
            }
        }

        protected virtual void RenderPreTransform(Graphics g, Pen pen, Brush brush, Font font)
        {
        }

        protected override void RenderText(Graphics g, Pen pen, Brush brush, Font font)
        {
            StringFormat fmt = StringFormat.GenericDefault;
            fmt.Alignment = StringAlignment.Center;
            fmt.LineAlignment = StringAlignment.Center;
            g.DrawString(Text, font, brush, Rect, fmt);
        }

        public override string Text
        {
            get
            {
                return Node.Name;
            }
        }

        private AmethystElementTerminalParentChildrenCollection _terminals;
        public AmethystElementTerminalParentChildrenCollection Terminals
        {
            get { return _terminals; }
        }

        //public virtual bool ShallProcessDoubleClick
        //{
        //    get { return false; }
        //}

        public virtual void ProcessDoubleClick(AmethystControl control)
        {
        }

        public sealed override void ProcessDoubleClick(CrystallineControl control)
        {
            ProcessDoubleClick((AmethystControl)control);
        }

        public override Utilities.Vector GetInboundConnectionPoint(Path path)
        {
            if (path is AmethystPath)
            {
                AmethystPath apath = (AmethystPath)path;

                if (apath.ToTerminal != null)
                {
                    return apath.ToTerminal.GetLocationInDocumentSpace();
                }
            }

            return base.GetInboundConnectionPoint(path);
        }

        public override Utilities.Vector GetOutboundConnectionPoint(Path path)
        {
            if (path is AmethystPath)
            {
                AmethystPath apath = (AmethystPath)path;

                if (apath.FromTerminal != null)
                {
                    return apath.FromTerminal.GetLocationInDocumentSpace();
                }
            }

            return base.GetInboundConnectionPoint(path);
        }



        public void Execute(Dictionary<InputConnectionBase,object> inputs, Dictionary<OutputConnectionBase,object> outputs)
        {
            //foreach (Terminal terminal in Terminals)
            //{
            //    if (terminal is InputTerminal)
            //    {
            //        InputTerminal terminal2 = (InputTerminal)terminal;
            //        terminal2.InputValue = terminal2.Path.FromTerminal.Result;

            //        inputs[terminal2.Connection] = terminal2.InputValue;
            //    }
            //}

            Node.Execute(inputs, outputs);

            //foreach (Terminal terminal in Terminals)
            //{
            //    if (terminal is OutputTerminal)
            //    {
            //        OutputTerminal terminal2 = (OutputTerminal)terminal;

            //        terminal2.Result = outputs[terminal2.Connection];
            //    }
            //}
        }

        private Dictionary<Connection, Terminal> _terminalsByConnection = new Dictionary<Connection,Terminal>();
        public Dictionary<Connection, Terminal> TerminalsByConnection
        {
            get { return _terminalsByConnection; }
            //set { _terminalsByConnection = value; }
        }

        public AmethystControl ParentAmethystControl
        {
            get
            {
                return (ParentCrystallineControl as AmethystControl);
            }
        }

        protected override void SetParentCrystallineControl(CrystallineControl value)
        {
            if (value == null || value is AmethystControl)
            {
                base.SetParentCrystallineControl(value);
            }
        }

        public override void Disconnect(out Entity[] entitiesToRemove)
        {
            List<Entity> list = new List<Entity>();
            Entity[] array;

            list.AddRange(Terminals.ToArray());

            base.Disconnect(out array);

            if (array != null)
            {
                list.AddRange(array);
            }

            entitiesToRemove = list.ToArray();
        }

        public void SwapTerminal(Terminal currentTerminal, Terminal newTerminal)
        {
            if (currentTerminal == null) throw new ArgumentNullException("currentTerminal");
            if (newTerminal == null) throw new ArgumentNullException("newTerminal");

            if (currentTerminal == newTerminal) return;

            if (!((currentTerminal is InputTerminal && newTerminal is InputTerminal) ||
                 (currentTerminal is OutputTerminal && newTerminal is OutputTerminal)))
            {
                throw new InvalidOperationException("The terminals must be both input or both output");
            }

            this.Terminals.Add(newTerminal);

            if (currentTerminal is InputTerminal)
            {
                InputTerminal icur = (InputTerminal)currentTerminal;
                InputTerminal inew = (InputTerminal)newTerminal;

                AmethystPath path = icur.Path;

                if (path != null)
                {
                    if (inew.IsConnectable(path.FromTerminal))
                    {
                        path.ToTerminal = inew;
                    }
                    else
                    {
                        icur.Path = null;
                    }
                }
            }
            else if (currentTerminal is OutputTerminal)
            {
                OutputTerminal ocur = (OutputTerminal)currentTerminal;
                OutputTerminal onew = (OutputTerminal)newTerminal;

                AmethystPath[] paths = ocur.AmethystPaths.ToArray();

                if (paths != null && paths.Length > 0)
                {
                    foreach (AmethystPath path in paths)
                    {
                        if (path.ToTerminal.IsConnectable(onew))
                        {
                            path.FromTerminal = onew;
                        }
                        else
                        {
                            path.FromTerminal = null;
                        }
                    }
                }
            }

            this.Terminals.Remove(currentTerminal);
        }
    }

    public class MappedElement : AmethystElement
    {
        public MappedElement(Node node)
            : base(node)
        {
        }

        public static MappedElement[] MapNodes(Node[] nodes)
        {
            AmethystPath[] paths;
            return MapNodes(nodes, out paths);
        }
        public static MappedElement[] MapNodes(Node[] nodes, out AmethystPath[] paths)
        {
            List<MappedElement> elements = new List<MappedElement>();

            Dictionary<InputConnectionBase, InputTerminal> inputs = new Dictionary<InputConnectionBase, InputTerminal>();
            Dictionary<OutputConnectionBase, OutputTerminal> outputs = new Dictionary<OutputConnectionBase, OutputTerminal>();

            foreach (Node node in nodes)
            {
                MappedElement elem  = new MappedElement(node);
                elements.Add(elem);
                foreach (InputTerminal term in Collection.Extract<Terminal, InputTerminal>(elem.Terminals))
                {
                    inputs[term.Connection] = term;
                }
                foreach (OutputTerminal term in Collection.Extract<Terminal, OutputTerminal>(elem.Terminals))
                {
                    outputs[term.Connection] = term;
                }
            }

            List<AmethystPath> paths2 = new List<AmethystPath>();
            foreach (MappedElement elem in elements)
            {
                foreach (InputTerminal term in Collection.Extract<Terminal, InputTerminal>(elem.Terminals))
                {
                    if (term.Connection.InboundConnection != null && outputs.ContainsKey(term.Connection.InboundConnection))
                    {
                        ConnectTerminals(outputs[term.Connection.InboundConnection], term);
                        paths2.Add(term.Path);
                    }
                }
            }

            paths = paths2.ToArray();
            return elements.ToArray();
        }

        private static void ConnectTerminals(OutputTerminal from, InputTerminal to)
        {
            AmethystPath path = new AmethystPath();
            path.FromTerminal = from; 
            path.ToTerminal = to;
        }

        protected override void InitTerminals()
        {
            List<InputTerminal> primaryInputs = new List<InputTerminal>();
            List<InputTerminal> secondaryInputs = new List<InputTerminal>();
            List<OutputTerminal> primaryOutputs = new List<OutputTerminal>();
            List<OutputTerminal> secondaryOutputs = new List<OutputTerminal>();

            foreach (InputConnectionBase conn in Node.InputConnectionBases)
            {
                InputTerminal term = new InputTerminal(conn);
                //if (conn.IsSecondary)
                //{
                //    term.Side = BoxOrientation.Up;
                //    secondaryInputs.Add(term);
                //}
                //else
                //{
                    term.Side = BoxOrientation.Left;
                    primaryInputs.Add(term);
                //}
            }
            foreach (OutputConnectionBase conn in Node.OutputConnectionBases)
            {
                OutputTerminal term = new OutputTerminal(conn);
                //if (conn.IsSecondary)
                //{
                //    term.Side = BoxOrientation.Down;
                //    secondaryOutputs.Add(term);
                //}
                //else
                //{
                    term.Side = BoxOrientation.Right;
                    primaryOutputs.Add(term);
                //}
            }

            int primaryMax = Math.Max(primaryInputs.Count, primaryOutputs.Count);
            int secondaryMax = Math.Max(secondaryInputs.Count, secondaryOutputs.Count);
            float height = 20 * (primaryMax+ 1);
            float width = 20 * (secondaryMax+ 1);

            int i;
            for (i = 0; i < primaryInputs.Count; i++)
            {
                primaryInputs[i].Position = 20 * (primaryMax - primaryInputs.Count + 1 + i) / 2;
            }
            for (i = 0; i < primaryOutputs.Count; i++)
            {
                primaryOutputs[i].Position = 20 * (primaryMax - primaryOutputs.Count + 1 + i) / 2;
            }
            for (i = 0; i < secondaryInputs.Count; i++)
            {
                secondaryInputs[i].Position = 20 * (i + 1);
            }
            for (i = 0; i < secondaryOutputs.Count; i++)
            {
                secondaryOutputs[i].Position = width - 20 * (i + 1);
            }
        }
    }
}
