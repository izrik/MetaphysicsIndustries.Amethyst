using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MetaphysicsIndustries.Build;

namespace MetaphysicsIndustries.Epiphany.Amethyst
{
    public partial class ConverterTypeSelectionForm : Form
    {
        public ConverterTypeSelectionForm()
        {
            InitializeComponent();
        }

        private System.Type _inputType;
        public System.Type InputType
        {
            get { return _inputType; }
            set
            {
                _inputType = value;
                _inputTypeNameTextBox.Text = value.FullName;

                EnableOk();
            }
        }

        private System.Type _outputType;
        public System.Type OutputType
        {
            get { return _outputType; }
            set
            {
                _outputType = value;
                _outputTypeNameTextBox.Text = value.FullName;

                EnableOk();
            }
        }

        private void EnableOk()
        {
            _okButton.Enabled = (InputType != null && OutputType != null);
        }



        private void _inputSelectButton_Click(object sender, EventArgs e)
        {
            TypeSelectionForm form = new TypeSelectionForm();
            if (InputType != null)
            {
                form.Result = SystemType.GetSystemType(InputType);
            }
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                Build.Type result = form.Result;
                if (result is ISystemType)
                {
                    InputType = ((ISystemType)result).InternalType;
                }
            }
        }

        private void _outputSelectButton_Click(object sender, EventArgs e)
        {
            TypeSelectionForm form = new TypeSelectionForm();
            if (OutputType != null)
            {
                form.Result = SystemType.GetSystemType(OutputType);
            }
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                Build.Type result = form.Result;
                if (result is ISystemType)
                {
                    OutputType = ((ISystemType)result).InternalType;
                }
            }
        }
    }
}