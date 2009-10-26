using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    public class NullNode : Node
    {
        public NullNode()
            : base("Null Node")
        {
        }

        protected override void InitConnections()
        {
        }

        public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
        {
            foreach (OutputConnectionBase con in OutputConnectionBases)
            {
                outputs[con] = null;
            }
        }
    }
}
