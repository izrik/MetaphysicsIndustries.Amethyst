using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class ConstructorInvokeElement : AmethystElement
    {
        public ConstructorInvokeElement()
            : base(new ConstructorInvokeNode(), new SizeF(80, 80))
        {
        }

        public new ConstructorInvokeNode Node
        {
            get { return (ConstructorInvokeNode)base.Node; }
        }

        [Serializable]
        public class ConstructorInvokeNode : Node
        {
            public ConstructorInvokeNode()
                : base("Constructor Invoke")
            {
            }

            protected override void InitConnections()
            {
            }

            private ConstructorInfo _constructor;
            public ConstructorInfo Constructor
            {
                get { return _constructor; }
                set
                {
                    if (_constructor != value)
                    {
                        _constructor = value;

                        UpdateConnections();
                    }
                }
            }

            protected void UpdateConnections()
            {
                ClearConnections();

                if (Constructor == null) { return; }

                Type icType = typeof(InputConnection<>);

                //if (!Constructor.IsStatic)
                //{
                //    AddInputConnection("this", Constructor.DeclaringType);
                //}

                ParameterInfo[] param = Constructor.GetParameters();
                int i = 0;
                foreach (ParameterInfo pi in param)
                {
                    string name = pi.Name;
                    if (string.IsNullOrEmpty(name))
                    {
                        name = "param_" + i.ToString();
                    }
                    InputConnectionBase conn = AddInputConnection(name, pi.ParameterType);
                    ParametersByInputConnection[conn] = pi;
                }

                UpdateOutputConnection();


                InitDependencies();
            }

            private void ClearConnections()
            {
                foreach (InputConnectionBase conn in InputConnectionBases)
                {
                    conn.InboundConnection = null;
                    conn.Dependants.Clear();
                }
                foreach (OutputConnectionBase conn in OutputConnectionBases)
                {
                    conn.OutboundConnections.Clear();
                    conn.Dependencies.Clear();
                }

                InputConnectionBases.Clear();
                OutputConnectionBases.Clear();
                InputConnectionsByName.Clear();
                //OutputConnectionsByName.Clear();
                ParametersByInputConnection.Clear();
                Output = null;
            }

            private OutputConnectionBase UpdateOutputConnection()
            {
                Type icType = typeof(OutputConnection<>);
                Type type = icType.MakeGenericType(Constructor.DeclaringType);
                OutputConnectionBase conn = (OutputConnectionBase)type.Assembly.CreateInstance(type.FullName, false, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static, null, new object[] { "Output" }, null, null);
                OutputConnectionBases.Add(conn);
                Output = conn;
                //OutputConnectionsByName[name] = conn;
                return conn;
            }

            private InputConnectionBase AddInputConnection(string name, Type connectionType)
            {
                Type icType = typeof(InputConnection<>);
                Type type = icType.MakeGenericType(connectionType);
                InputConnectionBase conn = (InputConnectionBase)type.Assembly.CreateInstance(type.FullName, false, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static, null, new object[] { name }, null, null);
                InputConnectionBases.Add(conn);
                InputConnectionsByName[name] = conn;
                return conn;
            }

            private Dictionary<string, InputConnectionBase> _inputConnectionsByName = new Dictionary<string, InputConnectionBase>();
            public Dictionary<string, InputConnectionBase> InputConnectionsByName
            {
                get { return _inputConnectionsByName; }
            }
            //private Dictionary<string, OutputConnectionBase> _outputConnectionsByName = new Dictionary<string, OutputConnectionBase>();
            //public Dictionary<string, OutputConnectionBase> OutputConnectionsByName
            //{
            //    get { return _outputConnectionsByName; }
            //}
            private Dictionary<InputConnectionBase, ParameterInfo> _parametersByInputConnection = new Dictionary<InputConnectionBase, ParameterInfo>();
            public Dictionary<InputConnectionBase, ParameterInfo> ParametersByInputConnection
            {
                get { return _parametersByInputConnection; }
            }

            private OutputConnectionBase _output;
            public OutputConnectionBase Output
            {
                get { return _output; }
                protected set
                {
                    if (_output != value)
                    {
                        _output = value;
                    }
                }
            }



            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                List<InputConnectionBase> inputConnectionsInOrder = new List<InputConnectionBase>();
                List<object> inputValuesInOrder = new List<object>();

                inputConnectionsInOrder.AddRange(ParametersByInputConnection.Keys);
                foreach (InputConnectionBase conn in InputConnectionBases)
                {
                    if (ParametersByInputConnection.ContainsKey(conn))
                    {
                        ParameterInfo pi = ParametersByInputConnection[conn];
                        inputConnectionsInOrder[pi.Position] = conn;
                    }
                }

                foreach (InputConnectionBase conn in inputConnectionsInOrder)
                {
                    inputValuesInOrder.Add(inputs[conn]);
                }

                object returnValue = Constructor.Invoke(inputValuesInOrder.ToArray());

                outputs[Output] = returnValue;
            }
        }

        public override string Text
        {
            get { return base.Text; }
        }

        public override bool ShallProcessDoubleClick
        {
            get { return true; }
        }

        public override void ProcessDoubleClick(AmethystControl control)
        {
            ConstructorInvokeForm form = new ConstructorInvokeForm(Node.Constructor);
            if (form.ShowDialog(control) == DialogResult.OK)
            {
                Node.Constructor = form.Constructor;

                UpdateTerminals();
            }
        }

        private void UpdateTerminals()
        {
            ClearTerminals();

            int y = 20;
            foreach (InputConnectionBase conn in Node.InputConnectionBases)
            {
                InputTerminal term = new InputTerminal(conn);
                term.Position = y;
                term.Side = BoxOrientation.Left;
                term.DisplayText = conn.Name;
                Terminals.Add(term);
                y += 20;
            }

            //if (Node.InputConnectionsByName.ContainsKey("this"))
            //{
            //    TerminalsByConnection[Node.InputConnectionsByName["this"]].Size *= 2;
            //}

            y = 30;
            foreach (OutputConnectionBase conn in Node.OutputConnectionBases)
            {
                OutputTerminal term = new OutputTerminal(conn);
                term.Position = y;
                term.Side = BoxOrientation.Right;
                term.DisplayText = conn.Name;
                Terminals.Add(term);
                y += 20;
            }

            Size = new SizeF(Width, Math.Max((Node.InputConnectionBases.Count + 1) * 20, (Node.OutputConnectionBases.Count + 1) * 20 + 10));
        }

        private void ClearTerminals()
        {
            foreach (Terminal term in Terminals)
            {
                if (term is InputTerminal)
                {
                    InputTerminal term2 = (InputTerminal)term;
                    AmethystPath path = term2.Path;
                    if (path != null)
                    {
                        term2.Path = null;
                        ParentAmethystControl.RemoveEntity(path);
                    }
                }
                else if (term is OutputTerminal)
                {
                    OutputTerminal term2 = (OutputTerminal)term;
                    AmethystPath[] paths = new AmethystPath[term2.AmethystPaths.Count];
                    term2.AmethystPaths.CopyTo(paths, 0);
                    foreach (AmethystPath path in paths)
                    {
                        ParentAmethystControl.RemoveEntity(path);
                    }
                    term2.AmethystPaths.Clear();
                }
            }

            Terminals.Clear();
        }
    }
}
