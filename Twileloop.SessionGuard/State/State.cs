using System.Linq;
using Twileloop.SessionGuard.State.Internal;

namespace Twileloop.SessionGuard.State
{
    public class State<U>
    {
        public Component Component { get; set; }
        public string Name { get; set; }
        public U Value { get { return Get<U>(); } set { Set(value); } }
        internal U InternalValue { get; set; }

        public override string ToString()
        {
            return $"{Name} = '{InternalValue}'";
        }

        private U Get<U>()
        {
            var activeState = Component.States.OfType<State<U>>().FirstOrDefault(x => x.Name == Name);
            if (activeState is not null)
            {
                return activeState.InternalValue;
            }
            return default(U);
        }

        private void Set(U value)
        {
            if (InternalValue.ToString() != value.ToString())
            {
                InternalValue = value;
                var doesComponentHasDependency = Component.States.OfType<State<U>>().Where(x => x.Name == Name).Any();
                if (doesComponentHasDependency)
                {
                    Component.Renderer();
                    RenderRecursively(Component, Name);
                }
            }
        }

        private void RenderRecursively(Component component, string name)
        {
            foreach (var child in component.Children)
            {
                child.Renderer();
                RenderRecursively(child, Name);
            }
        }
    }
}
