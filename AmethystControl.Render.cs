using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MetaphysicsIndustries.Crystalline;

namespace MetaphysicsIndustries.Epiphany.Amethyst
{
    public partial class AmethystControl : CrystallineControl
    {
        Pen _connectionPen = new Pen(Color.Gold, 2);

        public virtual Pen ChoosePenForTerminal(Terminal terminal, Pen defaultPen)
        {
            if (terminal == _connectionSourceTerminal)
            {
                return _connectionPen;
            }
            else if (_connecting && terminal == _connectionCandidate)
            {
                return _connectionPen;
            }
            else
            {
                return defaultPen;
            }
        }

        public virtual Brush ChooseBrushForTerminal(Terminal terminal, Brush defaultBrush)
        {
            if (terminal is InputTerminal)
            {
                InputTerminal terminal2 = (InputTerminal)terminal;
                if (terminal2.IsConnected)
                {
                    return ChooseBrushForTerminal(terminal2.FromTerminal, defaultBrush);
                }
                //else if (!terminal2.IsRequired)
                //{
                //    return Brushes.LightGreen;
                //}
                else
                {
                    return Brushes.Red;
                }
            }
            else if (terminal is OutputTerminal)
            {
                OutputTerminal terminal2 = (OutputTerminal)terminal;
                if (_valueCache.ContainsKey(terminal2))
                {
                    return Brushes.LightGreen;
                }
                else
                {
                    return Brushes.Yellow;
                }
            }

            //switch (terminal.State)
            //{
            //    case TerminalState.Executed: return Brushes.LightGreen;
            //    case TerminalState.NeedsExecute: return Brushes.Yellow;
            //    case TerminalState.Error: return Brushes.Red;
            //    case TerminalState.DisconnectedOptional: return Brushes.LightBlue;
            //}
            return SystemBrushes.Window;
        }

        protected void InvalidateRectFromTerminal(Terminal terminal)
        {
            InvalidateRectInDocument(GetRectFromTerminalInDocumentSpace(terminal));
        }

        protected void InvalidateConnectionLine()
        {
            PointF cursorPos = LastMouseMoveInDocument;
            PointF managerPos = GetConnectionSourceTerminalLocationInDocumentSpace();

            InvalidateRectFromPointsInDocument(cursorPos, managerPos);

            if (_connectionCandidate != null)
            {
                PointF candidatePos = _connectionCandidate.GetLocationInDocumentSpace();
                InvalidateRectFromPointsInDocument(managerPos, candidatePos);
            }
        }

        protected override void ProcessPaint(PaintEventArgs e)
        {
            base.ProcessPaint(e);

            if (_connecting)
            {
                PointF cursorPos = LastMouseMoveInDocument;
                PointF managerPos = GetConnectionSourceTerminalLocationInDocumentSpace();

                if (_connectionCandidate != null)
                {
                    PointF candidatePos = _connectionCandidate.GetLocationInDocumentSpace();
                    e.Graphics.DrawLine(_connectionPen, managerPos, candidatePos);

                    //e.Graphics.DrawLine(_connectionPen, managerPos, cursorPos);
                }
                else
                {
                    e.Graphics.DrawLine(_connectionPen, managerPos, cursorPos);
                }
            }
        }
    }
}

