using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;

namespace MetaphysicsIndustries.Amethyst
{
    public class DualBellMatrixFilterElement : MatrixFilterElement
    {
        public DualBellMatrixFilterElement()
            : base(new DualBellEdgeDetectorMatrixFilter(3), "Dual Bell Filter")
        {
        }
    }
}
