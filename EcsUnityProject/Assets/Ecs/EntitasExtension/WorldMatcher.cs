namespace Ecs.EntitasExtension
{
    internal sealed class WorldMatcher : IWorldMatcher
    {
        private readonly ComponentMatcherContainer _container;

        public WorldMatcher(IComponentsInfo info)
        {
            _container = new ComponentMatcherContainer(info);
        }

        public IMatcher Has<T>() where T : struct
        {
            var matcher = new Matcher(_container);
            return matcher.Has<T>();
        }
    }
}