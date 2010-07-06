using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Utilities;
using MetaphysicsIndustries.Build;

namespace MetaphysicsIndustries.Amethyst
{
    public partial class TerminalEditorForm : Form
    {
        public TerminalEditorForm(string name, string displayText, System.Type terminalType, BoxOrientation orientation, float position, SizeV parentNodeSize)
        {
            InitializeComponent();

            if (name == null) name = string.Empty;
            if (displayText == null) displayText = string.Empty;
            if (terminalType == null) terminalType = typeof(object);

            TerminalName = name;
            TerminalDisplayText = displayText;
            TerminalType = terminalType;
            TerminalOrientation = orientation;
            TerminalPosition = position;
            ParentNodeSize = parentNodeSize;
        }

        private string _terminalName;
        public string TerminalName
        {
            get { return _terminalName; }
            set
            {
                _terminalName = value;
                _nametextBox1.Text = value;
            }
        }

        private string _terminalDisplayText;
        public string TerminalDisplayText
        {
            get { return _terminalDisplayText; }
            set
            {
                _terminalDisplayText = value;
                _displayTexttextBox2.Text = value;
            }
        }

        System.Type _terminalType;
        public System.Type TerminalType
        {
            get { return _terminalType; }
            set
            {
                _terminalType = value;
                TerminalTypeTemp = value;
            }
        }

        System.Type _terminalTypeTemp;
        protected System.Type TerminalTypeTemp
        {
            get { return _terminalTypeTemp; }
            set
            {
                _terminalTypeTemp = value;
                _typetextBox3.Text = RenderTypeName(value);
            }
        }

        private BoxOrientation _terminalOrientation;
        public BoxOrientation TerminalOrientation
        {
            get { return _terminalOrientation; }
            set
            {
                _terminalOrientation = value;

                switch (value)
                {
                    case BoxOrientation.Left: _orientationcomboBox1.SelectedIndex = 0; break;
                    case BoxOrientation.Up: _orientationcomboBox1.SelectedIndex = 1; break;
                    case BoxOrientation.Right: _orientationcomboBox1.SelectedIndex = 2; break;
                    case BoxOrientation.Down: _orientationcomboBox1.SelectedIndex = 3; break;
                }

                if (value == BoxOrientation.Left ||
                    value == BoxOrientation.Right)
                {
                    OrientationIsLeftOrRight = true;
                }
                else
                {
                    OrientationIsLeftOrRight = false;
                }
            }
        }

        bool _orientationIsLeftOrRight;
        protected bool OrientationIsLeftOrRight
        {
            get { return _orientationIsLeftOrRight; }
            set
            {
                _orientationIsLeftOrRight = value;
                SetPositionMaximum();
            }
        }

        int _positionScale = 10;

        private float _terminalPosition;
        public float TerminalPosition
        {
            get { return _terminalPosition; }
            set
            {
                _terminalPosition = value;
                SetPositonValue();
            }
        }

        private void SetPositonValue()
        {
            _positiontrackBar1.Value = Math.Min((int)(TerminalPosition * _positionScale), _positiontrackBar1.Maximum);
        }

        private SizeV _parentNodeSize;
        public SizeV ParentNodeSize
        {
            get { return _parentNodeSize; }
            set
            {
                _parentNodeSize = value;

                _positiontrackBar1.Minimum = 0;
                _positiontrackBar1.TickFrequency = 5 * _positionScale;
                _positiontrackBar1.SmallChange = _positionScale;

                SetPositionMaximum();
            }
        }

        private void SetPositionMaximum()
        {
            if (OrientationIsLeftOrRight)
            {
                _positiontrackBar1.Maximum = (int)(ParentNodeSize.Width * _positionScale);
            }
            else
            {
                _positiontrackBar1.Maximum = (int)(ParentNodeSize.Height * _positionScale);
            }
            _positiontrackBar1.LargeChange = Math.Max(_positiontrackBar1.Maximum / 8, _positionScale);

            SetPositonValue();
        }

        private void _selectbutton1_Click(object sender, EventArgs e)
        {
            TypeSelectionForm form = new TypeSelectionForm();
            form.Result = SystemType.GetSystemType(TerminalTypeTemp);
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                if (!(form.Result is ISystemType))
                {
                    throw new InvalidOperationException();
                }

                TerminalTypeTemp = ((ISystemType)form.Result).InternalType;
            }
        }

        public static string RenderTypeName(System.Type type)
        {
            return type.ToString();
        }

        private void _positiontrackBar1_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void _orientationcomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_orientationcomboBox1.SelectedIndex == 0 || _orientationcomboBox1.SelectedIndex == 2)
            {
                OrientationIsLeftOrRight = true;
            }
            else
            {
                OrientationIsLeftOrRight = false;
            }
        }

        private void _okbutton2_Click(object sender, EventArgs e)
        {
            TerminalName = _nametextBox1.Text;
            TerminalDisplayText = _displayTexttextBox2.Text;
            TerminalType = TerminalTypeTemp;
            switch (_orientationcomboBox1.SelectedIndex)
            {
                case 0: TerminalOrientation = BoxOrientation.Left; break;
                case 1: TerminalOrientation = BoxOrientation.Up; break;
                case 2: TerminalOrientation = BoxOrientation.Right; break;
                default: TerminalOrientation = BoxOrientation.Down; break;
            }
            TerminalPosition = _positiontrackBar1.Value / _positionScale;
        }

    }
}
