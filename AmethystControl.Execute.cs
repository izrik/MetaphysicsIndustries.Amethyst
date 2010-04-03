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
            AsynchronousExecutionEngine engine = new AsynchronousExecutionEngine();

            engine.Execute(Entities.Extract<AmethystElement>(), _valueCache);
        }

        //ExecutionEngine _executionEngine = new ExecutionEngine();
        //public class ExecutionEngine
        //{
        private ValueCache _valueCache = new ValueCache();

            public void Execute()
            {

                try
                {
                    List<AmethystElement> order = GetExecutionOrder(Entities.Extract<AmethystElement>());

                    StringBuilder sb = new StringBuilder();
                    foreach (AmethystElement elem in order)
                    {
                        sb.AppendLine(elem.Text);

                        try
                        {
                            ExecuteElement(elem);
                        }
                        catch (Exception ee)
                        {
                            throw new AmethystExecuteException(elem, "Error in execution", ee);
                        }
                    }
                    MessageBox.Show(this, "Success: \r\n" + sb.ToString());
                }
                catch (Exception ee)
                {
                    if (ee is AmethystExecuteException)
                    {
                        AmethystExecuteException aee = (AmethystExecuteException)ee;

                        //clear value cache for downstream terminals
                        ClearValueCacheForElement(aee.Element);

                        //change states of all elements/terminals downstream to red/yellow
                        //UpdateTerminalStatesForElement(aee.Element);
                    }

                    //MessageBox.Show(this, "There was an exception: " + ee.ToString());
                    ReportException(ee);
                }

                Invalidate();
            }

        private List<AmethystElement> GetExecutionOrder(AmethystElement[] elements)
        {
            Set<AmethystElement> elems = new Set<AmethystElement>();
            List<AmethystElement> order = new List<AmethystElement>(Elements.Count);
            //Dictionary<AmethystElement, int> dependencyCounts = new Dictionary<AmethystElement, int>();
            Set<AmethystElement> freeElements = new Set<AmethystElement>();

            foreach (AmethystElement aelem in elements)
            {
                Set<OutputTerminal> terminals = new Set<OutputTerminal>();

                foreach (Terminal terminal in aelem.Terminals)
                {
                    if (terminal is OutputTerminal)
                    {
                        terminals.Add((OutputTerminal)terminal);
                    }
                }

                if (terminals.Count > 0)
                {
                    foreach (OutputTerminal terminal in terminals)
                    {
                        if (!_valueCache.ContainsKey(terminal))
                        {
                            elems.Add(aelem);
                            break;
                        }
                    }
                }
                else
                {
                    elems.Add(aelem);
                }
            }

            //dependencyCounts.Clear();
            //foreach (AmethystElement elem in elements)
            //{
            //    dependencyCounts[elem] = 0;
            //}

            while (elems.Count > 0)
            {
                freeElements.Clear();
                freeElements.AddRange(elems);
                foreach (AmethystElement elem in elems)
                {
                    foreach (Terminal terminal in elem.Terminals)
                    {
                        if (terminal is InputTerminal)
                        {
                            InputTerminal terminal2 = (InputTerminal)terminal;
                            if (terminal2.Path != null && terminal2.FromTerminal != null)
                            {
                                if (elems.Contains(terminal2.FromTerminal.ParentAmethystElement))
                                {
                                    //dependency
                                    freeElements.Remove(elem);
                                    break;
                                }
                            }
                            else
                            {
                                //unconnected input
                                throw new Exception("Unconnected Input: " + elem.Text + "." + terminal2.DisplayText);
                            }
                        }
                    }
                }

                if (freeElements.Count <= 0)
                {
                    //circular dependency

                    StringBuilder sb2 = new StringBuilder();

                    foreach (AmethystElement elem in elems)
                    {
                        sb2.AppendLine(elem.Text);
                    }

                    throw new Exception("Circular dependency: \r\n" + sb2.ToString());
                }

                order.AddRange(freeElements);
                elems.RemoveRange(freeElements);
            }
            return order;
        }

        private void ExecuteElement(AmethystElement elem)
        {
            Dictionary<InputConnectionBase, object> inputs = new Dictionary<InputConnectionBase, object>();
            Dictionary<OutputConnectionBase, object> outputs = new Dictionary<OutputConnectionBase, object>();

            foreach (Terminal terminal in elem.Terminals)
            {
                if (terminal is InputTerminal)
                {
                    InputTerminal terminal2 = (InputTerminal)terminal;
                    //terminal2.InputValue = terminal2.Path.FromTerminal.Result;

                    //inputs[terminal2.Connection] = terminal2.InputValue;
                    inputs[terminal2.Connection] = _valueCache[terminal2.FromTerminal];
                }
                //else if (terminal is OutputTerminal)
                //{
                //    OutputTerminal terminal2 = (OutputTerminal)terminal;

                //}
            }

            elem.Execute(inputs, outputs);

            foreach (OutputConnectionBase con in outputs.Keys)
            {
                _valueCache[(OutputTerminal)elem.TerminalsByConnection[con]] = outputs[con];
            }

            //foreach (Terminal term in elem.Terminals)
            //{
            //    if (term is OutputTerminal)
            //    {
            //        OutputTerminal term2 = (OutputTerminal)term;

            //        if (!_valueCache.ContainsKey(term2))
            //        {
            //            elem.Execute();
            //            break;
            //        }
            //    }
            //}

            //foreach (Terminal term in elem.Terminals)
            //{
            //    if (term is OutputTerminal)
            //    {
            //        OutputTerminal term2 = (OutputTerminal)term;

            //        if (!_valueCache.ContainsKey(term2))
            //        {
            //            elem.Execute();
            //            break;
            //        }
            //    }
            //}

            InvalidateRectFromEntity(elem);
            Refresh();
        }


            protected void ClearValueCacheForElement(AmethystElement element)
            {
                foreach (Terminal term in element.Terminals)
                {
                    RemoveFromValueCache(term);
                }
            }

            public void RemoveFromValueCache(Terminal terminal)
            {
                if (terminal is OutputTerminal)
                {
                    RemoveFromValueCache((OutputTerminal)terminal);
                }
                else if (terminal is InputTerminal)
                {
                    RemoveFromValueCache((InputTerminal)terminal);
                }
            }

            public void RemoveFromValueCache(OutputTerminal terminal)
            {
                if (_valueCache.ContainsKey(terminal))
                {
                    _valueCache.Remove(terminal);

                    foreach (AmethystPath apath in terminal.AmethystPaths)
                    {
                        RemoveFromValueCache(apath.ToTerminal);
                        InvalidateRectFromTerminal(apath.ToTerminal);
                    }

                    InvalidateRectFromTerminal(terminal);
                }
            }

            private void RemoveFromValueCache(InputTerminal terminal)
            {
                foreach (OutputConnectionBase con in terminal.Connection.Dependants)
                {
                    RemoveFromValueCache(terminal.ParentAmethystElement.TerminalsByConnection[con]);
                }
            }

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
        //}
    }
}

