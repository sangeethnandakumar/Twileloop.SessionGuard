using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Twileloop.SessionGuard.State;

namespace Twileloop.SessionGuard.Abstractions
{
    public partial class StatefullUserControl : UserControl
    {
        public readonly Session<AppState> Session = Session<AppState>.Instance;
        public string ComponentName { get; set; }

        public StatefullUserControl()
        {
            if (Session.State is null)
            {
                Session.State = new AppState();
            }
        }

        public State<U> UseState<U>(string name, U value)
        {
            //Get the component
            var calleeComponent = Session.State.Components.FirstOrDefault(component => component.Name == ComponentName);
            if (calleeComponent is not null)
            {
                //Get the state
                var calleeState = calleeComponent.States.OfType<State<U>>().FirstOrDefault(state => state.Name == name);
                if (calleeState is not null)
                {
                    calleeState.Value = value;
                    return calleeState;
                }
                else
                {
                    var newState = new State<U>
                    {
                        Component = calleeComponent,
                        Name = name,
                        Value = value
                    };
                    calleeComponent.States.Add(newState);
                    return newState;
                }
            }
            else
            {
                var newComponent = new Component
                {
                    Name = ComponentName,
                    Renderer = Render,
                    States = new ArrayList()
                };
                var newState = new State<U>
                {
                    Component = newComponent,
                    Name = name,
                    Value = value
                };
                newComponent.States.Add(newState);
                Session.State.Components.Add(newComponent);
                return newState;
            }
        }

        public void UseChild<W>(string childName, params State<W>[] dependentStates)
        {
            var childComponent = Session.State.Components.FirstOrDefault(component => component.Name == childName);
            if (childComponent is not null)
            {
                childComponent.States.Clear();
                childComponent.States.AddRange(dependentStates);
                Session.State.Components.FirstOrDefault(component => component.Name == ComponentName).Children.Add(childComponent);
            }
            else
            {
                var newComponent = new Component
                {
                    Name = childName,
                    Renderer = Render,
                    States = new ArrayList()
                };
                newComponent.States.Add(dependentStates);
                Session.State.Components.Add(newComponent);
            }
        }

        public virtual void Render()
        {
            Debug.WriteLine($"{DateTime.Now.TimeOfDay} - {ComponentName} Rendering...");
        }
    }

    public partial class StatefullForm : Form
    {
        public readonly Session<AppState> Session = Session<AppState>.Instance;
        public string ComponentName { get; init; }

        public StatefullForm()
        {
            if (Session.State is null)
            {
                Session.State = new AppState();
            }
        }

        public State<U> UseState<U>(string name, U value)
        {
            //Get the component
            var calleeComponent = Session.State.Components.FirstOrDefault(component => component.Name == ComponentName);
            if (calleeComponent is not null)
            {
                //Get the state
                var calleeState = calleeComponent.States.OfType<State<U>>().FirstOrDefault(state => state.Name == name);
                if (calleeState is not null)
                {
                    calleeState.Value = value;
                    return calleeState;
                }
                else
                {
                    var newState = new State<U>
                    {
                        Component = calleeComponent,
                        Name = name,
                        Value = value
                    };
                    calleeComponent.States.Add(newState);
                    return newState;
                }
            }
            else
            {
                var newComponent = new Component
                {
                    Name = ComponentName,
                    Renderer = Render,
                    States = new ArrayList()
                };
                var newState = new State<U>
                {
                    Component = newComponent,
                    Name = name,
                    Value = value
                };
                newComponent.States.Add(newState);
                Session.State.Components.Add(newComponent);
                return newState;
            }
        }

        public void UseChild<W>(string childName, params State<W>[] dependentStates)
        {
            var childComponent = Session.State.Components.FirstOrDefault(component => component.Name == childName);
            if (childComponent is not null)
            {
                childComponent.States.Clear();
                childComponent.States.AddRange(dependentStates);
                Session.State.Components.FirstOrDefault(component => component.Name == ComponentName).Children.Add(childComponent);
            }
            else
            {
                var newComponent = new Component
                {
                    Name = childName,
                    Renderer = Render,
                    States = new ArrayList()
                };
                newComponent.States.Add(dependentStates);
                Session.State.Components.Add(newComponent);
            }
        }

        public virtual void Render()
        {
            Debug.WriteLine($"{DateTime.Now.TimeOfDay} - {ComponentName} Rendering...");
        }
    }
}
