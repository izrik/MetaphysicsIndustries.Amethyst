using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Acuity;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class NegOneOneToZeroOneFitMatrixFilterElement : MatrixFilterElement
    {
        public NegOneOneToZeroOneFitMatrixFilterElement()
            : base(new ModulatorMatrixFilter(AcuityEngine.ConvertNegOneOneToZeroOne), "[-1,1] -> [0,1]")
        {
        }

        [Serializable]
        public class ModulatorMatrixFilter : MatrixFilter
        {
            public ModulatorMatrixFilter(Modulator mod)
            {
                _mod = mod;
            }

            private Modulator _mod;
            public Modulator Mod
            {
                get { return _mod; }
                set { _mod = value; }
            }

            public override Matrix Apply(Matrix input)
            {
                Matrix result = input.Clone();

                result.ApplyToAll(Mod);

                return result;
            }
        }
    }
}
