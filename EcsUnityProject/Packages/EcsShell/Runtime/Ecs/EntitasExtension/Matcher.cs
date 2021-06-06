using System.Collections.Generic;
using System.Linq;

namespace Ecs.EntitasExtension
{
    internal sealed class Matcher : IMatcher
    {
        private readonly ComponentMatcherContainer _container;
        private readonly HashSet<Entitas.IMatcher<Entity>> _has = new HashSet<Entitas.IMatcher<Entity>>();
        private readonly HashSet<Entitas.IMatcher<Entity>> _none = new HashSet<Entitas.IMatcher<Entity>>();

        public Matcher(ComponentMatcherContainer container)
        {
            _container = container;
        }
        
        internal Entitas.IMatcher<Entity> GetMatcher()
        {
            var matcher = Entitas.Matcher<Entity>.AllOf(_has.ToArray());

            if (_none.Any())
            {
                matcher.NoneOf(_none.ToArray());
            }

            return matcher;
        }

        public IMatcher Has<T>() where T : struct
        {
            var matcher = _container.GetMatcher<T>();
            _has.Add(matcher);
            return this;
        }

        public IMatcher None<T>() where T : struct
        {
            var matcher = _container.GetMatcher<T>();
            _none.Add(matcher);
            return this;
        }
    }
}