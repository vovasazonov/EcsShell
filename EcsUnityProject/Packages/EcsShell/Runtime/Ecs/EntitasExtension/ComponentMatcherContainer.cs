using System.Collections.Generic;

namespace Ecs.EntitasExtension
{
    internal sealed class ComponentMatcherContainer
    {
        private readonly IComponentsInfo _info;
        private readonly Dictionary<int, Entitas.Matcher<Entity>> _matchers = new Dictionary<int, Entitas.Matcher<Entity>>();

        public ComponentMatcherContainer(IComponentsInfo info)
        {
            _info = info;
        }

        public Entitas.IMatcher<Entity> GetMatcher<T>() where T : struct
        {
            int index = _info.GetIndex<T>();

            if (!_matchers.TryGetValue(index, out var matcher))
            {
                matcher = (Entitas.Matcher<Entity>) Entitas.Matcher<Entity>.AllOf(index);
                matcher.componentNames = _info.Names;
                _matchers.Add(index, matcher);
            }

            return matcher;
        }
    }
}