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

            amethystControl1.Elements.Clear();
            amethystControl1.Paths.Clear();
            amethystControl1.Entities.Clear();

            amethystControl1.Elements.AddRange(_target.Elements);
            amethystControl1.Paths.AddRange(_target.Paths);

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

            _target.Elements.Clear();
            _target.Elements.AddRange(amethystControl1.Elements);

            _target.Paths.Clear();
            _target.Paths.AddRange(amethystControl1.Paths);

            //this feels soooo kludgy
            Dictionary<Path, Element> froms = new Dictionary<Path, Element>();
            Dictionary<Path, Element> tos = new Dictionary<Path, Element>();
            foreach (Path p in _target.Paths)
            {
                froms[p] = p.From;
                tos[p] = p.To;
            }

            amethystControl1.Elements.Clear();
            amethystControl1.Paths.Clear();
            amethystControl1.Entities.Clear();

            //kludge, part 2
            foreach (Path p in _target.Paths)
            {
                p.From = froms[p];
                p.To = tos[p];
            }
        }
    }
}