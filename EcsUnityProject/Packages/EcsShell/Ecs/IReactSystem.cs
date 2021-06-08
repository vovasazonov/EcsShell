using System;

namespace Ecs
{
    public interface IReactSystem : IUpdateSystem
    {
        public Func<IWorldMatcher, IMatcher> Matcher { get; }
    }
}