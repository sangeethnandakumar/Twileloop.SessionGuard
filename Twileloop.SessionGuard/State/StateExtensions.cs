using ObjectsComparator.Comparator.Helpers;
using System;
using System.Linq;
using System.Text.Json;

namespace Twileloop.SessionGuard.State
{
    public static class StateExtensions
    {

        public static void SetState<S, T>(this Session<S> session, object formState, AtomicState<T> atomicState, T newValue)
        {
            foreach(var component in session.Components)
            {
                if(component.ComponentId == formState.ToString().Split(",")[0])
                {
                    foreach(var dependentState in component.DependentStates)
                    {
                        if (dependentState is AtomicState<T>)
                        {
                            var matchState = (AtomicState<T>)dependentState;
                            if (
                                matchState.UniqueIdentifier == atomicState.UniqueIdentifier &&
                                matchState.ComponentId == formState.ToString().Split(",")[0]
                                )
                            {
                                matchState.Value = newValue;
                                component.Renderer();

                                //Find all dependent child components who also need to update
                                foreach (var child in component.ChildComponents)
                                {
                                    var childComponent = session.Components.FirstOrDefault(x => x.ComponentId == child.Item1);
                                    if(childComponent != null)
                                    {
                                        foreach (var depState in childComponent.DependentStates)
                                        {
                                            if (depState is AtomicState<T>)
                                            {
                                                var updatedState = (AtomicState<T>)depState;
                                                updatedState.Value = newValue;
                                                childComponent.Renderer();
                                                return;
                                            }
                                        }
                                    }
                                }

                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
