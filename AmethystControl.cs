using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MetaphysicsIndustries.Crystalline;

namespace MetaphysicsIndustries.Amethyst
{
    public partial class AmethystControl : MetaphysicsIndustries.Crystalline.CrystallineControl
    {
        public AmethystControl()
        {
            InitializeComponent();

            //_terminalConnectionEngine = new AmethystTerminalConnectionEngine(this);
        }

        AmethystTerminalConnectionEngine _terminalConnectionEngine;

        protected override void ProcessLoad()
        {
            base.ProcessLoad();

            //GetOpenFilenameElement gof = new GetOpenFilenameElement();
            //LoadImageElement li = new LoadImageElement();
            //ImageDisplayElement id = new ImageDisplayElement();

            //gof.Location = new PointF(100, 100);
            //li.Location = new PointF(175, 175);
            //id.Location = new PointF(275, 275);

            //AddElement(gof);
            //AddElement(li);
            //AddElement(id);

            //MakeConnection((OutputTerminal)gof.TerminalsByConnection[gof.Node2.Output], (InputTerminal)li.TerminalsByConnection[li.Node.Input]);
            //MakeConnection((OutputTerminal)li.TerminalsByConnection[li.Node.Output], (InputTerminal)id.TerminalsByConnection[id.Node.Input]);
        }
    }
}

