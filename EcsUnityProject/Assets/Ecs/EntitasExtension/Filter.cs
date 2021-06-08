using System.Collections.Generic;

namespace Ecs.EntitasExtension
{
    internal sealed class Filter : IFilter
    {
        private readonly Entitas.IGroup<Entity> _group;

        public Filter(Entitas.IGroup<Entity> group)
        {
            _group = group;
        }

        public IEnumerator<IEntity> GetEnumerator()
        {
            return _group.GetEnumerator();
        }

        public IEnumerable<IEntity> GetEntities()
        {
            return _group.GetEntities();
        }
    }
}