using System;
using System.Collections.Generic;

namespace Ecs.EntitasExtension
{
    public abstract class ProjectComponents : IProjectComponents
    {
        private readonly HashSet<Type> _components = new HashSet<Type>();
        public IEnumerable<Type> Components => _components;

        protected void Init<T>() where T : struct
        {
            var type = typeof(ComponentShell<T>);
            _components.Add(type);
        }
    }
}