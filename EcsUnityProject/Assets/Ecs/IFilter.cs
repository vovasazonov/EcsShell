using System.Collections.Generic;

namespace Ecs
{
    public interface IFilter
    {
        IEnumerator<IEntity> GetEnumerator();
        IEnumerable<IEntity> GetEntities();
    }
}