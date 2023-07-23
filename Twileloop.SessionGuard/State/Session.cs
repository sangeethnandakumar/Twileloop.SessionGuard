using ObjectsComparator.Comparator.RepresentationDistinction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Twileloop.SessionGuard.Models;

namespace Twileloop.SessionGuard.State
{

    public class Session<T>
    {
        public T State { get; set; }
        private static Session<T> instance;
        public List<Component> Components { get; set; } = new List<Component>();
        public ArrayList AppStates { get; set; } = new ArrayList();

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
            var matchedComponent = Components.FirstOrDefault(x => x.ComponentId == componentId);
            if (matchedComponent == null)
            {
                var activeComponent = new Component
                {
                    ComponentId = componentId
                };
                var state = new AtomicState<U>
                {
                    ComponentId = componentId,
                    UniqueIdentifier = name,
                    Value = value
                };
                activeComponent.Renderer = renderer;
                activeComponent.DependentStates.Add(state);
                Components.Add(activeComponent);
                return state;
            }
            else
            {
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
        }

        public void RegisterChildComponents<U, W>(U parentComponent, Type childComponent, params AtomicState<W>[] dependentStates)
        {
            var componentId = parentComponent.ToString().Split(",")[0];
            var matchedComponent = Components.FirstOrDefault(x => x.ComponentId == componentId);
            matchedComponent.ChildComponents.Add((childComponent.ToString(), dependentStates.Select(x=>x.UniqueIdentifier).ToList()));
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
