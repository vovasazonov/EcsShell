namespace Ecs
{
    public abstract class GroupSystem : ISystem
    {
        private readonly ISystems _systems;

        protected GroupSystem(ISystems systems)
        {
            _systems = systems;
        }

        protected void Add<TSystem>(TSystem system) where TSystem : ISystem
        {
            _systems.Add(system);
        }
    }
}