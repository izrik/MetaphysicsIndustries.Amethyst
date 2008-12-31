using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    public class TypeofElement : AmethystElement
    {
        public TypeofElement()
            : base(new TypeofNode())
        {
        }

        public class TypeofNode : Node
        {
            public TypeofNode()
                : base("typeof()")
            {
            }

            private InputConnection<object> _value = new InputConnection<object>("Value");
            public InputConnection<object> Value
            {
                get { return _value; }
            }
            private OutputConnection<Type> _type = new OutputConnection<Type>("Type");
            public OutputConnection<Type> Type
            {
                get { return _type; }
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(Value);
                OutputConnectionBases.Add(Type);
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                object value = inputs[Value];


                outputs[Type] = ((value != null) ? value.GetType() : null);
            }
        }
    }
}
