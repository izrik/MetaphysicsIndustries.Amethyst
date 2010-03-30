using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Diagnostics;
//using MetaphysicsIndustries.Giza;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class CSharpCompilerElement : AmethystElement
    {
        public CSharpCompilerElement()
            : base(new CSharpCompilerNode())
        {
        }



        public new CSharpCompilerNode Node
        {
            get { return (CSharpCompilerNode)base.Node; }
        }

        [Serializable]
        public class CSharpCompilerNode : Node
        {
            public CSharpCompilerNode()
                : base("C# Compiler")
            {
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(Input);
                OutputConnectionBases.Add(Output);
            }

            private InputConnection<string> _input = new InputConnection<string>("Input");
            public InputConnection<string> Input
            {
                get { return _input; }
            }
            private OutputConnection<Assembly> _output = new OutputConnection<Assembly>("Output");
            public OutputConnection<Assembly> Output
            {
                get { return _output; }
            }

            MetaphysicsIndustries.Giza.CSharpCompiler _compiler = new MetaphysicsIndustries.Giza.CSharpCompiler();

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                string source = (string)inputs[Input];

                outputs[Output] = _compiler.CompileAssemblyFromSource(source);
            }
        }
    }
}
