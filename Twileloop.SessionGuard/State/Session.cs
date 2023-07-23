using System;
using System.Collections;
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

        public AtomicState<U> UseState<U>(object component, string name, U value, Action renderer)
        {
            var componentId = component.ToString().Split(",")[0];
            if (!ComponentDictionary.TryGetValue(componentId, out var matchedComponent))
            {
                matchedComponent = new Component
                {
                    ComponentId = componentId
                };
                Components.Add(matchedComponent);
                ComponentDictionary[componentId] = matchedComponent;
            }

            var state = new AtomicState<U>
            {
                ComponentId = componentId,
                UniqueIdentifier = name,
                Value = value
            };

            matchedComponent.Renderer = renderer;
            matchedComponent.DependentStates.Add(state);
            return state;
        }


        public void RegisterChildComponents<U, W>(U parentComponent, Type childComponent, params AtomicState<W>[] dependentStates)
        {
            var componentId = parentComponent.ToString().Split(",")[0];
            if (ComponentDictionary.TryGetValue(componentId, out var matchedComponent))
            {
                matchedComponent.ChildComponents.Add((childComponent.ToString(), dependentStates.Select(x => x.UniqueIdentifier).ToList()));
            }
        }
    }

    public class AtomicState<U>
    {
        public string ComponentId { get; set; }
        public string UniqueIdentifier { get; set; }
        public U Value { get; set; }


        public override string ToString()
        {
            return $"{Value} | {UniqueIdentifier}";
        }
    }

    public class Component
    {
        public string ComponentId { get; set; }
        public ArrayList DependentStates { get; set; } = new ArrayList();
        public List<(string, List<string>)> ChildComponents { get; set; } = new List<(string, List<string>)>();
        public Action Renderer { get; set; }

        public override string ToString()
        {
            return $"{ComponentId} | {DependentStates.Count} Dependent States";
        }
    }
}
