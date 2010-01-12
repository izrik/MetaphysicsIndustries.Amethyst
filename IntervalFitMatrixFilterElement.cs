using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Acuity;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class IntervalFitMatrixFilterElement : MatrixFilterElement
    {
        public IntervalFitMatrixFilterElement()
            : base(new IntervalFitMatrixFilter(), "Interval Fit")
        {
        }
    }
}
