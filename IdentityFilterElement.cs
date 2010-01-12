using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class IdentityFilterElement : MatrixFilterElement
    {
        public IdentityFilterElement()
            : base(new MatrixFilterNode("Identity Filter"))
        {
        }
    }
}
