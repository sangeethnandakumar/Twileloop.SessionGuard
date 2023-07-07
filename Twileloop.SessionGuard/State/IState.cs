namespace Twileloop.SessionGuard.State
{
    public interface IState<T>
    {
        T GetState();
        void SetState(T state);
    }
}
