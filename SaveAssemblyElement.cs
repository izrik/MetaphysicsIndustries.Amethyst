using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class SaveAssemblyElement : AmethystElement
    {
        public SaveAssemblyElement()
            : base(new SaveAssemblyNode())
        {
        }

        [Serializable]
        public class SaveAssemblyNode : Node
        {
            public SaveAssemblyNode()
                : base("Save Assembly")
            {
            }

            private InputConnection<Assembly> _imageInput = new InputConnection<Assembly>("Assembly");
            public InputConnection<Assembly> ImageInput
            {
                get { return _imageInput; }
            }
            private InputConnection<string> _filenameInput = new InputConnection<string>("Filename");
            public InputConnection<string> FilenameInput
            {
                get { return _filenameInput; }
            }


            protected override void InitConnections()
            {
                InputConnectionBases.Add(ImageInput);
                InputConnectionBases.Add(FilenameInput);
            }

            public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
            {
                Assembly image = (Assembly)inputs[ImageInput];
                string filename = (string)inputs[FilenameInput];

                //Assembly.sa
                throw new NotImplementedException();
            }
        }
    }
}
