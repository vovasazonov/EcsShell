using System.Collections.Generic;

namespace Ecs
{
    public interface IFilter
    {
        int Count { get; }
        IEnumerator<IEntity> GetEnumerator();
        IEnumerable<IEntity> GetEntities();
    }
}