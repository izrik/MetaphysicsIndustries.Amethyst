using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Collections;

namespace MetaphysicsIndustries.Amethyst
{
    class ExecutionState
    {
        public ExecutionState(AmethystControl control)
        {
            control.Entities.ItemAdded += Entities_ItemAdded;
            control.Entities.ItemRemoved += Entities_ItemRemoved;
        }



        public ValueCache ValueCache = new ValueCache();



        Dictionary<AmethystElement, bool> _isPaused = new Dictionary<AmethystElement, bool>();
        public bool IsPaused(AmethystElement element)
        {
            if (!_isPaused.ContainsKey(element))
            {
                _isPaused[element] = false;
            }

            return _isPaused[element];
        }
        public void Pause(AmethystElement element)
        {
            _isPaused[element] = true;
        }
        public void Unpause(AmethystElement elements)
        {
            _isPaused[elements] = false;
        }



        Dictionary<AmethystElement, Exception> _lastException = new Dictionary<AmethystElement, Exception>();
        public bool IsException(AmethystElement element)
        {
            return _lastException.ContainsKey(element);
        }
        public Exception GetLastException(AmethystElement element)
        {
            if (!_lastException.ContainsKey(element))
            {
                return null;
            }

            return _lastException[element];
        }
        public void ClearLastException(AmethystElement element)
        {
            if (_lastException.ContainsKey(element))
            {
                _lastException.Remove(element);
            }
        }



        Set<OutputTerminal> _hasChanged = new Set<OutputTerminal>();
        public void SetHasChanged(AmethystElement element)
        {
            foreach (OutputTerminal term in Collection.Extract<Terminal, OutputTerminal>(element.Terminals))
            {
                SetHasChanged(term);
            }
        }
        public void SetHasChanged(OutputTerminal terminal)
        {
            _hasChanged.Add(terminal);
        }
        public void ClearHasChanged(AmethystElement element)
        {
            foreach (OutputTerminal term in Collection.Extract<Terminal, OutputTerminal>(element.Terminals))
            {
                ClearHasChanged(term);
            }
        }
        public void ClearHasChanged(OutputTerminal terminal)
        {
            _hasChanged.Remove(terminal);
        }
        public void ClearAllHasChanged()
        {
            _hasChanged.Clear();
        }
        public bool GetHasChanged(OutputTerminal terminal)
        {
            return _hasChanged.Contains(terminal);
        }



        void Entities_ItemRemoved(Crystalline.Entity item)
        {
            if (item is AmethystElement)
            {
                AmethystElement element = (AmethystElement)item;
                if (_isPaused.ContainsKey(element))
                {
                    _isPaused.Remove(element);
                }
                ClearLastException(element);
                ClearHasChanged(element);
            }
        }
        void  Entities_ItemAdded(Crystalline.Entity item)
        {
        }
    }
}
