using System;
using System.Collections.Generic;

namespace Ecs.EntitasExtension
{
    public abstract class ProjectEcsInfo : IProjectEcsInfo
    {
        private readonly HashSet<Type> _components = new HashSet<Type>();
        private readonly List<Func<IWorld, ISystem>> _eventSystems = new List<Func<IWorld, ISystem>>();
        
        public IComponentsInfo ComponentsInfo => new ComponentsInfo(_components);
        
        public void InitEventSystems(IWorld world, ISystems systems)
        {
            foreach (var eventSystem in _eventSystems)
            {
                systems.Add(eventSystem.Invoke(world));
            }
        }

        protected void Init<T>(bool isEvent = false) where T : struct
        {
            var type = typeof(ComponentShell<T>);
            _components.Add(type);

            if (isEvent)
            {
                Init<ListenerComponent<T>>();
                _eventSystems.Add(world => new EventSystem<T>(world));
            }
        }
    }
}