using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class CSharpCodeElement : AmethystElement
    {
        public CSharpCodeElement()
            : base(new CSharpCodeNode())
        {
        }

        public override bool ShallProcessDoubleClick
        {
            get { return true; }
        }

        public override void ProcessDoubleClick(AmethystControl control)
        {
            CSharpCodeEditorForm form = new CSharpCodeEditorForm(this);

            if (form.ShowDialog(control) == System.Windows.Forms.DialogResult.OK)
            {
            }
        }

        [Serializable]
        public class CSharpCodeNode : Node
        {
            public CSharpCodeNode()
                : base("C#")
            {
            }

            private string _code;
            public string Code
            {
                get { return _code; }
                set
                {
                    _code = value;
                    ClearCache();
                }
            }

            private void ClearCache()
            {
            }

            protected override void InitConnections()
            {
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                throw new Exception("The method or operation is not implemented.");
            }

        }
    }
}
