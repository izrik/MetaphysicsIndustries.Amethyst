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
    public partial class CSharpCodeEditorForm : Form
    {
        public CSharpCodeEditorForm(CSharpCodeElement element)
        {
            InitializeComponent();

            //parameters
            //return value
            //code
        }

        List<Parameter> _parameters = new List<Parameter>();
        System.Type _returnType = typeof(void);
        string _code = string.Empty;

        private void _chooseTypeButton_Click(object sender, EventArgs e)
        {

        }

        private void _parametersButton_Click(object sender, EventArgs e)
        {

        }

    }
}