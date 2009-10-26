using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Crystalline;
using System.Drawing;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    public abstract class AmethystElement : Element
    {
        public AmethystElement(Node node)
            : this(node, CalcSizeFromNodeConnections(node))
        {
        }

        protected static SizeF CalcSizeFromNodeConnections(Node node)
        {
            return new SizeF(60, 20 + 20 * (int)Math.Max(node.InputConnectionBases.Count, node.OutputConnectionBases.Count));
        }

        public AmethystElement(Node node, SizeF size)
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


            AmethystControl control = (AmethystControl)(Framework.ParentControl);
            if (ShallRenderTerminals)
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

        public override PointF GetInboundConnectionPoint(Path path)
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

        public override PointF GetOutboundConnectionPoint(Path path)
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
            set { _terminalsByConnection = value; }
        }

        public AmethystControl ParentAmethystControl
        {
            get
            {
                if (Framework == null)
                {
                    return null;
                }

                return (AmethystControl)Framework.ParentControl;
            }
        }
    }
}
