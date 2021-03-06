using System;
using System.Collections.Generic;

namespace Ecs
{
    public sealed class HandleEventComponentSystem<TComponent> : IReactSystem, IEventSystem where TComponent : struct
    {
        readonly List<IComponentListener<TComponent>> _listenerBuffer;
        private readonly IFilter _filter;
        public Func<IWorldMatcher, IMatcher> Matcher { get; } = matcher => matcher.Has<TComponent>();

        public HandleEventComponentSystem(IWorld world)
        {
            _listenerBuffer = new List<IComponentListener<TComponent>>();
            _filter = world.GetFilter(m => m.Has<TComponent>().Has<ListenerComponent<TComponent>>());
        }

        public void Update()
        {
            foreach (var entity in _filter.GetEntities())
            {
                var component = entity.Get<TComponent>();
                _listenerBuffer.Clear();
                _listenerBuffer.AddRange(entity.Get<ListenerComponent<TComponent>>().Value);
                foreach (var listener in _listenerBuffer)
                {
                    listener.OnChanged(entity, component);
                }
            }
        }
    }
}