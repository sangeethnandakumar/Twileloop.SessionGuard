using System;
using System.Collections;
using System.Collections.Generic;

namespace Twileloop.SessionGuard.State
{
    public class Component
    {
        public string Name { get; set; }
        public ArrayList States { get; set; } = new ArrayList();
        public List<Component> Children { get; set; } = new List<Component>();
        public Action Renderer { get; set; }

        public override string ToString()
        {
            return $"{Name} Component";
        }
    }
}
