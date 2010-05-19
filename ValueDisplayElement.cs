using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Utilities;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public abstract class ValueDisplayElement<T> : AmethystElement
    {
        public ValueDisplayElement(ValueDisplayNode node, SizeV size)
            : base(node, size)
        {
        }

        [Serializable]
        public class ValueDisplayNode : Node
        {
            public ValueDisplayNode(string name)
                : base(name)
            {
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(Input);
            }

            [NonSerialized]
            private T _value;
            public T Value
            {
                get { return _value; }
                set { _value = value; }
            }

            private InputConnection<T> _input = new InputConnection<T>("Input");
            public InputConnection<T> Input
            {
                get { return _input; }
                set { _input = value; }
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                Value = (T)inputs[Input];
            }
        }

        public T Value
        {
            get { return ((ValueDisplayNode)Node).Value; }
            set { ((ValueDisplayNode)Node).Value = value; }
        }

        public override string Text
        {
            get
            {
                if (Value != null)
                {
                    return InternalText;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        protected virtual string InternalText
        {
            get { return Value.ToString(); }
        }
    }
}
