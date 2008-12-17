using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MetaphysicsIndustries.Epiphany.Amethyst
{
    public class GetSaveFilenameElement : StringLiteralElement
    {
        public GetSaveFilenameElement()
        {
            ((LiteralNode)Node).Value = "Filename";
        }

        public override bool ShallProcessDoubleClick
        {
            get { return true; }
        }

        public override void ProcessDoubleClick(AmethystControl control)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = ((LiteralNode)Node).Value;

            if (sfd.ShowDialog(control) == DialogResult.OK)
            {
                ((LiteralNode)Node).Value = sfd.FileName;
            }
        }
    }
}
