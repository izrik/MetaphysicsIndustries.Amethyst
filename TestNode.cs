using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    public class TestNode : Node
    {
        public TestNode()
            :base("Test")
        {
        } 

        protected override void InitConnections()
        {
            InputConnectionBases.Add(Input);
            OutputConnectionBases.Add(Output);
        }

        private InputConnectionBase _input = new InputConnection<double>("Input");
        public InputConnectionBase Input
        {
            get { return _input; }
        }

        private OutputConnectionBase _output = new OutputConnection<double>("Output");
        public OutputConnectionBase Output
        {
            get { return _output; }
        }


        public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
