namespace Twileloop.SessionGuard.State
{

    public class Session<T>
    {
        public T State { get; set; }
        private static Session<T> instance;

        private Session()
        {
        }

        public static Session<T> Instance
        {
            get
            {
                if (instance == null)
                    instance = new Session<T>();

                return instance;
            }
        }
    }
}
