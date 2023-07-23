using System.Linq;

namespace Twileloop.SessionGuard.State
{
    public static class StateExtensions
    {

        public static void SetState<S, T>(this Session<S> session, object formState, AtomicState<T> atomicState, T newValue)
        {
            var componentId = formState.ToString().Split(",")[0];

            if (session.ComponentDictionary.TryGetValue(componentId, out var component))
            {
                var dependentStatesOfTypeT = component.DependentStates.OfType<AtomicState<T>>().ToList();

                foreach (var dependentState in dependentStatesOfTypeT)
                {
                    if (dependentState.UniqueIdentifier == atomicState.UniqueIdentifier)
                    {
                        dependentState.Value = newValue;
                        component.Renderer();

                        foreach (var (childComponentId, childDependentStates) in component.ChildComponents)
                        {
                            if (session.ComponentDictionary.TryGetValue(childComponentId, out var childComponent))
                            {
                                var childDependentStatesOfTypeT = childComponent.DependentStates.OfType<AtomicState<T>>().ToList();

                                foreach (var depState in childDependentStatesOfTypeT)
                                {
                                    if (childDependentStates.Contains(depState.UniqueIdentifier))
                                    {
                                        depState.Value = newValue;
                                        childComponent.Renderer();
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
