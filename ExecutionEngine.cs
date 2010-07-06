using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Collections;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    public class ExecutionEngine : IExecutionEngine
    {
        public void Execute(AmethystElement[] elements, ValueCache valueCache)
        {
            AmethystElement[] order = GetExecutionOrder(elements, valueCache);

            StringBuilder sb = new StringBuilder();
            foreach (AmethystElement elem in order)
            {
                sb.AppendLine(elem.Text);

                try
                {
                    ExecuteElement(elem, valueCache);
                }
                catch (Exception ex)
                {
                    valueCache.Remove(elem);

                    throw ex;
                }
            }
        }

        private AmethystElement[] GetExecutionOrder(AmethystElement[] elements, ValueCache valueCache)
        {
            Set<AmethystElement> elems = new Set<AmethystElement>();
            List<AmethystElement> order = new List<AmethystElement>();
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
                        if (!valueCache.ContainsKey(terminal))
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
            return order.ToArray();
        }

        private void ExecuteElement(AmethystElement elem, ValueCache valueCache)
        {
            Dictionary<InputConnectionBase, object> inputs = new Dictionary<InputConnectionBase, object>();
            Dictionary<OutputConnectionBase, object> outputs = new Dictionary<OutputConnectionBase, object>();

            foreach (Terminal terminal in elem.Terminals)
            {
                if (terminal is InputTerminal)
                {
                    InputTerminal terminal2 = (InputTerminal)terminal;

                    inputs[terminal2.Connection] = valueCache[terminal2.FromTerminal];
                }
                else if (terminal is OutputTerminal)
                {
                    OutputTerminal terminal2 = (OutputTerminal)terminal;

                    outputs[terminal2.Connection] = null;
                }
            }

            elem.Execute(inputs, outputs);

            foreach (OutputConnectionBase con in outputs.Keys)
            {
                valueCache[(OutputTerminal)elem.TerminalsByConnection[con]] = outputs[con];
            }

            OnElementExecuted(elem);
        }

        public event EventHandler<AmethystElementEventArgs> ElementExecuted;

        protected void OnElementExecuted(AmethystElement element)
        {
            if (ElementExecuted != null)
            {
                ElementExecuted(this, new AmethystElementEventArgs(element));
            }
        }
    }
}
