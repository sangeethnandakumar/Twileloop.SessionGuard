using System;
using System.Collections.Generic;
using System.Linq;

namespace Twileloop.SessionGuard.State
{

    public class Session<T>
    {
        public T State { get; set; }
        private static Session<T> instance;
        public List<Component> Components { get; set; } = new List<Component>();
        public Dictionary<string, Component> ComponentDictionary { get; set; } = new Dictionary<string, Component>();


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
