using System;
using System.Collections.Generic;
using Twileloop.SessionGuard.State;

namespace Twileloop.SessionGuard.Models
{
    public class StateUpdateEventArgs<T> : EventArgs
    {
        public StateUpdateEventArgs(T appState, List<string> fieldsUpdated, Session<T> state)
        {
            State = appState;
            FieldsUpdated = fieldsUpdated;
            Session = state;
        }

        public T State { get; }
        public Session<T> Session { get; }
        public List<string> FieldsUpdated { get; set; }
    }
}
