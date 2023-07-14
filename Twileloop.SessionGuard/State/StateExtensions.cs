using System;
using System.Text.Json;

namespace Twileloop.SessionGuard.State
{
    public static class StateExtensions
    {
        public static void SetState<T>(this Session<T> state, Action<T> updateAction)
        {
            var previousState = JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(state.State));
            updateAction(state.State);
            var diffs = DiffChecker<T>.GetChangedProperties(previousState, state.State);
            state.LoadState(state.State, diffs);
        }
    }
}
