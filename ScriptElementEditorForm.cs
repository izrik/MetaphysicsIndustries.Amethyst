using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Build;

namespace MetaphysicsIndustries.Amethyst
{
    public partial class ScriptElementEditorForm : Form
    {
        public ScriptElementEditorForm(
            string name,
            InputConnectionBase[] inputs,
            OutputConnectionBase[] outputs,
            string[]usings,
            string source)
        {
            InitializeComponent();

            ElementName = name;
            ElementInputs = inputs;
            ElementOutputs = outputs;
            ElementUsings = usings;
            ElementSource = source;
        }

        string _elementName;
        public string ElementName
        {
            get { return _elementName; }
            set
            {
                _elementName = value;
                _nametextBox2.Text = value;
            }
        }
        InputConnectionBase[] _elementInputs;
        public InputConnectionBase[] ElementInputs
        {
            get { return _elementInputs; }
            set
            {
                _elementInputs = value;
                _elementInputsTemp.Clear();
                _elementInputsTemp.AddRange(value);
                UpdateConnectionsListBox();
            }
        }
        OutputConnectionBase[] _elementOutputs;
        public OutputConnectionBase[] ElementOutputs
        {
            get { return _elementOutputs; }
            set
            {
                _elementOutputs = value;
                _elementOutputsTemp.Clear();
                _elementOutputsTemp.AddRange(value);
                UpdateConnectionsListBox();
            }
        }
        string[] _elementUsings;
        public string[] ElementUsings
        {
            get { return _elementUsings; }
            set
            {
                _elementUsings = value;
                _elementUsingsTemp.Clear();
                _elementUsingsTemp.AddRange(value);
                UpdateConnectionsListBox();
            }
        }
        string _elementSource;
        public string ElementSource
        {
            get { return _elementSource; }
            set
            {
                _elementSource = value;
                _sourcetextBox1.Text = value;
            }
        }

        List<InputConnectionBase> _elementInputsTemp = new List<InputConnectionBase>();
        List<OutputConnectionBase> _elementOutputsTemp = new List<OutputConnectionBase>();
        List<string> _elementUsingsTemp = new List<string>();

        private void _connectionslistBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_connectionslistBox1.SelectedIndex >= 0)
            {
                _deleteConnectionbutton3.Enabled = true;
            }
            else
            {
                _deleteConnectionbutton3.Enabled = false;
            }
        }

        CSharpRenderer _renderer = new CSharpRenderer();
        CSharpRenderContext _context = new CSharpRenderContext();

        private void UpdateConnectionsListBox()
        {
            _connectionslistBox1.Items.Clear();
            foreach (InputConnectionBase input in _elementInputsTemp)
            {
                _connectionslistBox1.Items.Add(
                    string.Format(
                        "input - {0} - {1}",
                        input.Name,
                        _renderer.RenderTypeReference(SystemType.GetSystemType(input.TypeForConnection), _context)));
            }
            foreach (OutputConnectionBase output in _elementOutputsTemp)
            {
                _connectionslistBox1.Items.Add(
                    string.Format(
                        "output - {0} - {1}",
                        output.Name,
                        _renderer.RenderTypeReference(SystemType.GetSystemType(output.TypeForConnection), _context)));
            }
            foreach (string us in _elementUsingsTemp)
            {
                _connectionslistBox1.Items.Add(string.Format("using {0};", us));
            }
        }

        private void _addInputbutton1_Click(object sender, EventArgs e)
        {
            ScriptElementConnectionEditorForm form = new ScriptElementConnectionEditorForm();
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                InputConnectionBase conn = InputConnectionBase.ConstructInputConnection(form.ConnectionType, form.ConnectionName);
                _elementInputsTemp.Add(conn);
                UpdateConnectionsListBox();
            }
        }

        private void _addOutputbutton2_Click(object sender, EventArgs e)
        {
            ScriptElementConnectionEditorForm form = new ScriptElementConnectionEditorForm();
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                OutputConnectionBase conn = OutputConnectionBase.ConstructOutputConnection(form.ConnectionType, form.ConnectionName);
                _elementOutputsTemp.Add(conn);
                UpdateConnectionsListBox();
            }
        }

        private void _addUsingbutton1_Click(object sender, EventArgs e)
        {
            StringEditorForm form = new StringEditorForm();
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                _elementUsingsTemp.Add(form.Value);
                UpdateConnectionsListBox();
            }
        }

        private void _deleteConnectionbutton3_Click(object sender, EventArgs e)
        {
            int i = _connectionslistBox1.SelectedIndex;
            if (i < 0) return;

            if (i < _elementInputsTemp.Count)
            {
                _elementInputsTemp.RemoveAt(i);
            }
            else if (i < _elementInputsTemp.Count + _elementOutputsTemp.Count)
            {
                i -= _elementInputsTemp.Count;
                _elementOutputsTemp.RemoveAt(i);
            }
            else
            {
                i -= _elementInputsTemp.Count;
                i -= _elementOutputsTemp.Count;
                _elementUsingsTemp.RemoveAt(i);
            }

            UpdateConnectionsListBox();
        }

        private void _okbutton1_Click(object sender, EventArgs e)
        {
            ElementName = _nametextBox2.Text;
            ElementInputs = _elementInputsTemp.ToArray();
            ElementOutputs = _elementOutputsTemp.ToArray();
            ElementUsings = _elementUsingsTemp.ToArray();
            ElementSource = _sourcetextBox1.Text;
        }

        private void _cancelbutton2_Click(object sender, EventArgs e)
        {

        }

        private void _connectionslistBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int i = _connectionslistBox1.SelectedIndex;
            if (i < 0) return;

            bool isinput = false;
            bool isusing = false;
            Connection conn = null;
            string us = null;
            if (i < _elementInputsTemp.Count)
            {
                isinput = true;
                conn = _elementInputsTemp[i];
            }
            else if (i < _elementInputsTemp.Count + _elementOutputsTemp.Count)
            {
                i -= _elementInputsTemp.Count;
                isinput = false;
                conn = _elementOutputsTemp[i];
            }
            else
            {
                i -= _elementInputsTemp.Count;
                i -= _elementOutputsTemp.Count;
                isusing = true;
                us = _elementUsingsTemp[i];
            }

            if (!isusing)
            {
                ScriptElementConnectionEditorForm form = new ScriptElementConnectionEditorForm(conn.Name, string.Empty, conn.TypeForConnection);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    if (isinput)
                    {
                        _elementInputsTemp[i] = InputConnectionBase.ConstructInputConnection(form.ConnectionType, form.ConnectionName);
                    }
                    else
                    {
                        _elementOutputsTemp[i] = OutputConnectionBase.ConstructOutputConnection(form.ConnectionType, form.ConnectionName);
                    }

                    UpdateConnectionsListBox();
                }
            }
            else
            {
                StringEditorForm form = new StringEditorForm(us);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    _elementUsingsTemp[i] = form.Value;

                    UpdateConnectionsListBox();
                }
            }
        }
    }
}
