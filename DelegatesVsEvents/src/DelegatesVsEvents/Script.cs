using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelegatesVsEvents
{
    public enum CastState
    {
        Casting,
        Iddle        
    }
    class ScriptEventArgs : EventArgs
    {
        public CastState CurrentCastState { get; private set; }
        public ScriptEventArgs(CastState currentState)
        {
            CurrentCastState = currentState;
        }
    }

    class Script
    {
        public string Name { get; set; }
        public event EventHandler<ScriptEventArgs> Interrupt;
        public void CastInterrupted()
        {
            //casting logic
            Interrupt?.Invoke(this, new ScriptEventArgs(CastState.Casting));
        }
    }
}
