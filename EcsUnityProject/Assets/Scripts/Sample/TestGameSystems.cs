using Ecs;

namespace Sample
{
    public sealed class TestGameSystems
    {
        public TestGameSystems(ISystems systems, IWorld world)
        {
            systems.Add(new HelloWorldSystem(world));
        }
    }
}