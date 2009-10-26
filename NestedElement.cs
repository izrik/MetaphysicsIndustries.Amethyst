using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;
using System.Windows.Forms;
using System.Drawing;
using MetaphysicsIndustries.Collections;
using MetaphysicsIndustries.Crystalline;

namespace MetaphysicsIndustries.Amethyst
{
    public class NestedElement : AmethystElement
    {
        public NestedElement()
            : base(new NestedNode(), new SizeF(60, 60))
        {
            Text = Node.Name;
        }

        public class NestedNode : Node
        {
            public NestedNode()
                : base("Nested Node")
            {
            }

            protected override void InitConnections()
            {
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                ExecutionEngine exe = new ExecutionEngine();
                //exe.Execute( ... )

                
            }
        }

        private string _text = string.Empty;
        public override string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public override bool ShallProcessDoubleClick
        {
            get { return true; }
        }

        public override void ProcessDoubleClick(AmethystControl control)
        {
            NestedElementEditorForm form = new NestedElementEditorForm(this);

            if (form.ShowDialog(control) == DialogResult.OK)
            {
            }

            control.InvalidateRectFromElement(this);
        }

        private Set<Element> _elements = new Set<Element>();
        public Set<Element> Elements
        {
            get { return _elements; }
        }

        private Set<Path> _paths = new Set<Path>();
        public Set<Path> Paths
        {
            get { return _paths; }
        }

    }
}
