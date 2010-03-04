using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Collections;

namespace MetaphysicsIndustries.Amethyst
{
    public partial class AmethystControl : MetaphysicsIndustries.Crystalline.CrystallineControl
    {
        bool _connecting = false;
        OutputTerminal _connectionSourceTerminal;
        InputTerminal _connectionCandidate;
        InputTerminal _disconnectionCandidate;

        //protected override void ProcessMouseDoubleClick(MouseEventArgs e)
        //{
        //    PointF docSpace = DocumentSpaceFromClientSpace(e.Location);
        //    Element element = GetFrontmostElementAtPointInDocumentSpace(docSpace);
        //    if (element is AmethystElement)
        //    {
        //        AmethystElement amelem = (AmethystElement)element;

        //        try
        //        {
        //            if (amelem.ShallProcessDoubleClick)
        //            {
        //                amelem.ProcessDoubleClick(this);
        //            }
        //        }
        //        catch (Exception ee)
        //        {
        //            MessageBox.Show(this, "There was an exception while processing the double-click: " + ee.ToString());
        //        }
        //    }

        //    //base.ProcessMouseDoubleClick(e);
        //}

        protected override void ProcessMouseDown(MouseEventArgs e)
        {
            if (_connecting)
            {
            }
            else
            {
                base.ProcessMouseDown(e);
            }
        }

        protected override void ProcessMouseMove(MouseEventArgs e)
        {
            PointF docSpace = DocumentSpaceFromClientSpace(e.Location);

            if (_connecting)
            {
                //Set<Element> elems = GetElementsAtPoint(docSpace);

                if (_connectionCandidate != null)
                {
                    InvalidateRectFromTerminal(_connectionCandidate);
                }


                InputTerminal terminal = GetFrontmostConnectableInputTerminalAtPointInDocumentSpace(docSpace);
                //if (terminal.IsConnectable(_connectionSourceTerminal))
                //{
                    _connectionCandidate = terminal;
                //}



                if (_connectionCandidate != null)
                {
                    InvalidateRectFromTerminal(_connectionCandidate);
                }

                InvalidateConnectionLine();
                InvalidateRectFromPointsInDocument(GetConnectionSourceTerminalLocationInDocumentSpace(), docSpace);
            }
            else
            {
                if (_connectionSourceTerminal != null)
                {
                    InvalidateRectFromTerminal(_connectionSourceTerminal);
                }

                _connectionSourceTerminal = GetFrontmostTerminalAtPointInDocumentSpace<OutputTerminal>(docSpace);
                _disconnectionCandidate = GetFrontmostTerminalAtPointInDocumentSpace<InputTerminal>(docSpace);

                if (_connectionSourceTerminal != null)
                {
                    InvalidateRectFromTerminal(_connectionSourceTerminal);
                }

                base.ProcessMouseMove(e);
            }
        }

        protected override void ProcessMouseUp(MouseEventArgs e)
        {
            if (_connecting)
            {
                if (_connectionCandidate != null
                    //&&
                    //_connectionCandidate != _connectionSourceTerminal
                    )
                {
                    MakeConnection(_connectionSourceTerminal, _connectionCandidate);
                }

                InvalidateConnectionLine();
                if (_connectionCandidate != null)
                {
                    InvalidateRectFromPointsInDocument(
                        _connectionCandidate.GetLocationInDocumentSpace(),
                        GetConnectionSourceTerminalLocationInDocumentSpace());
                }

                if (_connectionSourceTerminal != null)
                {
                    InvalidateRectFromTerminal(_connectionSourceTerminal);
                }
                if (_connectionCandidate != null)
                {
                    InvalidateRectFromTerminal(_connectionCandidate);
                }

                _connecting = false; 
                
            }
            else
            {
                base.ProcessMouseUp(e);
            }
        }
    }
}

