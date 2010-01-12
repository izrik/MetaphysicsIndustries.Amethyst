using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class StringValueDisplayElement : ValueDisplayElement<string>
    {
        public StringValueDisplayElement()
            : base(new ValueDisplayNode("String Value"), new SizeF(80, 40))
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
