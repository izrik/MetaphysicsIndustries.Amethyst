using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    [Serializable]
    public class SaveTextFileElement : AmethystElement
    {

        public SaveTextFileElement()
            : base(new SaveTextFileNode())
        {
        }

        [Serializable]
        public class SaveTextFileNode : Node
        {
            public SaveTextFileNode()
                : base("Save Text File")
            {
            }

            private InputConnection<string> _imageInput = new InputConnection<string>("Contents");
            public InputConnection<string> ImageInput
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
                string contents = (string)inputs[ImageInput];
                string filename = (string)inputs[FilenameInput];

                File.WriteAllText(filename, contents);
            }
        }
    }
}
