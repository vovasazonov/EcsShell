using Ecs;

namespace Sample
{
    public class GameSystems : GroupSystem
    {
        public GameSystems(ISystems systems, IWorld world) : base(systems)
        {
            Add(new HelloWorldSystem(world));
        }
    }
}