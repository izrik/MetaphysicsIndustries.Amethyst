using System;
using System.Collections.Generic;
using System.Text;
using MetaphysicsIndustries.Solus;

namespace MetaphysicsIndustries.Epiphany.Amethyst
{
    //public class MmseNode : Node
    //{
    //    public MmseNode()
    //        : base("MMSE")
    //    {
    //    }

    //    protected override void InitConnections()
    //    {
    //        InputConnectionBases.Add(_input);
    //        InputConnectionBases.Add(_noiseVariance);
    //        InputConnectionBases.Add(_windowSize);
    //        InputConnectionBases.Add(_row);
    //        InputConnectionBases.Add(_column);
    //        InputConnectionBases.Add(_signalMeanInput);
    //        InputConnectionBases.Add(_signalVariance);

    //        OutputConnectionBases.Add(_output);
    //        OutputConnectionBases.Add(_signalMeanOutput);
    //        OutputConnectionBases.Add(_window);
    //    }

    //    private InputConnectionBase _input = new InputConnection<Matrix>("Input");
    //    public InputConnectionBase Input
    //    {
    //        get { return _input; }
    //    }

    //    private InputConnectionBase _noiseVariance = new InputConnection<double>("NoiseVariance");
    //    public InputConnectionBase NoiseVariance
    //    {
    //        get { return _noiseVariance; }
    //    }

    //    private InputConnectionBase _windowSize = new InputConnection<int>("WindowSize");
    //    public InputConnectionBase WindowSize
    //    {
    //        get { return _windowSize; }
    //    }

    //    private InputConnectionBase _row = new InputConnection<int>("Row");
    //    public InputConnectionBase Row
    //    {
    //        get { return _row; }
    //    }

    //    private InputConnectionBase _column = new InputConnection<int>("Column");
    //    public InputConnectionBase Column
    //    {
    //        get { return _column; }
    //    }

    //    private InputConnectionBase _signalMeanInput = new InputConnection<double>("SignalMean");
    //    public InputConnectionBase SignalMeanInput
    //    {
    //        get { return _signalMeanInput; }
    //    }

    //    private InputConnectionBase _signalVariance = new InputConnection<double>("SignalVariance");
    //    public InputConnectionBase SignalVariance
    //    {
    //        get { return _signalVariance; }
    //    }

    //    private OutputConnectionBase _output = new OutputConnection<double>("Output");
    //    public OutputConnectionBase Output
    //    {
    //        get { return _output; }
    //    }
    //    private OutputConnectionBase _window = new OutputConnection<Matrix>("Window");
    //    public OutputConnectionBase Window
    //    {
    //        get { return _window; }
    //    }
    //    private OutputConnectionBase _signalMeanOutput = new OutputConnection<double>("SignalMean");
    //    public OutputConnectionBase SignalMeanOutput
    //    {
    //        get { return _signalMeanOutput; }
    //    }


    //    public override void Execute(Dictionary<InputConnectionBase, object> inputs, Dictionary<OutputConnectionBase, object> outputs)
    //    {
    //        throw new Exception("The method or operation is not implemented.");
    //    }
    //}
}
