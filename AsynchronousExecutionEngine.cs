using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Collections;
using System.Threading;
using MetaphysicsIndustries.Epiphany;

namespace MetaphysicsIndustries.Amethyst
{
    class AsynchronousExecutionEngine //: IExecutionEngine
    {
        //public void Execute(AmethystElement[] elements, ValueCache valueCache)
        //{
        //    Set<AmethystElement> toExecute = new Set<AmethystElement>(elements);

        //    while (toExecute.Count > 0)
        //    {
        //        AmethystElement[] order = GetExecutionOrder(toExecute.ToArray(), valueCache);

        //        AmethystElement elem = order[0];

        //        ExecuteElement(elem, valueCache);

        //        //toExecute.Clear();
        //        //toExecute.AddRange(order);
        //        toExecute.Remove(elem);
        //    }
        //}

        //private void ExecuteElement(AmethystElement elem, ValueCache valueCache)
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        //private AmethystElement[] GetExecutionOrder(AmethystElement[] amethystElement, ValueCache valueCache)
        //{
        //    throw new Exception("The method or operation is not implemented.");
        //}

        //protected virtual void OnElementsExecuted(AmethystElement[] elements)
        //{
        //    if (ElementExecuted != null)
        //    {
        //        foreach (AmethystElement elem in elements)
        //        {
        //            ElementExecuted(this, new AmethystElementEventArgs(elem));
        //        }
        //    }
        //}

        //public event EventHandler<AmethystElementEventArgs> ElementExecuted;

        public void AddElement(AmethystElement elem)
        {
        }

        public void RemoveElement(AmethystElement elem)
        {
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }

        protected void Init()
        {
            if (_scheduler == null)
            {
                _scheduler = new SchedulerThread();
            }

            if (_workers == null || _workers.Length != Environment.ProcessorCount)
            {
                WorkerThread[] w = new WorkerThread[Environment.ProcessorCount];
                if (_workers != null)
                {
                    int i;
                    for (i = 0; i < Math.Min(_workers.Length, w.Length); i++)
                    {
                        w[i] = _workers[i];
                    }
                    for (; i < _workers.Length; i++)
                    {
                        throw new NotImplementedException();
                        //_workers[i].Abort();
                    }
                    for (; i < w.Length; i++)
                    {
                        w[i] = new WorkerThread();
                        throw new NotImplementedException();
                        //w[i].Start(w[i]);
                    }
                    _workers = w;
                }
            }
        }

        SchedulerThread _scheduler;
        WorkerThread[] _workers;

        class SchedulerThread
        {
            public SchedulerThread()
            {
                _thread = new Thread(ThreadProc);
            }

            void ThreadProc(object param)
            {
                Random rand = new Random();

                while (true)
                {
                    while (_running)
                    {
                        Set<AmethystElement> toExecute = new Set<AmethystElement>();

                        foreach (AmethystElement elem in _elements)
                        {
                            if (/*/elem is connected/*/false)
                            {
                                if (/*/input data is available/*/false)
                                {
                                    toExecute.Add(elem);
                                }
                            }
                        }

                        AmethystElement[] array = new AmethystElement[toExecute.Count];
                        while (toExecute.Count > 0)
                        {
                            toExecute.CopyTo(array, 0);
                            int i = rand.Next(toExecute.Count);
                            AmethystElement elem = array[i];
                            toExecute.Remove(elem);

                            ExecuteElement(elem);
                        }

                    }
                    while (!_running)
                    {
                    }
                }
            }

            private void ExecuteElement(AmethystElement elem)
            {
                throw new NotImplementedException();
            }

            Set<AmethystElement> _elements = new Set<AmethystElement>();
            bool _running = false;
            Thread _thread;
            Semaphore _executeWait;
        }

        class WorkerThread
        {
            public WorkerThread()
            {
                _thread = new Thread(ThreadProc);
            }

            void ThreadProc(object param)
            {
            }

            Thread _thread;
        }


        Dictionary<Type, object> _defaultValues = new Dictionary<Type, object>();
        public void RegisterDefaultValue(Type type, object value)
        {
            _defaultValues[type] = value;
        }
        public void RegisterDefaultValue<T>(T value)
        {
            RegisterDefaultValue(typeof(T), value);
        }
        public void UnregisterDefaultValue<T>()
        {
            UnregisterDefaultValue(typeof(T));
        }
        public void UnregisterDefaultValue(Type type)
        {
            if (_defaultValues.ContainsKey(type))
            {
                _defaultValues.Remove(type);
            }
        }
        public object GetDefaultValue(Type type)
        {
            object value;
            if (_defaultValues.ContainsKey(type))
            {
                value = _defaultValues[type];
            }
            else
            {
                value = type.IsValueType ? Activator.CreateInstance(type) : null;
                RegisterDefaultValue(type, value);
            }
            return value;
        }

        public string[] Iterate(AmethystElement[] elements, ValueCache valueCache)
        {
            if (elements == null) throw new ArgumentNullException("elements");
            if (valueCache == null) throw new ArgumentNullException("valueCache");

            Set<AmethystElement> elems = new Set<AmethystElement>(elements);


            Set<AmethystElement> toRemove = new Set<AmethystElement>();
            //exclude disqualified: disconnected, paused
            foreach (AmethystElement e in elems)
            {
                //if (e is paused)
                //{
                //  toRemove.Add(e);
                //  continue;
                //}

                bool isDisconnected = false;
                foreach (InputTerminal term in (Collection.Extract<Terminal, InputTerminal>(e.Terminals)))
                {
                    if (!term.IsConnected)
                    {
                        toRemove.Add(e);
                        isDisconnected = true;
                        break;
                    }
                }
                if (isDisconnected) continue;

                //more?
            }
            elems.RemoveRange(toRemove);

            List<string> results = new List<string>();

            while (elems.Count > 0)
            {
                Set<AmethystElement> toExecute = new Set<AmethystElement>();
                //get all that have sufficient data available
                foreach (AmethystElement e in elems)
                {
                    bool isAvailable = true;
                    foreach (InputTerminal term in (Collection.Extract<Terminal, InputTerminal>(e.Terminals)))
                    {
                        if (!valueCache.ContainsKey(term.FromTerminal))
                        {
                            isAvailable = false;
                            break;
                        }
                    }
                    if (isAvailable)
                    {
                        toExecute.Add(e);
                    }
                }


                if (toExecute.Count < 1)
                {
                    //none were available
                    //set default values in the value cache and execute all
                    foreach (AmethystElement e in elems)
                    {
                        foreach (InputTerminal term in (Collection.Extract<Terminal, InputTerminal>(e.Terminals)))
                        {
                            if (!valueCache.ContainsKey(term.FromTerminal))
                            {
                                object value = GetDefaultValue(term.FromTerminal.Connection.TypeForConnection);
                                valueCache.Add(term.FromTerminal, value);
                            }
                        }
                    }
                    toExecute.AddRange(elems);
                }


                // execute!
                Dictionary<AmethystElement, ElementExecution> execs = new Dictionary<AmethystElement, ElementExecution>();
                foreach (AmethystElement e in toExecute)
                {
                    ElementExecution exec = new ElementExecution(e);
                    execs[e] = exec;
                    Dictionary<InputConnectionBase, object> inputs = exec.Inputs;

                    foreach (InputTerminal term in (Collection.Extract<Terminal, InputTerminal>(e.Terminals)))
                    {
                        inputs[term.Connection] = valueCache[term.FromTerminal];
                    }

                    ThreadPool.QueueUserWorkItem(ExecuteElement, exec);
                }
                foreach (AmethystElement e in toExecute)
                {
                    execs[e].WaitHandle.WaitOne();
                    OnElementExecuted(e);
                    Dictionary<OutputConnectionBase, object> outputs = execs[e].Outputs;

                    foreach (OutputTerminal term in (Collection.Extract<Terminal, OutputTerminal>(e.Terminals)))
                    {
                        valueCache[term] = outputs[term.Connection];
                    }

                    results.Add(execs[e].Result);
                }


                //remove
                elems.RemoveRange(toExecute);


                //loop! - while (elems.Count > 0)
            }

            return results.ToArray();
        }


        class ElementExecution
        {
            public ElementExecution(AmethystElement element)
            {
                Element = element;
            }
            public AmethystElement Element;
            public Dictionary<InputConnectionBase, object> Inputs = new Dictionary<InputConnectionBase, object>();
            public Dictionary<OutputConnectionBase, object> Outputs = new Dictionary<OutputConnectionBase, object>();
            public EventWaitHandle WaitHandle = new ManualResetEvent(false);
            public string Result = string.Empty;
        }

        void ExecuteElement(object state)
        {
            ElementExecution exec = (ElementExecution)state;

            Exception ex = null;
            try
            {
                exec.Element.Execute(exec.Inputs, exec.Outputs);
            }
            catch (Exception ex2)
            {
                ex = ex2;
            }

            if (ex == null)
            {
                exec.Result = exec.Element.Text;
            }
            else
            {
                exec.Result = exec.Element.Text + ": " + ex.ToString();
            }

            exec.WaitHandle.Set();

            //throw new NotImplementedException("UI stuff on separate threads!");
            //OnElementExecuted(exec.Element);
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
