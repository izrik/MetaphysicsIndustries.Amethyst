using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Collections;

namespace MetaphysicsIndustries.Amethyst
{
    class AsynchronousExecutionEngine : IExecutionEngine
    {
        public void Execute(AmethystElement[] elements, ValueCache valueCache)
        {
            Set<AmethystElement> toExecute = new Set<AmethystElement>(elements);

            while (toExecute.Count > 0)
            {
                AmethystElement[] order = GetExecutionOrder(toExecute.ToArray(), valueCache);

                AmethystElement elem = order[0];

                ExecuteElement(elem, valueCache);

                //toExecute.Clear();
                //toExecute.AddRange(order);
                toExecute.Remove(elem);
            }
        }

        private void ExecuteElement(AmethystElement elem, ValueCache valueCache)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private AmethystElement[] GetExecutionOrder(AmethystElement[] amethystElement, ValueCache valueCache)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected virtual void OnElementsExecuted(AmethystElement[] elements)
        {
            if (ElementExecuted != null)
            {
                foreach (AmethystElement elem in elements)
                {
                    ElementExecuted(this, new AmethystElementEventArgs(elem));
                }
            }
        }

        public event EventHandler<AmethystElementEventArgs> ElementExecuted;
    }
}
