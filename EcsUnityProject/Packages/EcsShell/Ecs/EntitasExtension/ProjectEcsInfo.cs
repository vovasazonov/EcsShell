using System;
using System.Collections.Generic;

namespace Ecs.EntitasExtension
{
    public abstract class ProjectEcsInfo
    {
        private readonly HashSet<Type> _components = new HashSet<Type>();
        private readonly List<Func<IWorld, ISystem>> _eventSystems = new List<Func<IWorld, ISystem>>();
        private readonly List<Func<IWorld, ISystem>> _frameSystems = new List<Func<IWorld, ISystem>>();

        internal IComponentsInfo ComponentsInfo => new ComponentsInfo(_components);

        internal void InitDefaultSystems(IWorld world, ISystems systems)
        {
            InitFrameSystems(world, systems);
            InitEventSystems(world, systems);
        }

        private void InitFrameSystems(IWorld world, ISystems systems)
        {
            foreach (var frameSystem in _frameSystems)
            {
                systems.Add(frameSystem.Invoke(world));
            }
        }

        private void InitEventSystems(IWorld world, ISystems systems)
        {
            foreach (var eventSystem in _eventSystems)
            {
                systems.Add(eventSystem.Invoke(world));
            }
        }

        protected void Init<T>() where T : struct
        {
            _components.Add(typeof(ComponentShell<T>));
            object[] attributes = typeof(T).GetCustomAttributes(false);

            foreach (FrameAttribute attribute in attributes)
            {
                _frameSystems.Add(world => new HandleFrameComponentSystem<T>(world, attribute.IsDestroyEntity));
            }

            foreach (EventAttribute attribute in attributes)
            {
                Init<ListenerComponent<T>>();
                _eventSystems.Add(world => new HandleEventComponentSystem<T>(world));
            }
        }
    }
}