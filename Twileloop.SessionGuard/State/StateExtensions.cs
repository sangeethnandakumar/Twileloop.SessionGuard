using System;

namespace Twileloop.SessionGuard.State
{
    public static class StateExtensions
    {
        public static void SetState<T>(this IState<T> state, Action<T> updateAction)
        {
            T currentState = state.GetState();
            updateAction(currentState);
            state.LoadState(currentState);
        }
    }
}
