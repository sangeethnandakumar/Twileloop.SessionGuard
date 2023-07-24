using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;

namespace Twileloop.SessionGuard.State
{
    public class State<U>
    {
        public Component Component { get; set; }
        public string Name { get; set; }
        internal U Value { get; set; }

        public override string ToString()
        {
            return $"{Name} = '{Value}'";
        }

        public U Get<U>()
        {
            var activeState = Component.States.OfType<State<U>>().FirstOrDefault(x => x.Name == Name);
            if(activeState is not null)
            {
                return activeState.Value;
            }
            return default(U);
        }

        public void Set(U value)
        {
            if (Value.ToString() != value.ToString())
            {
                Value = value;
                var doesComponentHasDependency = Component.States.OfType<State<U>>().Where(x => x.Name == Name).Any();
                if (doesComponentHasDependency)
                {
                    Component.Renderer();
                    RenderRecursively(Component, Name);
                }
            }
        }

        public void RenderRecursively(Component component, string name)
        {
            foreach (var child in component.Children)
            {
                child.Renderer();
                RenderRecursively(child, Name);
            }
        }
    }
}
