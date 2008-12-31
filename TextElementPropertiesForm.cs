using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MetaphysicsIndustries.Amethyst
{
    public partial class TextElementPropertiesForm : Form
    {
        public TextElementPropertiesForm()
        {
            InitializeComponent();
        }

        public string ElementText
        {
            get { return _text.Text; }
            set { _text.Text = value; }
        }

        public float ElementWidth
        {
            get
            {
                float f;
                if (float.TryParse(_width.Text, out f))
                {
                    return f;
                }
                else
                {
                    return 0;
                }
            }
            set { _width.Text = value.ToString(); }
        }

        public float ElementHeight
        {
            get
            {
                float f;
                if (float.TryParse(_height.Text, out f))
                {
                    return f;
                }
                else
                {
                    return 0;
                }
            }
            set { _height.Text = value.ToString(); }
        }

        public bool ElementShallRenderTerminals
        {
            get { return _renderTerminalsCheckBox.Checked; }
            set { _renderTerminalsCheckBox.Checked = value; }
        }
    }
}