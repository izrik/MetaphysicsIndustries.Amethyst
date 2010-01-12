using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Epiphany;
using MetaphysicsIndustries.Acuity;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class SaveImageElement : AmethystElement
    {
        public SaveImageElement()
            : base(new SaveImageNode())
        {
        }

        [Serializable]
        public class SaveImageNode : Node
        {
            public SaveImageNode()
                : base("Save Image")
            {
            }

            private InputConnection<Matrix> _imageInput = new InputConnection<Matrix>("Image");
            public InputConnection<Matrix> ImageInput
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
                Matrix image = (Matrix)inputs[ImageInput];
                string filename = (string)inputs[FilenameInput];

                AcuityEngine.SaveImage2(filename, image);
            }
        }
    }
}
