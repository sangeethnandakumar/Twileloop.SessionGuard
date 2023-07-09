using System;

namespace Twileloop.SessionGuard.Models
{
    public class StateUpdateEventArgs<T> : EventArgs
    {
        public T State { get; }

        public StateUpdateEventArgs(T updatedState)
        {
            State = updatedState;
        }
    }
}
