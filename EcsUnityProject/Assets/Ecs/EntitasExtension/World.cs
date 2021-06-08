using System;

namespace Ecs.EntitasExtension
{
    public sealed class World : IWorld
    {
        private readonly WorldMatcher _matcher;
        private readonly Entitas.Context<Entity> _context;

        internal WorldMatcher Matcher => _matcher;
        internal Entitas.Context<Entity> Context => _context;

        public World(IComponentsInfo componentsInfo, string name = "World")
        {
            _context = CreateContext();
            _matcher = new WorldMatcher(componentsInfo);

            Entitas.Context<Entity> CreateContext()
            {
                Entitas.ContextInfo contextInfo = new Entitas.ContextInfo(name, componentsInfo.Names, componentsInfo.Types);

                Entitas.IAERC AercFactory(Entitas.IEntity entity)
                {
#if (ENTITAS_FAST_AND_UNSAFE)
                    return new Entitas.UnsafeAERC();
#else
                    return new Entitas.SafeAERC(entity);
#endif
                }

                Entity EntityFactory() => new Entity(componentsInfo);

                return new Entitas.Context<Entity>(componentsInfo.Total, 0, contextInfo, AercFactory, EntityFactory);
            }
        }

        IEntity IWorld.CreateEntity()
        {
            return _context.CreateEntity();
        }

        private IFilter GetFilter(IMatcher matcher)
        {
            Entitas.IMatcher<Entity> entitasMatcher = ((Matcher) matcher).GetMatcher();
            Entitas.IGroup<Entity> group = _context.GetGroup(entitasMatcher);
            IFilter filter = new Filter(group);
            return filter;
        }

        public IFilter GetFilter(Func<IWorldMatcher, IMatcher> matcher)
        {
            return GetFilter(matcher.Invoke(_matcher));
        }
    }
}