using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Epiphany.Amethyst
{
    public class ConverterElement<TInput, TOutput> : ConverterElementBase
        where TInput : TOutput
    {
        public ConverterElement()
            : base(new ConverterNode())
        {
        }

        public class ConverterNode : Node
        {
            public ConverterNode()
                : base("Converter " + typeof(TInput).Name + " -> " + typeof(TOutput).Name)
            {
            }

            protected override void InitConnections()
            {
                InputConnectionBases.Add(Input);
                OutputConnectionBases.Add(Output);
            }

            private InputConnectionBase _input = new InputConnection<TInput>("Input");
            public InputConnectionBase Input
            {
                get { return _input; }
            }
            private OutputConnectionBase _output = new OutputConnection<TOutput>("Output");
            public OutputConnectionBase Output
            {
                get { return _output; }
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                TInput input = (TInput)inputs[Input];

                TOutput output = (TOutput)input;

                outputs[Output] = output;
            }
        }


    }
}
