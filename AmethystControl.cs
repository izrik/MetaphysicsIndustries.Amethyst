using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    public partial class AmethystControl : MetaphysicsIndustries.Crystalline.CrystallineControl
    {
        public AmethystControl()
        {
            InitializeComponent();

            //_terminalConnectionEngine = new AmethystTerminalConnectionEngine(this);

            _valueCache.TerminalRemoved += valueCache_TerminalRemoved;
            _executionEngine.ElementExecuted += executionEngine_ElementExecuted;
            _asyncExecutionEngine.ElementExecuted += executionEngine_ElementExecuted;
        }

        AmethystTerminalConnectionEngine _terminalConnectionEngine;

        protected override void ProcessLoad()
        {
            base.ProcessLoad();

            //GetOpenFilenameElement gof = new GetOpenFilenameElement();
            //LoadImageElement li = new LoadImageElement();
            //ImageDisplayElement id = new ImageDisplayElement();

            //gof.Location = new Vector(100, 100);
            //li.Location = new Vector(175, 175);
            //id.Location = new Vector(275, 275);

            //AddElement(gof);
            //AddElement(li);
            //AddElement(id);

            //MakeConnection((OutputTerminal)gof.TerminalsByConnection[gof.Node2.Output], (InputTerminal)li.TerminalsByConnection[li.Node.Input]);
            //MakeConnection((OutputTerminal)li.TerminalsByConnection[li.Node.Output], (InputTerminal)id.TerminalsByConnection[id.Node.Input]);
        }

        public void RemoveFromValueCache(OutputTerminal terminal)
        {
            if (terminal == null) { throw new ArgumentNullException("terminal"); }

            _valueCache.Remove(terminal);
        }

        protected void RemoveFromValueCache(InputTerminal terminal)
        {
            foreach (OutputConnectionBase con in terminal.Connection.Dependants)
            {
                RemoveFromValueCache((OutputTerminal)(terminal.ParentAmethystElement.TerminalsByConnection[con]));
            }
        }
    }
}

