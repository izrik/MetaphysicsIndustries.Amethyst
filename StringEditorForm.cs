using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MetaphysicsIndustries.Amethyst
{
    public partial class StringEditorForm : Form
    {
        public StringEditorForm()
            : this(string.Empty)
        {
        }
        public StringEditorForm(string value)
        {
            InitializeComponent();

            Value = value;
        }

        public bool Multiline
        {
            get { return _valueTextBox.Multiline; }
            set { _valueTextBox.Multiline = value; }
        }

        private string _value = string.Empty;
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Value = _valueTextBox.Text;
        }

        private void StringEditorForm_Load(object sender, EventArgs e)
        {
            _valueTextBox.Text = Value;
        }

        private void _valueTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}