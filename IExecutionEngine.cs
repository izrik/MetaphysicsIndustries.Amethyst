using System;
using System.Collections.Generic;
using System.Text;

namespace MetaphysicsIndustries.Amethyst
{
    public interface IExecutionEngine
    {
        void Execute(AmethystElement[] elements, ValueCache valueCache);

        event EventHandler<AmethystElementEventArgs> ElementExecuted;
    }
}
