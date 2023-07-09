namespace Twileloop.SessionGuard.State
{
    public interface IState<T>
    {
        T GetState();
        void LoadState(T state);
    }
}
