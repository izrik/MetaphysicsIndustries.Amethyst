using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Amethyst;

namespace Amethyst
{
    public partial class AmethystForm : CrystallineAppForm<AmethystControl>
    {
        public AmethystForm()
        {
            InitializeComponent();
        }

        protected override string DefaultExtension
        {
            get { return "amethyst"; }
        }

        protected override string Filter
        {
            get { return "Amethyst files (*.amethyst)|*.amethyst|All files (*.*)|*.*"; }
        }

        protected override string AppTitle
        {
            get { return "Amethyst"; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.Icon = Resource1.amethyst;
        }
    }
}

