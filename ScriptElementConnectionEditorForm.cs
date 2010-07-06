using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MetaphysicsIndustries.Build;

namespace MetaphysicsIndustries.Amethyst
{
    public partial class ScriptElementConnectionEditorForm : Form
    {
        public ScriptElementConnectionEditorForm(            )
            :this(string.Empty,string.Empty, typeof(string))
        {
        }
        public ScriptElementConnectionEditorForm(string name, string displayText, System.Type type)
        {
            if (string.IsNullOrEmpty(name)) name = string.Empty;
            if (string.IsNullOrEmpty(displayText)) displayText = string.Empty;
            if (type == null) type = typeof(string);

            InitializeComponent();

            ConnectionName = name;
            ConnectionDisplayText = displayText;
            ConnectionType = type;
        }

        string _connectionName;
        public string ConnectionName
        {
            get { return _connectionName; }
            set
            {
                _connectionName = value;
                _nametextBox1.Text = value;
            }
        }
        string _connectionDisplayText;
        public string ConnectionDisplayText
        {
            get { return _connectionDisplayText; }
            set
            {
                _connectionDisplayText = value;
                _displayTexttextBox2.Text = value;
            }
        }
        System.Type _connectionType;
        public System.Type ConnectionType
        {
            get { return _connectionType; }
            set
            {
                _connectionType = value;
                ConnectionTypeTemp = value;
            }
        }

        CSharpRenderer _renderer = new CSharpRenderer();
        CSharpRenderContext _context = new CSharpRenderContext();

        System.Type _connectionTypeTemp;
        public System.Type ConnectionTypeTemp
        {
            get { return _connectionTypeTemp; }
            set
            {
                _connectionTypeTemp = value;

                _typetextBox4.Text = _renderer.RenderTypeReference(SystemType.GetSystemType(value), _context);
            }
        }

        private void _okbutton1_Click(object sender, EventArgs e)
        {
            ConnectionType = ConnectionTypeTemp;
            ConnectionName = _nametextBox1.Text;
            ConnectionDisplayText = _displayTexttextBox2.Text;
        }

        private void _selectbutton1_Click(object sender, EventArgs e)
        {
            TypeSelectionForm form = new TypeSelectionForm();
            form.Result = SystemType.GetSystemType(ConnectionTypeTemp);

            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                if (!(form.Result is ISystemType))
                {
                    throw new InvalidOperationException();
                }

                ConnectionTypeTemp = ((ISystemType)form.Result).InternalType;
            }
        }
    }
}
