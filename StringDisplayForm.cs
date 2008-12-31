using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MetaphysicsIndustries.Amethyst
{
    public partial class StringDisplayForm : Form
    {
        public StringDisplayForm(string text)
        {
            InitializeComponent();

            textBox1.Text = text;
        }
    }
}