using System;

namespace Ecs
{
    public interface IWorld
    {
        IEntity CreateEntity();
        IFilter GetFilter(Func<IWorldMatcher, IMatcher> matcher);
    }
}