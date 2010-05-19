using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Acuity;
using MetaphysicsIndustries.Utilities;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class DualBellMatrixFilterElement : MatrixFilterElement
    {
        public DualBellMatrixFilterElement()
            : base(new DualBellEdgeDetectorMatrixFilter(3), "Dual Bell Filter", new SizeV(100, 80))
        {
        }
    }
}
