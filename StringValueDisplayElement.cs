using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Utilities;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class StringValueDisplayElement : ValueDisplayElement<string>
    {
        public StringValueDisplayElement()
            : base(new ValueDisplayNode("String Value"), new SizeV(80, 40))
        {
        }

        public override bool ShallProcessDoubleClick
        {
            get { return true; }
        }

        public override void ProcessDoubleClick(AmethystControl control)
        {
            StringDisplayForm form = new StringDisplayForm(Value);
            form.Show(control);
        }
    }
}
