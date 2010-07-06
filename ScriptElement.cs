using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Giza;
using MetaphysicsIndustries.Build;
using MetaphysicsIndustries.Collections;
using System.Reflection;

namespace MetaphysicsIndustries.Amethyst
{
    public class ScriptElement : AmethystElement
    {
        public ScriptElement()
            : base(new ScriptNode())
        {
        }

        public class ScriptNode : MetaphysicsIndustries.Epiphany.Node
        {
            public ScriptNode()
                : base("Script")
            {
                Usings.AddRange(CSharpCompiler.DefaultUsings);
            }

            protected override void InitConnections()
            {
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                CSharpCompiler compiler = new CSharpCompiler();

                InputConnectionBase[] inputConnections = Collection.ToArray(this.InputConnectionBases);
                OutputConnectionBase[] outputConnections = Collection.ToArray(this.OutputConnectionBases);

                Parameter[] parameters = ParametersFromConnections(inputConnections, outputConnections);

                MethodInfo method = compiler.CompileMethodBody(ScriptSource, parameters, this.Usings.ToArray());

                List<object> args = new List<object>();
                foreach (InputConnectionBase input in inputConnections)
                {
                    args.Add(inputs[input]);
                }
                foreach (OutputConnectionBase output in outputConnections)
                {
                    args.Add(outputs[output]);
                }
                object[] args2 = args.ToArray();
                method.Invoke(null, args2);
                int i;
                for (i = 0; i < outputConnections.Length; i++)
                {
                    outputs[outputConnections[i]] = args2[i + inputConnections.Length];
                }
            }

            private Parameter[] ParametersFromConnections(InputConnectionBase[] inputs, OutputConnectionBase[] outputs)
            {
                List<Parameter> parameters = new List<Parameter>();
                foreach (InputConnectionBase input in inputs)
                {
                    parameters.Add(new Parameter(SystemType.GetSystemType(input.TypeForConnection), input.Name, false, false));
                }
                foreach (OutputConnectionBase output in outputs)
                {
                    parameters.Add(new Parameter(SystemType.GetSystemType(output.TypeForConnection), output.Name, true, false));
                }
                return parameters.ToArray();
            }

            private string _scriptSource;
            public string ScriptSource
            {
                get { return _scriptSource; }
                set { _scriptSource = value; }
            }

            private List<string> _usings = new List<string>();
            public List<string> Usings
            {
                get { return _usings; }
            }

            public void SetName(string value)
            {
                Name = value;
            }
        }

        public override bool ShallProcessDoubleClick
        {
            get { return true; }
        }
        public override void ProcessDoubleClick(AmethystControl control)
        {
            ScriptNode node = (ScriptNode)Node;
            ScriptElementEditorForm form =
                new ScriptElementEditorForm(
                    node.Name,
                    Collection.ToArray(Node.InputConnectionBases),
                    Collection.ToArray(Node.OutputConnectionBases),
                    node.Usings.ToArray(),
                    node.ScriptSource);
            if (form.ShowDialog(control) == System.Windows.Forms.DialogResult.OK)
            {
                bool clear = false;

                node.SetName(form.ElementName);
                if (node.ScriptSource != form.ElementSource)
                {
                    clear = true;
                    node.ScriptSource = form.ElementSource;
                }

                UpdateInputTerminals(node, form.ElementInputs, ref clear);
                UpdateOutputTerminals(node, form.ElementOutputs, ref clear);
                UpdateUsings(node, form.ElementUsings, ref clear);

                this.Size = CalcSizeFromNodeConnections(node);

                if (clear)
                {
                    foreach (Terminal term in Terminals)
                    {
                        ParentAmethystControl.RemoveFromValueCache(term);
                    }
                }
            }
        }

        private void UpdateInputTerminals(ScriptNode node, InputConnectionBase[] formInputs, ref bool clear)
        {
            List<InputConnectionBase> toRemove = new List<InputConnectionBase>();
            float y = 20;
            foreach (InputConnectionBase input in node.InputConnectionBases)
            {
                bool done = false;
                foreach (InputConnectionBase input2 in formInputs)
                {
                    if (input == input2)
                    {
                        TerminalsByConnection[input].Side = Crystalline.BoxOrientation.Left;
                        TerminalsByConnection[input].Position = y;

                        y += 20;
                        done = true;
                    }
                    else if (input.Name == input2.Name && input.TypeForConnection == input2.TypeForConnection)
                    {
                        InputTerminal term = new InputTerminal(input2);
                        term.Side = Crystalline.BoxOrientation.Left;
                        term.Position = y;
                        this.SwapTerminal(TerminalsByConnection[input], term);

                        clear = true;

                        y += 20;
                        done = true;
                    }

                    if (done)
                    {
                        break;
                    }
                }

                if (!done)
                {
                    toRemove.Add(input);
                }
            }
            foreach (InputConnectionBase input in toRemove)
            {
                this.Terminals.Remove(TerminalsByConnection[input]);
            }
            foreach (InputConnectionBase input in formInputs)
            {
                bool done = false;
                foreach (InputConnectionBase input2 in node.InputConnectionBases)
                {
                    if (input == input2)
                    {
                        done = true;
                        break;
                    }
                }

                if (!done)
                {
                    node.InputConnectionBases.Add(input);
                    InputTerminal term = new InputTerminal(input);
                    term.Side = Crystalline.BoxOrientation.Left;
                    term.Position = y;
                    this.Terminals.Add(term);

                    y += 20;
                }
            }
        }

        private void UpdateOutputTerminals(ScriptNode node, OutputConnectionBase[] formOutputs, ref bool clear)
        {
            List<OutputConnectionBase> toRemove = new List<OutputConnectionBase>();
            float y = 20;
            foreach (OutputConnectionBase output in node.OutputConnectionBases)
            {
                bool done = false;
                foreach (OutputConnectionBase output2 in formOutputs)
                {
                    if (output == output2)
                    {
                        TerminalsByConnection[output].Side = Crystalline.BoxOrientation.Right;
                        TerminalsByConnection[output].Position = y;

                        y += 20;
                        done = true;
                    }
                    else if (output.Name == output2.Name && output.TypeForConnection == output2.TypeForConnection)
                    {
                        OutputTerminal term = new OutputTerminal(output2);
                        term.Side = Crystalline.BoxOrientation.Left;
                        term.Position = y;
                        this.SwapTerminal(TerminalsByConnection[output], term);

                        clear = true;
                        y += 20;
                        done = true;
                    }

                    if (done)
                    {
                        break;
                    }
                }

                if (!done)
                {
                    toRemove.Add(output);
                }
            }
            foreach (OutputConnectionBase input in toRemove)
            {
                this.Terminals.Remove(TerminalsByConnection[input]);
            }
            foreach (OutputConnectionBase output in formOutputs)
            {
                bool done = false;
                foreach (OutputConnectionBase output2 in node.OutputConnectionBases)
                {
                    if (output == output2)
                    {
                        done = true;
                        break;
                    }
                }

                if (!done)
                {
                    node.OutputConnectionBases.Add(output);
                    OutputTerminal term = new OutputTerminal(output);
                    term.Side = Crystalline.BoxOrientation.Right;
                    term.Position = y;
                    this.Terminals.Add(term);

                    y += 20;
                }
            }
        }

        private void UpdateUsings(ScriptNode node, string[] formUsings, ref bool clear)
        {
            string[] usings = node.Usings.ToArray();
            string[] inter = Set<string>.Intersection(formUsings, usings);
            if (node.Usings.Count != formUsings.Length ||
                usings.Length != inter.Length ||
                formUsings.Length != inter.Length)
            {
                clear = true;
                node.Usings.Clear();
                node.Usings.AddRange(formUsings);
            }
        }
    }
}
