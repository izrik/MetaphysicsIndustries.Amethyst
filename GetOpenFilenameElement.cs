using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class GetOpenFilenameElement : StringLiteralElement
    {
        public GetOpenFilenameElement()
        {
            ((LiteralNode)Node).Value = "Filename";
        }

        public override bool ShallProcessDoubleClick
        {
            get { return true; }
        }

        public string asdlnfjkasd = "asdf";

        public override void ProcessDoubleClick(AmethystControl control)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = ((LiteralNode)Node).Value;

            if (ofd.ShowDialog(control) == DialogResult.OK)
            {
                ((LiteralNode)Node).Value = ofd.FileName;
            }
        }
    }
}
