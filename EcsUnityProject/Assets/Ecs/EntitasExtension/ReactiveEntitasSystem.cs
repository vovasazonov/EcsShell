using System;
using System.Collections.Generic;

namespace Ecs.EntitasExtension
{
    internal sealed class ReactiveEntitasSystem<T> : Entitas.ReactiveSystem<Entity>
    {
        private readonly IReactSystem _reactSystem;

        public ReactiveEntitasSystem(IReactSystem reactSystem, Entitas.ICollector<Entity> collector) : base(collector)
        {
            _reactSystem = reactSystem;
        }

        protected override Entitas.ICollector<Entity> GetTrigger(Entitas.IContext<Entity> context)
        {
            throw new NotSupportedException();
        }

        protected override bool Filter(Entity entity)
        {
            return true;
        }

        protected override void Execute(List<Entity> filter)
        {
            _reactSystem.Update();
        }
    }
}