using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Solus;
using MetaphysicsIndustries.Collections;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    public partial class AmethystControl : CrystallineControl
    {
        public void ExecuteAsync()
        {
            try
            {
                //AsynchronousExecutionEngine engine = new AsynchronousExecutionEngine();

                //engine.Execute(Entities.Extract<AmethystElement>(), _valueCache);
            }
            catch (Exception ex)
            {
                ReportException(ex);
            }
        }

        private ValueCache _valueCache = new ValueCache();

        ExecutionEngine _executionEngine = new ExecutionEngine();
        AsynchronousExecutionEngine _asyncExecutionEngine = new AsynchronousExecutionEngine();

        //protected void UpdateTerminalStatesForElement(AmethystElement element)
        //{
        //    foreach (Terminal term in element.Terminals)
        //    {
        //        if (term is OutputTerminal)
        //        {
        //            OutputTerminal term2 = (OutputTerminal)term;

        //            UpdateOutputTerminalState(term2);

        //            foreach (AmethystPath path in term2.AmethystPaths)
        //            {
        //                if (path.To != null && path.To is AmethystElement)
        //                {
        //                    ClearValueCacheForElement((AmethystElement)path.To);
        //                }
        //            }
        //        }
        //    }
        //}

        void valueCache_TerminalRemoved(object sender, TerminalEventArgs e)
        {
            InvalidateRectFromTerminal(e.Terminal);

            //is execution is synchronous

            foreach (AmethystPath apath in e.Terminal.AmethystPaths)
            {
                RemoveFromValueCache(apath.ToTerminal);
            }
        }


        void executionEngine_ElementExecuted(object sender, AmethystElementEventArgs e)
        {
            InvalidateRectFromEntity(e.Element);
            Refresh();
        }
    }
}

