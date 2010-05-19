using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Build;

namespace MetaphysicsIndustries.Amethyst
{
    public partial class NestedElementEditorForm : Form
    {
        public NestedElementEditorForm(NestedElement target)
        {
            _target = target;

            InitializeComponent();
        }

        NestedElement _target;

        private void NestedElementEditorForm_Load(object sender, EventArgs e)
        {
            _nameTextBox.Text = _target.Text;

            AddTeminalMenuItems();

            amethystControl1.Entities.Clear();

            amethystControl1.Entities.AddRange(_target.Entities);

            amethystControl1.RouteAllPaths();
        }

        private void AddTeminalMenuItems()
        {
            ToolStripMenuItem item = new ToolStripMenuItem("Input Terminal");
            item.Click += new EventHandler(AddInputTerminal_Click);
            amethystControl1.AddMenuItem(item, amethystControl1.AddItem);
        }

        void AddInputTerminal_Click(object sender, EventArgs e)
        {
            TypeSelectionForm form = new TypeSelectionForm();
            form.Result = SystemValueType.GetSystemValueType(typeof(int));
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (!(form.Result is ISystemType))
                {
                    throw new InvalidOperationException();
                }

                System.Type conType = ((ISystemType)form.Result).InternalType;
                InputConnectionBase con = InputConnectionBase.ConstructInputConnection(conType, string.Empty);
                _target.Node.InputConnectionBases.Add(con);

                InputTerminal term = new InputTerminal(con);
                term.Side = BoxOrientation.Left;
                float maxPos = 0;
                foreach (Terminal term2 in _target.Terminals)
                {
                    if (term2 is InputTerminal &&
                        term2.Side == BoxOrientation.Left &&
                        term2.Position > maxPos)
                    {
                        maxPos = term2.Position;
                    }
                }
                term.Position = maxPos + 20;
                if (_target.Height < maxPos + 40)
                {
                    _target.Height = maxPos + 40;
                }
                _target.Terminals.Add(term);

                InputTerminalElement elem = new InputTerminalElement(term);
                elem.Location = amethystControl1.LastRightClickInDocument;
                amethystControl1.AddEntity(elem);
            }
        }

        private void _closeButton_Click(object sender, EventArgs e)
        {
            _target.Text = _nameTextBox.Text;

            _target.Entities.Clear();
            _target.Entities.AddRange(amethystControl1.Entities);

            amethystControl1.Entities.Clear();
        }
    }
}