using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Epiphany.Amethyst
{
    public class IdentityFilterElement : MatrixFilterElement
    {
        public IdentityFilterElement()
            : base(new MatrixFilterNode("Identity Filter"))
        {
        }
    }
}
