using System;

namespace Ecs
{
    public interface IReactSystem : ISystem
    {
        public Func<IWorldMatcher, IMatcher> Matcher { get; }
        public void React();
    }
}