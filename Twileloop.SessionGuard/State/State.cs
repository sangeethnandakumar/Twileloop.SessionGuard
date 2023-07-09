using System;
using Twileloop.SessionGuard.Models;

namespace Twileloop.SessionGuard.State
{

    public class State<T> : IState<T>
    {
        private static State<T> instance;
        private T state;
        public event EventHandler<StateUpdateEventArgs<T>> OnStateUpdated;

        private State() { }

        public static State<T> Instance
        {
            get
            {
                if (instance == null)
                    instance = new State<T>();

                return instance;
            }
        }

        public T GetState()
        {
            return state;
        }

        public void LoadState(T newState)
        {
            state = newState;
            OnStateUpdated?.Invoke(this, new StateUpdateEventArgs<T>(state));
        }
    }
}
