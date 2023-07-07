using System;

namespace Twileloop.SessionGuard.State
{
    public class State<T> : IState<T>
    {
        public T GetState()
        {
            throw new NotImplementedException();
        }

        public void SetState(T state)
        {
            throw new NotImplementedException();
        }
    }
}
