using System;
using System.Collections.Generic;
using Twileloop.SessionGuard.Models;

namespace Twileloop.SessionGuard.State
{

    public class Session<T>
    {
        private static Session<T> instance;
        public T State { get; set; }
        public List<string> FieldsUpdated { get; set; }
        public event EventHandler<StateUpdateEventArgs<T>> OnStateUpdated;

        private Session() { }

        public static Session<T> Instance
        {
            get
            {
                if (instance == null)
                    instance = new Session<T>();

                return instance;
            }
        }

        public void LoadState(T newState, List<string> fieldsUpdated = null)
        {
            State = newState;
            FieldsUpdated = fieldsUpdated is null ? new List<string>() : fieldsUpdated;
            OnStateUpdated?.Invoke(this, new StateUpdateEventArgs<T>(State, FieldsUpdated, this));
        }

        public void Bind(string field, Action onFieldUpdate)
        {
            if (FieldsUpdated.Contains(field))
            {
                onFieldUpdate();
            }
        }
    }
}
