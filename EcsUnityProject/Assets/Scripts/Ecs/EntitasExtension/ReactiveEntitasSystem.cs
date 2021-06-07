using System;
using System.Collections.Generic;

namespace Ecs.EntitasExtension
{
    internal sealed class ReactiveEntitasSystem<T> : Entitas.ReactiveSystem<Entity>
    {
        private readonly IReactSystem _reactSystem;
        private readonly IWorldMatcher _worldMatcher;

        public ReactiveEntitasSystem(Entitas.IContext<Entity> context, IReactSystem reactSystem, IWorldMatcher worldMatcher) : base(context)
        {
            _reactSystem = reactSystem;
            _worldMatcher = worldMatcher;
        }

        protected override Entitas.ICollector<Entity> GetTrigger(Entitas.IContext<Entity> context)
        {
            Entitas.IMatcher<Entity> matcher = ((Matcher) _reactSystem.Matcher.Invoke(_worldMatcher)).GetMatcher();
            int indices = matcher.indices.Length;
            if (indices > 1 || indices == 0)
            {
                throw new NotSupportedException("System can react only to one component.");
            }

            return context.CreateCollector(matcher);
        }

        protected override bool Filter(Entity entity)
        {
            return false;
        }

        protected override void Execute(List<Entity> filter)
        {
            _reactSystem.React();
        }
    }
}