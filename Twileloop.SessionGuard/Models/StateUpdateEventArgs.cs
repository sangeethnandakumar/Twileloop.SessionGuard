using System;
using System.Collections.Generic;
using Twileloop.SessionGuard.State;

namespace Twileloop.SessionGuard.Models
{
    public class StateUpdateEventArgs<T> : EventArgs
    {
        public StateUpdateEventArgs(T appState, Session<T> state)
        {
            State = appState;
            Session = state;
        }

        public T State { get; }
        public Session<T> Session { get; }
    }
}
